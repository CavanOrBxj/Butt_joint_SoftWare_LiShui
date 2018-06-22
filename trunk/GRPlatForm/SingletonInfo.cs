using System.Threading;
using System.Collections.Generic;
using System.Data;

namespace GRPlatForm
{
    public class SingletonInfo
    {
        private static SingletonInfo _singleton;


        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude;
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude;
        public int counter5k;//5000 CreateEvent及命名管道 唯一标识符
        public string signatureIP;//签名验签连接服务器的IP
        public string signaturePORT;//签名验签连接服务器的端口
        public SendFileHttpPost postfile;

        private SingletonInfo()                                                                 
        {
            Longitude = "";
            Latitude = "";
            counter5k = 0;
            signatureIP = "";
            signaturePORT = "";
            postfile = new SendFileHttpPost();
        }
        public static SingletonInfo GetInstance()
        {
            if (_singleton == null)
            {
                Interlocked.CompareExchange(ref _singleton, new SingletonInfo(), null);
            }
            return _singleton;
        }
    }
}