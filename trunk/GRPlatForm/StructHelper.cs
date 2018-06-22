using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRPlatForm
{
    public class SignatureStruct
    {
        public string base64Message { get; set; }
    }

    public class VerifySignatureStruct
    {
        public string base64Message { get; set; }
        public string certType { get; set; }
        public string base64IssuerID { get; set; }
        public string base64CertificateSN { get; set; }
        public string   signatureTime { get; set; }
        public string digestAlgorithm { get; set; }
        public string signatureAlgorithm { get; set; }
        public string base64Signature { get; set; }
    }


    public class SignatureStructReply
    {
        public string result { get; set; }
        public string certType { get; set; }
        public string base64IssuerID { get; set; }
        public string base64CertificateSN { get; set; }
        public string  signatureTime { get; set; }
        public string digestAlgorithm { get; set; }
        public string  signatureAlgorithm { get; set; }
        public string base64Signature { get; set; }
    }

    public class VerifySignatureStructReply
    {
        public string  result { get; set; }
    }
}
