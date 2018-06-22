using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace GRPlatForm
{
    public partial class mainForm : Form
    {
        public IniFiles ini;
        //子窗体定义
        private ServerIPSetForm setipFrm;
        private ServerSetForm setServerFrm;
        private TmpFolderSetForm tmpforldFrm;
        private InfoSetForm infoFrm;
        private ServerForm serverFrm;
        //
        public static dbAccess dba;
        public List<string> lTarPathName = new List<string>();//接收到的Tar包列表
        public static string sSendTarName = "";//发送Tar包名字

        //public bool MQStartFlag = false;
        public string strSourceType = "";
        public string strSourceName = "";
        public string strSourceID = "";
       // public static string m_UsbPwsSupport = "";
        public static SerialPort comm = new SerialPort();
        public static SerialPort sndComm = new SerialPort();//临时发送语音用

        public static bool bWaitOrNo = true;//等待 2016-04-01
        public static bool bMsgStatusFree = false;//

        private List<byte> lCommData = new List<byte>();
        private object oComm = new object();
        private Thread thComm;

       // public USBE usb = new USBE();
        public Scrambler scrambler = new Scrambler();//密码器
        public IntPtr phDeviceHandle = (IntPtr)1;

        public mainForm()
        {
            InitializeComponent();
            ini = new IniFiles(@Application.StartupPath + "\\Config.ini");
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //  m_UsbPwsSupport = ini.ReadValue("USBPSW", "USBPSWSUPPART");
                //MQStartFlag = ini.ReadValue("[MQInfo]", "IsStartFlag") == "1" ? true : false;//判断是否启用MQ

                //打开密码器  丽水松阳项目不使用此密码器  20180227
                //if (m_UsbPwsSupport == "1")
                //{
                //    try
                //    {
                //        int nReturn = usb.USB_OpenDevice(ref phDeviceHandle);
                //        if (nReturn != 0)
                //        {
                //            MessageBox.Show("密码器打开失败！");
                //        }
                //    }
                //    catch (Exception em)
                //    {
                //        MessageBox.Show("密码器打开失败：" + em.Message);
                //    }
                //}


                //初始化签名验签函数

                //int nReturn = scrambler.InitializeLSEB();
                //if (nReturn != 0)
                //{
                //    MessageBox.Show("初始化签名验签失败！");
                //}

                //初始化写日志线程
                string sLogPath = Application.StartupPath + "\\Log";
                if (!Directory.Exists(sLogPath))
                    Directory.CreateDirectory(sLogPath);
                Log.Instance.LogDirectory = sLogPath + "\\";
                Log.Instance.FileNamePrefix = "EBD_";
                Log.Instance.CurrentMsgType = MsgLevel.Debug;
                Log.Instance.logFileSplit = LogFileSplit.Daily;
                Log.Instance.MaxFileSize = 2;
                Log.Instance.InitParam();

                AreaMappingHelper.InitDic();

                AreaMapping.InitDic();
                SingletonInfo.GetInstance().Longitude = ini.ReadValue("INFOSET", "Longitude");
                SingletonInfo.GetInstance().Latitude = ini.ReadValue("INFOSET", "Latitude");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region 菜单响应

        private void mnuServerAddrSet_Click(object sender, EventArgs e)
        {
            if (setServerFrm == null || setServerFrm.IsDisposed)
            {
                setServerFrm = new ServerSetForm();
                setServerFrm.MdiParent = this;
                setServerFrm.Show();
            }
            else
            {
                if (setServerFrm.WindowState == FormWindowState.Minimized)
                {
                    setServerFrm.WindowState = FormWindowState.Normal;
                }
                else
                    setServerFrm.Activate();
            }
        }

        private void ServerIPSet_Click(object sender, EventArgs e)
        {
            if (setipFrm == null || setipFrm.IsDisposed)
            {
                setipFrm = new ServerIPSetForm();
                setipFrm.MdiParent = this;
                setipFrm.Show();
            }
            else
            {
                if (setipFrm.WindowState == FormWindowState.Minimized)
                {
                    setipFrm.WindowState = FormWindowState.Normal;
                }
                else
                    setipFrm.Activate();
            }
        }

        private void mnuFolderSet_Click(object sender, EventArgs e)
        {
            if (tmpforldFrm == null || tmpforldFrm.IsDisposed)
            {
                tmpforldFrm = new TmpFolderSetForm();
                tmpforldFrm.MdiParent = this;
                tmpforldFrm.Show();
            }
            else
            {
                if (tmpforldFrm.WindowState == FormWindowState.Minimized)
                {
                    tmpforldFrm.WindowState = FormWindowState.Normal;
                }
                else
                    tmpforldFrm.Activate();
            }
        }

        private void mnuSysInfoSet_Click(object sender, EventArgs e)
        {
            if (infoFrm == null || infoFrm.IsDisposed)
            {
                infoFrm = new InfoSetForm();
                infoFrm.MdiParent = this;
                infoFrm.Show();
            }
            else
            {
                if (infoFrm.WindowState == FormWindowState.Minimized)
                {
                    infoFrm.WindowState = FormWindowState.Normal;
                }
                else
                    infoFrm.Activate();
            }
        }

        private void mnuServerStart_Click(object sender, EventArgs e)
        {
            if (serverFrm == null || serverFrm.IsDisposed)
            {
                try
                {
                    serverFrm = new ServerForm();
                    serverFrm.MdiParent = this;
                    serverFrm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "mainFormb");
                }
            }
            else
            {
                if (serverFrm.WindowState == FormWindowState.Minimized)
                {
                    serverFrm.WindowState = FormWindowState.Normal;
                }
                else
                    serverFrm.Activate();
            }
        }

        #endregion End

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (serverFrm != null)
            {
                serverFrm.Close();
                serverFrm.Dispose();
            }
            if (comm != null)
            {
                comm.Close();
                comm.Dispose();
            }
            if (sndComm != null)
            {
                sndComm.Close();
                sndComm.Dispose();
            }
            this.Dispose(true);//释放资源
            Application.Exit();
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            if (serverFrm != null)
                serverFrm.Hide();
            this.Visible = false;
            this.Hide();
            this.ShowInTaskbar = false;
            this.nIcon.Visible = true;
            //关闭密码器  丽水松阳项目不使用此密码器   20180227
            //if (m_UsbPwsSupport == "1")
            //{
            //    try
            //    {
            //        int nDeviceHandle = (int)phDeviceHandle;
            //        int nReturn = usb.USB_CloseDevice(ref nDeviceHandle);
            //    }
            //    catch (Exception em)
            //    {
            //        MessageBox.Show("密码器关闭失败：" + em.Message);
            //    }
            //}
            if (serverFrm != null)
            {
                serverFrm.Close();
                serverFrm.Dispose();
            }
            if (comm != null)
            {
                comm.Close();
                comm.Dispose();
            }
            if (sndComm != null)
            {
                sndComm.Close();
                sndComm.Dispose();
            }
            this.Dispose();                //释放资源
            Application.Exit();
            Application.ExitThread();
            Environment.Exit(0);
        }

        private void mnuShow_Click(object sender, EventArgs e)
        {
            if (!this.ShowInTaskbar)
            {
                this.Visible = true;
                this.Show();
                this.ShowInTaskbar = true;
                nIcon.Visible = false;
                foreach (Form frm in this.MdiChildren)
                {
                    if (!frm.IsDisposed & frm != null)
                        frm.Show();
                }
            }
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            if (serverFrm != null)
            {
                serverFrm.Close();
                serverFrm.Dispose();
            }
            if (comm != null)
            {
                comm.Close();
                comm.Dispose();
            }
            if (sndComm != null)
            {
                sndComm.Close();
                sndComm.Dispose();
            }
            if (thComm != null)
            {
                thComm.Abort();
                thComm = null;
            }
            this.Dispose(true);
            Application.ExitThread();
        }

        /// <summary>
        /// 文件签名
        /// </summary>
        /// <param name="strPath"></param>
        /// <param name="strEBDID"></param>
        //public void GenerateSignatureFile(string strPath, string strEBDID)
        //{
        //    //if (m_UsbPwsSupport != "1")
        //    //{
        //    //    return;
        //    //}

        //    string sSignFileName = "\\EBDB_" + strEBDID + ".xml";

        //    using (FileStream SignFs = new FileStream(strPath + sSignFileName, FileMode.Open))
        //    {
        //        StreamReader signsr = new StreamReader(SignFs, Encoding.UTF8);
        //        string xmlsign = signsr.ReadToEnd();
        //        signsr.Close();
        //        responseXML signrp = new responseXML();
        //        XmlDocument xmlSignDoc = new XmlDocument();
        //        try
        //        {
        //            //对文件进行签名
        //            int nDeviceHandle = (int)phDeviceHandle;
        //            byte[] pucSignature = Encoding.UTF8.GetBytes(xmlsign);

        //            string strSignture = "";
        //            string strpucCounter = "";
        //            string strpucSignCerSn = "";
        //            string nReturn =scrambler.Platform_CalculateSingature_String(pucSignature, pucSignature.Length, ref strSignture);
        //            //生成签名文件
        //            string xmlSIGNFileName = "\\EBDS_EBDB_" + strEBDID + ".xml";
        //            xmlSignDoc = signrp.SignResponse(strEBDID, strpucCounter, strpucSignCerSn, nReturn);
        //            CommonFunc cm = new CommonFunc();
        //            cm.SaveXmlWithUTF8NotBOM(xmlSignDoc, strPath + xmlSIGNFileName);
        //            if (cm != null)
        //            {
        //                cm = null;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Instance.LogWrite("签名文件错误：" + ex.Message);
        //        }
        //    }
        //}

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受  
            return true;
        }

        //
        public void Signature(string strPath, string strEBDID)
        {

            string sSignFileName = "\\EBDB_" + strEBDID + ".xml";

            using (FileStream SignFs = new FileStream(strPath + sSignFileName, FileMode.Open))
            {
                StreamReader signsr = new StreamReader(SignFs, Encoding.UTF8);
                string xmlsign = signsr.ReadToEnd();
                signsr.Close();
                responseXML signrp = new responseXML();
                XmlDocument xmlSignDoc = new XmlDocument();
                try
                {
                    //对文件进行签名
                 
                    byte[] pucSignature = Encoding.UTF8.GetBytes(xmlsign);

                    string base64Message = Convert.ToBase64String(pucSignature);

                    SignatureStructReply sigresult = CalculateSignature(base64Message);
                    //生成签名文件
                    string xmlSIGNFileName = "\\EBDS_EBDB_" + strEBDID + ".xml";
                    xmlSignDoc = signrp.SignResponse(strEBDID, sigresult);
                    CommonFunc cm = new CommonFunc();
                    cm.SaveXmlWithUTF8NotBOM(xmlSignDoc, strPath + xmlSIGNFileName);
                    if (cm != null)
                    {
                        cm = null;
                    }
                }
                catch (Exception ex)
                {
                    Log.Instance.LogWrite("签名文件错误：" + ex.Message);
                }
            }

           
        
        }


        private SignatureStructReply CalculateSignature(string base64Message)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证


            string url = "https://" + SingletonInfo.GetInstance().signatureIP + ":" + SingletonInfo.GetInstance().signaturePORT + "/api/security/message/signature";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8";
            request.ReadWriteTimeout = 30 * 1000;
            request.Proxy = null;

            SignatureStruct pp = new SignatureStruct();

            pp.base64Message = base64Message;
            string postStr = JsonHelper.SerializeObject(pp);

            byte[] data = Encoding.UTF8.GetBytes(postStr);
            request.ContentLength = data.Length;

            Stream myRequestStream = request.GetRequestStream();

            myRequestStream.Write(data, 0, data.Length);
            myRequestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            SignatureStructReply sigresult = JsonHelper.DeserializeJsonToObject<SignatureStructReply>(content);
            return sigresult;

        }
    }
}
