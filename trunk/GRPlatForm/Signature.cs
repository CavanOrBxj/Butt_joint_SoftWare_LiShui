﻿using System;
using System.Xml.Serialization;

namespace GRPlatForm
{
    [Serializable]
    [XmlRoot(ElementName = "Signature")]
    public class Signature
    {
        public string Version;
        public RelatedEBD RelatedEBD;
        public SignatureCert SignatureCert;
        public string  SignatureTime;
        public string DigestAlgorithm;
        public string SignatureAlgorithm;
        public string SignatureValue;
    }

    [Serializable]
    public class SignatureCert
    {
        public string CertType;
        public string IssuerID;
        public string CertSN;
    }

}
