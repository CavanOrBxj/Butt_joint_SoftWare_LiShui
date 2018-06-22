using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Threading;
namespace GRPlatForm
{
    public class V5KStreamer
    {
        public bool m_bPlayFlag = false;
        string strNO;
        string m_strCPPPlayPath;
        string m_strMediaPathName;
        string m_IPinfo;
        string m_strPiPeName;
        string m_strEventName;
        string m_nAudioPID;
        string m_nVedioPID;
        string m_nVedioRat;
        string m_nAuioRat;
        Microsoft.Win32.SafeHandles.SafeWaitHandle m_handle;
        NamedPipeServerStream pipeStream = null;
        bool CFlag = false;
        object locked = new object();

        //需要停止的播放任务
        // public string TsCmdStoreID;//任务的ID
        public bool init(string strCPPPlayPath, string strMediaPathName, string strIPinfo, string strPiPeName, string strEventName)
        {
            m_strCPPPlayPath = strCPPPlayPath;
            m_strMediaPathName = strMediaPathName;
            m_IPinfo = strIPinfo;
            return true;
        }
        public bool CreatePipeandEvent(string strPiPeName, string strEventName)
        {
            try
            {
                m_strPiPeName = strPiPeName;
                m_strEventName = strEventName;
                pipeStream = new NamedPipeServerStream(strPiPeName);
                m_handle = CoreEvent.CreateEvent(default(IntPtr), false, false, strEventName);
                CFlag = false;//停止的标示
                strNO = strNO + "1";
                return true;

            }
            catch
            {
                return false;
            }
        }
        public void StopCPPPlayer()
        {
            try
            {
                pipeStream.WaitForConnection();
                using (StreamReader sr = new StreamReader(pipeStream))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Thread.Sleep(500);
                        string strValue = line;
                        if (line == "-1000")
                        {
                            //CFlag=true;
                            Console.WriteLine(line);
                            break;
                        }
                    }
                }
                //CoreEvent.SetEvent(m_handle);
                lock (locked)
                {
                    if (!CFlag)
                    {

                        CoreEvent.SetEvent(m_handle);
                        //CoreEvent.CloseHandle(m_handle);
                        pipeStream.Close();
                        CFlag = true;
                    }
                }
                //CoreEvent.CloseHandle(m_handle);
            }
            catch
            {
                return;
            }
        }
        public void StopCPPPlayer2()
        {
            try
            {
                lock (locked)
                {
                    if (!CFlag)
                    {
                        CoreEvent.SetEvent(m_handle);
                        //CoreEvent.CloseHandle(m_handle);
                        pipeStream.Close();
                        CFlag = true;
                    }
                }
            }
            catch
            {
                return;
            }
        }


        public bool CreateCPPPlayer()
        {
            string strPath = m_strCPPPlayPath;
            try
            {
                string strCmd = m_strMediaPathName; //  "file:///D:/123.mp3 192.168.34.86 4007 103 hshuh-448-48485-5844 101 pipename 11600 128";
                strCmd += " ";
                strCmd += m_IPinfo;
                strCmd += " ";
                strCmd += m_strEventName;
                strCmd += " ";
                strCmd += m_strPiPeName;

                Process proc = new Process();
                proc.StartInfo.FileName = m_strCPPPlayPath;
                proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(m_strCPPPlayPath);
                proc.StartInfo.Arguments = strCmd;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.Start();


                //string strCmd = "D:\\Abutment\\93\\AudioFiles\\EBDR_5fc74408-04cf-44e4-805b-152dd1fc5b08.mp3 rtp://192.168.4.108:6666 EVENT";
                //Process proc = new Process();
                //proc.StartInfo.FileName = @"C:\Users\Administrator\Documents\Tencent Files\353751786\FileRecv\CmdShellGet\bin\Release\V5KStreamer.exe";
                //proc.StartInfo.WorkingDirectory = @"C:\Users\Administrator\Documents\Tencent Files\353751786\FileRecv\CmdShellGet\bin\Release";
                //proc.StartInfo.Arguments = strCmd;
                //proc.StartInfo.CreateNoWindow = true;
                //proc.StartInfo.UseShellExecute = false;
                //proc.StartInfo.RedirectStandardOutput = true;
                //proc.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
