using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace GRPlatForm
{
    public class Scrambler
    {

        public bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {   // 总是接受  
            return true;
        }

        /// <summary>
        /// 验签
        /// </summary>
        /// <param name="base64Message"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public string Verifysignature(string base64Message, Signature sign)
        {
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(CheckValidationResult);//验证服务器证书回调自动验证

            string url = "https://" + SingletonInfo.GetInstance().signatureIP + ":" + SingletonInfo.GetInstance().signaturePORT + "/api/security/message/verifysignature";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8";
            request.ReadWriteTimeout = 30 * 1000;


            VerifySignatureStruct pp = new VerifySignatureStruct();


          

        
            byte[] IssuerIDlist = System.Text.Encoding.Default.GetBytes(sign.SignatureCert.IssuerID);
            //转成 Base64 形式的 System.String  

            byte[] SNlist = System.Text.Encoding.Default.GetBytes(sign.SignatureCert.CertSN);

            pp.base64CertificateSN =Hexstr2Base64(sign.SignatureCert.CertSN);
            pp.base64IssuerID = Hexstr2Base64(sign.SignatureCert.IssuerID);
            pp.base64Message = base64Message;
            pp.base64Signature = sign.SignatureValue;
            pp.certType = sign.SignatureCert.CertType;
            pp.digestAlgorithm = "1";
            pp.signatureAlgorithm = "1";
            pp.signatureTime = Convert.ToInt64(sign.SignatureTime,16).ToString();
            string postStr = JsonHelper.SerializeObject(pp);

            byte[] data = Encoding.UTF8.GetBytes(postStr);
            request.ContentLength = data.Length;
            request.Proxy = null;
            Stream myRequestStream = request.GetRequestStream();

            myRequestStream.Write(data, 0, data.Length);
            myRequestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string content = myStreamReader.ReadToEnd();
            VerifySignatureStructReply reply = new VerifySignatureStructReply();
            if (content != null)
            {
                reply = JsonHelper.DeserializeJsonToObject<VerifySignatureStructReply>(content);
            }

            myStreamReader.Close();

            return reply.result.ToString();

        }

        private string Hexstr2Base64(string str)
        {
            string pp = str;

            int leng = pp.Length;

            List<byte> ppL = new List<byte>();
            for (int i = 0; i < leng / 2; i++)
            {
                ppL.Add((byte)Convert.ToInt32(pp.Substring(2 * i, 2), 16));
            }

            byte[] qq = ppL.ToArray();
            string dasdas = Convert.ToBase64String(qq);
            return dasdas;
        
        }

    }
}
