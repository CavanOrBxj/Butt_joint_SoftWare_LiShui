using System;
using System.Collections.Generic;
using System.Xml;

namespace GRPlatForm
{
    public class responseXML
    {
        private IniFiles serverini = new IniFiles(System.Windows.Forms.Application.StartupPath + "\\Config.ini");
        public string SourceAreaCode = "";
        public string SourceType = "";
        public string SourceName = "";
        public string SourceID = "";
        public string sHBRONO = "0000000000000";//"010332132300000001";//实体编号

        //通用反馈的xml头
        public int xmlHead(XmlDocument xmlDoc, XmlElement xmlElem, EBD ebdsr, string EBDstyle, string strebdid)
        {
            #region 标准头部
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = EBDstyle;
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBEID");
            xmlSRCAreaCode.InnerText = sHBRONO;// "010334152300000002";// ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End
            return 0;
        }

        /// <summary>
        /// －－接收回馈数据包-通用反馈
        /// </summary>
        /// <returns></returns>
        public XmlDocument EBDResponse(EBD ebdsr, string EBDstyle, string strEBDID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strEBDID);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID;
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            xmlResultCode.InnerText = "1";
            xmlEBDResponse.AppendChild(xmlResultCode);

            XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            xmlResultDesc.InnerText = "执行成功";
            xmlEBDResponse.AppendChild(xmlResultDesc);

            return xmlDoc;
        }

        public XmlDocument VerifySignatureError(EBD ebdsr, string EBDstyle, string strEBDID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strEBDID);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID;
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            xmlResultCode.InnerText = "4";
            xmlEBDResponse.AppendChild(xmlResultCode);

            XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            xmlResultDesc.InnerText = "签名验证失败";
            xmlEBDResponse.AppendChild(xmlResultDesc);

            return xmlDoc;
        }

        public XmlDocument EBDResponseyunweierror(EBD ebdsr, string EBDstyle, string strEBDID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strEBDID);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID;
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            xmlResultCode.InnerText = "3";
            xmlEBDResponse.AppendChild(xmlResultCode);

            XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            xmlResultDesc.InnerText = "该接口暂不支持";
            xmlEBDResponse.AppendChild(xmlResultDesc);

            return xmlDoc;
        }

        public XmlDocument EBDResponseerror(EBD ebdsr, string EBDstyle, string strEBDID)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strEBDID);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID;
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("EBDResponse");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
            xmlResultCode.InnerText = "5";
            xmlEBDResponse.AppendChild(xmlResultCode);

            XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
            xmlResultDesc.InnerText = "查找不到该EBMID";
            xmlEBDResponse.AppendChild(xmlResultDesc);

            return xmlDoc;
        }

        /// <summary>
        /// 河北－－应急消息播发状态反馈
        /// </summary>
        /// <returns>返回XML文档</returns>
        //public XmlDocument EBMStateResponse(EBD ebdsr, string EBDstyle, string strebdid)
        //{
        //    XmlDocument xmlDoc = new XmlDocument();
        //    //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
        //    xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
        //    XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
        //    xmlDoc.AppendChild(xmlElem);
        //    xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle, strebdid);

        //    XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
        //    xmlElem.AppendChild(xmlRelatedEBD);

        //    XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
        //    xmlRelatedEBD.AppendChild(xmlReEBDID);
        //    XmlElement xmlEBMStateResponse = xmlDoc.CreateElement("EBMStateResponse");
        //    xmlElem.AppendChild(xmlEBMStateResponse);

        //    //反馈数据的时间
        //    XmlElement xmlRptTime = xmlDoc.CreateElement("RptTime");
        //    xmlRptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //    xmlEBMStateResponse.AppendChild(xmlRptTime);
        //    //应急消息内容信息
        //    XmlElement xmlEBM = xmlDoc.CreateElement("EBM");
        //    xmlEBMStateResponse.AppendChild(xmlEBM);
        //    {
        //        //发布该应急广播消息的应急广播平台ID
        //        XmlElement xmlEBEID = xmlDoc.CreateElement("EBEID");
        //        xmlEBEID.InnerText = ebdsr.SRC.EBRID;
        //        xmlEBM.AppendChild(xmlEBEID);

        //        //应急消息ID通过应急广播平台ID和应急广播消息ID区别其他的应急广播消息
        //        XmlElement xmlEBMID = xmlDoc.CreateElement("EBMID");
        //        xmlEBMID.InnerText = ebdsr.EBM.EBMID;
        //        xmlEBM.AppendChild(xmlEBMID);
        //    }

        //    //播发状态标志，0：播发失败 1：正在播发 2：播发完成，该字段表明当前的应急广播消息播发是否已完成
        //    XmlElement xmlBrdStateCode = xmlDoc.CreateElement("BrdStateCode");
        //    xmlBrdStateCode.InnerText = "2";
        //    xmlEBMStateResponse.AppendChild(xmlBrdStateCode);

        //    //播发状态描述
        //    XmlElement xmlBrdStateDesc = xmlDoc.CreateElement("BrdStateDesc");
        //    xmlEBMStateResponse.AppendChild(xmlBrdStateDesc);

        //    //实际覆盖行政区域,该数据元素为可选
        //    XmlElement xmlCoverage = xmlDoc.CreateElement("Coverage");
        //    xmlEBMStateResponse.AppendChild(xmlCoverage);
        //    {
        //        //实际覆盖区域百分比
        //        XmlElement xmlCoveragePercent = xmlDoc.CreateElement("CoveragePercent");
        //        xmlCoveragePercent.InnerText = "90%";
        //        xmlCoverage.AppendChild(xmlCoveragePercent);

        //        //区域代码，格式为：（区域编码1，区域编码2）
        //        XmlElement xmlAreaCode = xmlDoc.CreateElement("AreaCode");
        //        if (ebdsr.EBM.MsgContent.AreaCode != null)
        //        {
        //            xmlAreaCode.InnerText = ebdsr.EBM.MsgContent.AreaCode;
        //        }
        //        xmlCoverage.AppendChild(xmlAreaCode);
        //    }

        //    //播发数据详情，可选
        //    XmlElement xmlResBrdInfo = xmlDoc.CreateElement("ResBrdInfo");
        //    xmlEBMStateResponse.AppendChild(xmlResBrdInfo);
        //    {
        //        //播出情况，可为多个，元素关系参见资源信息数据上报
        //        XmlElement xmlResBrdItem = xmlDoc.CreateElement("ResBrdItem");
        //        xmlResBrdInfo.AppendChild(xmlResBrdItem);
        //        {
        //            //反馈时间
        //            XmlElement xmlARptTime = xmlDoc.CreateElement("RptTime");
        //            xmlARptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //            xmlResBrdItem.AppendChild(xmlARptTime);

        //            XmlElement xmlEBEST = xmlDoc.CreateElement("EBEST");
        //            xmlEBEST.InnerText = "";
        //            xmlResBrdItem.AppendChild(xmlEBEST);
        //            {
        //                XmlElement xmlEBESTEBEID = xmlDoc.CreateElement("EBEID");
        //                xmlEBESTEBEID.InnerText = "";
        //                xmlEBEST.AppendChild(xmlEBESTEBEID);
        //            }

        //            XmlElement xmlEBEAS = xmlDoc.CreateElement("EBEAS");
        //            xmlEBEAS.InnerText = "";
        //            xmlResBrdItem.AppendChild(xmlEBEAS);
        //            {
        //                XmlElement xmlEBEASEBEID = xmlDoc.CreateElement("EBEID");
        //                xmlEBEASEBEID.InnerText = "";
        //                xmlEBEAS.AppendChild(xmlEBEASEBEID);
        //            }

        //            XmlElement xmlEBEBS = xmlDoc.CreateElement("EBEBS");
        //            xmlEBEAS.InnerText = "";
        //            xmlResBrdItem.AppendChild(xmlEBEBS);
        //            {
        //                XmlElement xmlEBEBSEBEID = xmlDoc.CreateElement("EBEID");
        //                xmlEBEBSEBEID.InnerText = "";
        //                xmlEBEBS.AppendChild(xmlEBEBSEBEID);

        //                XmlElement xmlStartTime = xmlDoc.CreateElement("StartTime");
        //                xmlStartTime.InnerText = "";
        //                xmlEBEBS.AppendChild(xmlStartTime);

        //                XmlElement xmlEndTime = xmlDoc.CreateElement("EndTime");
        //                xmlEndTime.InnerText = "";
        //                xmlEBEBS.AppendChild(xmlEndTime);

        //                XmlElement xmlFileURL = xmlDoc.CreateElement("FileURL");
        //                xmlEBEBS.AppendChild(xmlFileURL);

        //                XmlElement xmlResultCode = xmlDoc.CreateElement("ResultCode");
        //                xmlResultCode.InnerText = "2";
        //                xmlEBEBS.AppendChild(xmlResultCode);

        //                XmlElement xmlResultDesc = xmlDoc.CreateElement("ResultDesc");
        //                xmlEBEBS.AppendChild(xmlResultDesc);
        //            }
        //        }
        //    }
        //    return xmlDoc;
        //}

        public XmlDocument EBMStateRequestResponse(EBD ebdsr, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBMStateResponse";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");

            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;//ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);


            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End

            #region EBMStateResponse
            XmlElement xmlEBMStateResponse = xmlDoc.CreateElement("EBMStateResponse");
            xmlElem.AppendChild(xmlEBMStateResponse);

            XmlElement xmlEBM = xmlDoc.CreateElement("EBM");
            xmlEBMStateResponse.AppendChild(xmlEBM);

            XmlElement xmlEBMID = xmlDoc.CreateElement("EBMID");
            if (ebdsr.EBMStateRequest != null)
                xmlEBMID.InnerText = ebdsr.EBMStateRequest.EBM.EBMID;//从100000000000开始编号
            else
                xmlEBMID.InnerText = ebdsr.EBM.EBMID;
            xmlEBM.AppendChild(xmlEBMID);

            XmlElement xmlRPTTime = xmlDoc.CreateElement("RptTime");
            xmlRPTTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlEBMStateResponse.AppendChild(xmlRPTTime);

            XmlElement xmlBRDState = xmlDoc.CreateElement("BrdStateCode");
            xmlBRDState.InnerText = "2";
            xmlEBMStateResponse.AppendChild(xmlBRDState);

            XmlElement BrdStateDesc = xmlDoc.CreateElement("BrdStateDesc");
            BrdStateDesc.InnerText = "完成";
            xmlEBMStateResponse.AppendChild(BrdStateDesc);

            #region Coverage

            // if (lEBMState.Count > 0)
            {
                XmlElement xmlCoverage = xmlDoc.CreateElement("Coverage");
                xmlEBMStateResponse.AppendChild(xmlCoverage);

                XmlElement xmlCoveragePercent = xmlDoc.CreateElement("CoveragePercent");
                xmlCoveragePercent.InnerText = "100";
                xmlCoverage.AppendChild(xmlCoveragePercent);

                // string[] AreaValue = lEBMState[0].BRDCoverageArea.Split('|');
                XmlElement xmlAreaCode = xmlDoc.CreateElement("AreaCode");
                if (ebdsr.EBM != null)
                    if (ebdsr.EBM.MsgContent != null)
                    {
                        xmlAreaCode.InnerText = ebdsr.EBM.MsgContent.AreaCode;//"003609810101AA"
                    }
                xmlCoverage.AppendChild(xmlAreaCode);
            }
            #endregion End

            #region Broadcast

            #endregion Broadcast
            #endregion End

            return xmlDoc;
        }

        /// <summary>
        /// 心跳包 
        /// </summary>
        /// <returns></returns>
        public XmlDocument HeartBeatResponse()
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);

            #region 标准头部

            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = "01" + sHBRONO + "0000000000000000";
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "ConnectionCheck";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);
            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;// "010334152300000002";// ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            XmlElement xmlDEST = xmlDoc.CreateElement("DEST");
            xmlElem.AppendChild(xmlDEST);

            XmlElement eebtEE = xmlDoc.CreateElement("EBRID");
            eebtEE.InnerText = "010233110000000001";// "010334152300000002";// ebdsr.SRC.EBEID;   尼玛   干嘛要写死？？20180104
            xmlDEST.AppendChild(eebtEE);

            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);
            #endregion End

            XmlElement xmlEBDResponse = xmlDoc.CreateElement("ConnectionCheck");
            xmlElem.AppendChild(xmlEBDResponse);

            XmlElement xmlResultCode = xmlDoc.CreateElement("RptTime");
            xmlResultCode.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlEBDResponse.AppendChild(xmlResultCode);

            return xmlDoc;
        }

        /// <summary>
        /// 实时流
        /// </summary>
        /// <returns></returns>
        public XmlDocument EBMStreamResponse(string strEBMID, string strUrl)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //加入XML的声明段落,Save方法不再xml上写出独立属性GB2312
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);

            //xmlHead(xmlDoc, xmlElem, ebdsr, EBDstyle);

            #region 标准头部

            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = "01" + sHBRONO + "0000000000000000";
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBMStreamPortRequest";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End

            XmlElement xmlDevice = xmlDoc.CreateElement("EBMStream");
            xmlElem.AppendChild(xmlDevice);

            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBM");
            xmlDevice.AppendChild(xmlRelatedEBD);
            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBMID");
            xmlReEBDID.InnerText = strEBMID;//与EBDID一致就用这个写
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlParams = xmlDoc.CreateElement("Params");
            xmlDevice.AppendChild(xmlParams);
            XmlElement xmlUrl = xmlDoc.CreateElement("Url");
            xmlUrl.InnerText = strUrl;//与EBDID一致就用这个写
            xmlParams.AppendChild(xmlUrl);

            return xmlDoc;
        }

        /// <summary>
        /// 平台播发记录数据数据
        /// </summary>
        /// <param name="ebdsr"></param>
        /// <returns></returns>
        public XmlDocument PlatformBRDResponse(EBD ebdsr, List<PlatformBRD> lP)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = ebdsr.EBDID;//
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBDResponse";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = ebdsr.SRC.EBRID;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            XmlElement xmlDEST = xmlDoc.CreateElement("DEST");
            xmlElem.AppendChild(xmlDEST);
            XmlElement xmlDESTEBEID = xmlDoc.CreateElement("EBEID");
            //try
            //{
            //    xmlDESTEBEID.InnerText = ebdsr.DEST.EBEID;
            //}
            //catch
            //{
            //}
            xmlSRC.AppendChild(xmlDESTEBEID);
            //XmlElement xmlSourceID = xmlDoc.CreateElement("EBEID");
            //xmlSourceID.InnerText = SourceID;//
            //xmlSRC.AppendChild(xmlSourceID);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End
            //RelatedEBD
            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);
            XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            xmlReEBDID.InnerText = ebdsr.EBDID.ToString();//与EBDID一致就用这个写
            xmlRelatedEBD.AppendChild(xmlReEBDID);

            #region PlatformBRDReport

            //XmlElement xmlPlatformBRDReport = xmlDoc.CreateElement("PlatformBRDReport");
            //xmlElem.AppendChild(xmlPlatformBRDReport);

            //XmlElement xmlRPTStartTime = xmlDoc.CreateElement("RPTStartTime");//RPTStartTime
            //xmlRPTStartTime.InnerText = ebdsr.DataRequest.StartTime;// ebdsr.DataRequest.StartTime;//
            //xmlPlatformBRDReport.AppendChild(xmlRPTStartTime);
            //XmlElement xmlRPTEndTime = xmlDoc.CreateElement("RPTEndTime");//RPTEndTime
            //xmlRPTEndTime.InnerText = ebdsr.DataRequest.EndTime; //ebdsr.DataRequest.EndTime;//DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            //xmlPlatformBRDReport.AppendChild(xmlRPTEndTime);

            //#region PlatformBRD
            //if (lP.Count > 0)
            //{
            //    for (int i = 0; i < lP.Count; i++)
            //    {
            //        XmlElement xmlPlatformBRD = xmlDoc.CreateElement("PlatformBRD");//PlatformBRD
            //        xmlPlatformBRDReport.AppendChild(xmlPlatformBRD);

            //        XmlElement xmlPlatformBRDID = xmlDoc.CreateElement("PlatformBRDID");//PlatformBRDID
            //        xmlPlatformBRDID.InnerText = lP[i].PlatformBRDID;//数据库ID字段值
            //        xmlPlatformBRD.AppendChild(xmlPlatformBRDID);
            //        XmlElement xmlBRDPSourceType = xmlDoc.CreateElement("SourceType");//SourceType
            //        xmlBRDPSourceType.InnerText =lP[i].SourceType;
            //        xmlPlatformBRD.AppendChild(xmlBRDPSourceType);
            //        XmlElement xmlBRDPSourceID = xmlDoc.CreateElement("SourceID");//SourceType
            //        xmlBRDPSourceID.InnerText = lP[i].SourceID;
            //        xmlPlatformBRD.AppendChild(xmlBRDPSourceID);
            //        XmlElement xmlMsgID = xmlDoc.CreateElement("MsgID");//
            //        xmlMsgID.InnerText = lP[i].MsgID;
            //        xmlPlatformBRD.AppendChild(xmlMsgID);
            //        XmlElement xmlSender = xmlDoc.CreateElement("Sender");//
            //        xmlSender.InnerText = lP[i].Sender;//播发部门：气象局，应急办，公安局
            //        xmlPlatformBRD.AppendChild(xmlSender);
            //        XmlElement xmlUnitId = xmlDoc.CreateElement("UnitId");//
            //        xmlUnitId.InnerText = lP[i].UnitId;//播发部门ID
            //        xmlPlatformBRD.AppendChild(xmlUnitId);
            //        XmlElement xmlUnitName = xmlDoc.CreateElement("UnitName");//
            //        xmlUnitName.InnerText = lP[i].UnitName;//播发部门名称
            //        xmlPlatformBRD.AppendChild(xmlUnitName);
            //        XmlElement xmlPersonID = xmlDoc.CreateElement("PersonID");//
            //        xmlPersonID.InnerText = lP[i].PersonID;//发布人员ID
            //        xmlPlatformBRD.AppendChild(xmlPersonID);
            //        XmlElement xmlPersonName = xmlDoc.CreateElement("PersonName");//
            //        xmlPersonName.InnerText = lP[i].PersonName;//播发人员姓名
            //        xmlPlatformBRD.AppendChild(xmlPersonName);
            //        XmlElement xmlBRDStartTime = xmlDoc.CreateElement("BRDStartTime");//
            //        xmlBRDStartTime.InnerText =lP[i].BRDStartTime ;//播发起始时间 DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            //        xmlPlatformBRD.AppendChild(xmlBRDStartTime);
            //        XmlElement xmlBRDEndTime = xmlDoc.CreateElement("BRDEndTime");//
            //        xmlBRDEndTime.InnerText =lP[i].BRDEndTime ;//DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            //        xmlPlatformBRD.AppendChild(xmlBRDEndTime);
            //        XmlElement xmlAudioFileURL = xmlDoc.CreateElement("AudioFileURL");//
            //        xmlAudioFileURL.InnerText = lP[i].AudioFileURL;//
            //        xmlPlatformBRD.AppendChild(xmlAudioFileURL);
            //    }
            //}
            #endregion End

            //#endregion End
            return xmlDoc;
        }

     

        /// <summary>
        /// 设备基础数据
        /// </summary>
        /// <param name="ebdsr"></param>
        /// <returns></returns>
        public XmlDocument DeviceInfoResponse(EBD ebdsr, List<Device> lDev, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;//
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBRDTInfo";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);


            //XmlElement xmlDEST = xmlDoc.CreateElement("DEST");
            //xmlElem.AppendChild(xmlDEST);

            //XmlElement xmlSRCAreaEBRID = xmlDoc.CreateElement("EBRID");
            //xmlSRCAreaEBRID.InnerText = "010232000000000001";
            //xmlDEST.AppendChild(xmlSRCAreaEBRID);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");

            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);

            XmlElement RelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(RelatedEBD);

            #endregion End
            //RelatedEBD
            //if (ebdsr != null)
            //{
            //    XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            //    xmlElem.AppendChild(xmlRelatedEBD);
            //    XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            //    xmlReEBDID.InnerText = ebdsr.EBDID;//与EBDID一致就用这个写
            //    xmlRelatedEBD.AppendChild(xmlReEBDID);
            //}
            #region DeviceInfoReport
            XmlElement xmlDeviceInfoReport = xmlDoc.CreateElement("EBRDTInfo");
            xmlElem.AppendChild(xmlDeviceInfoReport);

            XmlElement xmlParams = xmlDoc.CreateElement("Params");
            xmlDeviceInfoReport.AppendChild(xmlParams);

            XmlElement xmlRPTStartTime = xmlDoc.CreateElement("RptStartTime");//RPTStartTime
            xmlRPTStartTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");// ebdsr.DataRequest.StartTime;
            xmlParams.AppendChild(xmlRPTStartTime);

            XmlElement xmlRPTEndTime = xmlDoc.CreateElement("RptEndTime");//RPTEndTime
            xmlRPTEndTime.InnerText = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd HH:mm:ss"); //ebdsr.DataRequest.EndTime;
            xmlParams.AppendChild(xmlRPTEndTime);

            XmlElement xmlRptType = xmlDoc.CreateElement("RptType");//RPTEndTime
            xmlRptType.InnerText = "Full"; //ebdsr.DataRequest.EndTime;
            xmlParams.AppendChild(xmlRptType);

            string DeviEBRID = sHBRONO.Substring(4, sHBRONO.Length - 6);
            Console.WriteLine(DeviEBRID);

            #region Device
            if (lDev.Count > 0)
            {
                for (int l = 0; l < lDev.Count; l++)
                {
                    XmlElement xmlDevice = xmlDoc.CreateElement("EBRDT");//Term
                    xmlDeviceInfoReport.AppendChild(xmlDevice);



                    XmlElement xmlRptTime = xmlDoc.CreateElement("RptTime");
                    xmlRptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    xmlDevice.AppendChild(xmlRptTime);

                    XmlElement xmlRptType2 = xmlDoc.CreateElement("RptType");
                    xmlRptType2.InnerText = "Sync";
                    xmlDevice.AppendChild(xmlRptType2);


                    //XmlElement xmlRelatedEEBRBS = xmlDoc.CreateElement("EBRPS");
                    //xmlDeviceInfoReport.AppendChild(xmlRelatedEEBRBS);

                    //XmlElement xmlEBRID = xmlDoc.CreateElement("RptTime");
                    //xmlEBRID.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    //xmlRelatedEEBRBS.AppendChild(xmlEBRID);

                    XmlElement xmlRelatedEBRPS = xmlDoc.CreateElement("RelatedEBRPS");
                    xmlDevice.AppendChild(xmlRelatedEBRPS);

                    XmlElement xmlERelatedEBRPSD = xmlDoc.CreateElement("EBRID");
                    xmlERelatedEBRPSD.InnerText = sHBRONO;
                    xmlRelatedEBRPS.AppendChild(xmlERelatedEBRPSD);


                    XmlElement xmlDeviceID = xmlDoc.CreateElement("EBRID");
                    xmlDeviceID.InnerText = "0601" + lDev[l].AreaCode.Substring(0,12) + lDev[l].DeviceID; //"0699" + "321323000000" + lDev[l].DeviceID;
                    xmlDevice.AppendChild(xmlDeviceID);


                    XmlElement xmlDeviceName = xmlDoc.CreateElement("EBRName");
                    xmlDeviceName.InnerText = (l+1).ToString() + "号";
                    xmlDevice.AppendChild(xmlDeviceName);

                    XmlElement xmlLongitude = xmlDoc.CreateElement("Longitude");
                    xmlLongitude.InnerText = SingletonInfo.GetInstance().Longitude;
                    xmlDevice.AppendChild(xmlLongitude);

                    XmlElement xmlLatitude = xmlDoc.CreateElement("Latitude");
                    xmlLatitude.InnerText = SingletonInfo.GetInstance().Latitude;
                    xmlDevice.AppendChild(xmlLatitude);

                    XmlElement xmlLatitudParamse = xmlDoc.CreateElement("Params");
                    xmlLatitudParamse.InnerText = "";
                    xmlDevice.AppendChild(xmlLatitudParamse);




                }
            }
            //XmlElement xmlRelatedEEBRBS = xmlDoc.CreateElement("EBRPS");
            //xmlDeviceInfoReport.AppendChild(xmlRelatedEEBRBS);

            //XmlElement xmlEBRID = xmlDoc.CreateElement("RptTime");
            //xmlEBRID.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //xmlRelatedEEBRBS.AppendChild(xmlEBRID);

            //XmlElement xmlRelatedEBRPS = xmlDoc.CreateElement("RelatedEBRPS");
            //xmlRelatedEEBRBS.AppendChild(xmlRelatedEBRPS);

            //XmlElement xmlERelatedEBRPSD = xmlDoc.CreateElement("EBRID");
            //xmlERelatedEBRPSD.InnerText = sHBRONO;
            //xmlRelatedEBRPS.AppendChild(xmlERelatedEBRPSD);
            #endregion End
            #endregion End
            return xmlDoc;
        }

        public XmlDocument DeviceInfoResponse(List<Device> lDev, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);

            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;//
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBRDTInfo";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");

            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End
            //RelatedEBD
            //XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            //xmlElem.AppendChild(xmlRelatedEBD);
            //XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            //xmlReEBDID.InnerText = strebdid;//与EBDID一致就用这个写
            //xmlRelatedEBD.AppendChild(xmlReEBDID);
            #region DeviceInfoReport
            XmlElement xmlDeviceInfoReport = xmlDoc.CreateElement("EBRDTInfo");
            xmlElem.AppendChild(xmlDeviceInfoReport);

            XmlElement xmlParams = xmlDoc.CreateElement("Params");
            xmlElem.AppendChild(xmlParams);

            XmlElement xmlRPTStartTime = xmlDoc.CreateElement("RPTStartTime");//RPTStartTime
            xmlRPTStartTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");// ebdsr.DataRequest.StartTime;
            xmlParams.AppendChild(xmlRPTStartTime);

            XmlElement xmlRPTEndTime = xmlDoc.CreateElement("RPTEndTime");//RPTEndTime
            xmlRPTEndTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //ebdsr.DataRequest.EndTime;
            xmlParams.AppendChild(xmlRPTEndTime);

            XmlElement xmlRptType = xmlDoc.CreateElement("RptType");//RPTEndTime
            xmlRptType.InnerText = ""; //ebdsr.DataRequest.EndTime;
            xmlParams.AppendChild(xmlRptType);

          //  string DeviEBRID = sHBRONO.Substring(4, sHBRONO.Length - 6);
          //  Console.WriteLine(DeviEBRID);

            #region Device
            if (lDev.Count > 0)
            {
                for (int l = 0; l < lDev.Count; l++)
                {
                    XmlElement xmlDevice = xmlDoc.CreateElement("EBRDT");//Term
                    xmlDeviceInfoReport.AppendChild(xmlDevice);

                    XmlElement xmlRptTime = xmlDoc.CreateElement("RptTime");
                    xmlRptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    xmlDevice.AppendChild(xmlRptTime);

                    XmlElement xmlRptType2 = xmlDoc.CreateElement("RptType");
                    xmlRptType2.InnerText = "Sync";
                    xmlDevice.AppendChild(xmlRptType2);

                    XmlElement xmlRelatedEBRPS = xmlDoc.CreateElement("RelatedEBRPS");
                    xmlDevice.AppendChild(xmlRelatedEBRPS);

                    XmlElement xmlEBRID = xmlDoc.CreateElement("EBRID");
                    xmlEBRID.InnerText = sHBRONO;
                    xmlRelatedEBRPS.AppendChild(xmlEBRID);

                    XmlElement xmlDeviceID = xmlDoc.CreateElement("EBRID");

                  
                    // 区域码唯一的前提下
                    xmlDeviceID.InnerText = "0601" + lDev[l].AreaCode.Substring(0,12) + lDev[l].DeviceID;
                  
                    xmlDevice.AppendChild(xmlDeviceID);

                    XmlElement xmlDeviceName = xmlDoc.CreateElement("EBRName");
                 //   xmlDeviceName.InnerText = l + "号";注释于20180109
                    xmlDeviceName.InnerText = lDev[l].DeviceName + "号";
                    xmlDevice.AppendChild(xmlDeviceName);

                    XmlElement xmlLongitude = xmlDoc.CreateElement("Longitude");
                    xmlLongitude.InnerText = lDev[l].Longitude;
                    xmlDevice.AppendChild(xmlLongitude);

                    XmlElement xmlLatitude = xmlDoc.CreateElement("Latitude");
                    xmlLatitude.InnerText = lDev[l].Latitude;
                    xmlDevice.AppendChild(xmlLatitude);

                    XmlElement xmlParams2 = xmlDoc.CreateElement("Params");
                    xmlLatitude.InnerText = lDev[l].Latitude;
                    xmlDevice.AppendChild(xmlParams2);
                }
            }
            #endregion End
            #endregion End
            return xmlDoc;
        }


       
        /// <summary>
        /// 平台信息
        /// </summary>
        /// <param name="ebdsr"></param>
        /// <returns></returns>
        public XmlDocument platformInfoResponse(EBD ebdsr, List<Device> lDev, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();

            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);

            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;//
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBRPSInfo";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");

            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            if (ebdsr != null)
            {
                //RelatedEBD
                XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
                xmlElem.AppendChild(xmlRelatedEBD);
                XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
                xmlReEBDID.InnerText = ebdsr.EBDID;//与EBDID一致就用这个写
                xmlRelatedEBD.AppendChild(xmlReEBDID);
            }

            XmlElement xmlDeviceInfoReport = xmlDoc.CreateElement("EBRPSInfo");
            xmlElem.AppendChild(xmlDeviceInfoReport);

            XmlElement xmlParams = xmlDoc.CreateElement("Params");
            xmlDeviceInfoReport.AppendChild(xmlParams);

            XmlElement xmlRPTStartTime = xmlDoc.CreateElement("RptStartTime");//RPTStartTime
            xmlRPTStartTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");// ebdsr.DataRequest.StartTime;
            xmlParams.AppendChild(xmlRPTStartTime);

            XmlElement xmlRPTEndTime = xmlDoc.CreateElement("RptEndTime");//RPTEndTime
            xmlRPTEndTime.InnerText = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd HH:mm:ss"); //ebdsr.DataRequest.EndTime;
            xmlParams.AppendChild(xmlRPTEndTime);

            XmlElement xmlRptType = xmlDoc.CreateElement("RptType");//RPTEndTime
            xmlRptType.InnerText = "Full"; //ebdsr.DataRequest.EndTime;
            xmlParams.AppendChild(xmlRptType);

            XmlElement xmlDevice = xmlDoc.CreateElement("EBRPS");//Term
            xmlDeviceInfoReport.AppendChild(xmlDevice);

            XmlElement xmlRptTime = xmlDoc.CreateElement("RptTime");
            xmlRptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlDevice.AppendChild(xmlRptTime);

            XmlElement xmlRptType2 = xmlDoc.CreateElement("RptType");
            xmlRptType2.InnerText = "Sync";
            xmlDevice.AppendChild(xmlRptType2);

            XmlElement xmlRelatedEBRPS = xmlDoc.CreateElement("RelatedEBRPS");
            xmlDevice.AppendChild(xmlRelatedEBRPS);

            XmlElement xmlEBRID = xmlDoc.CreateElement("EBRID");
            xmlEBRID.InnerText = sHBRONO;
            xmlRelatedEBRPS.AppendChild(xmlEBRID);

            XmlElement xmlDeviceID = xmlDoc.CreateElement("EBRID");
            xmlDeviceID.InnerText = sHBRONO;
            xmlDevice.AppendChild(xmlDeviceID);

            XmlElement xmlDeviceName = xmlDoc.CreateElement("EBRName");
            xmlDeviceName.InnerText = serverini.ReadValue("PLATFORMINFO", "EBRName");//"丹阳县应急广播平台";
            xmlDevice.AppendChild(xmlDeviceName);

            XmlElement Address = xmlDoc.CreateElement("Address");
            Address.InnerText = serverini.ReadValue("PLATFORMINFO", "Address"); //"丹阳县广电";
            xmlDevice.AppendChild(Address);

            XmlElement Contact = xmlDoc.CreateElement("Contact");
            Contact.InnerText = serverini.ReadValue("PLATFORMINFO", "Contact"); //"刘先生";
            xmlDevice.AppendChild(Contact);

            XmlElement PhoneNumber = xmlDoc.CreateElement("PhoneNumber");
            PhoneNumber.InnerText = serverini.ReadValue("PLATFORMINFO", "PhoneNumber"); //"12345678901";
            xmlDevice.AppendChild(PhoneNumber);

            XmlElement Longitude = xmlDoc.CreateElement("Longitude");
            Longitude.InnerText = SingletonInfo.GetInstance().Longitude;
            xmlDevice.AppendChild(Longitude);

            XmlElement Latitude = xmlDoc.CreateElement("Latitude");
            Latitude.InnerText = SingletonInfo.GetInstance().Latitude;
            xmlDevice.AppendChild(Latitude);

            XmlElement URL = xmlDoc.CreateElement("URL");
            URL.InnerText = "htttp://192.168.34.98:7000";
            xmlDevice.AppendChild(URL);

            return xmlDoc;
        }

        public XmlDocument platformInfoResponse(string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();

            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;//strebdid;//自己的ID前面一长串
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBRPSInfo";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;// sHBRONO;单独的ID
            xmlSRC.AppendChild(xmlSRCAreaCode);


            XmlElement xmlDEST = xmlDoc.CreateElement("DEST");
            xmlElem.AppendChild(xmlDEST);

            XmlElement xmlDESTEBRID = xmlDoc.CreateElement("EBRID");
            xmlDESTEBRID.InnerText = "010232000000000001";// sHBRONO;单独的ID
            xmlDEST.AppendChild(xmlDESTEBRID);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");

            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);

            //RelatedEBD
            //XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            //xmlElem.AppendChild(xmlRelatedEBD);
            //XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            //xmlReEBDID.InnerText = strebdid;//与EBDID一致就用这个写
            //xmlRelatedEBD.AppendChild(xmlReEBDID);

            XmlElement xmlDeviceInfoReport = xmlDoc.CreateElement("EBRPSInfo");
            xmlElem.AppendChild(xmlDeviceInfoReport);

            XmlElement xmlParams = xmlDoc.CreateElement("Params");
            xmlElem.AppendChild(xmlParams);

            XmlElement xmlRPTStartTime = xmlDoc.CreateElement("RPTStartTime");//RPTStartTime
            xmlRPTStartTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");// ebdsr.DataRequest.StartTime;
            xmlParams.AppendChild(xmlRPTStartTime);

            XmlElement xmlRPTEndTime = xmlDoc.CreateElement("RPTEndTime");//RPTEndTime
            xmlRPTEndTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //ebdsr.DataRequest.EndTime;
            xmlParams.AppendChild(xmlRPTEndTime);

            XmlElement xmlRptType = xmlDoc.CreateElement("RptType");//RPTEndTime
            xmlRptType.InnerText = "Full"; //ebdsr.DataRequest.EndTime;
            xmlParams.AppendChild(xmlRptType);

            XmlElement xmlDevice = xmlDoc.CreateElement("EBRPS");//Term
            xmlDeviceInfoReport.AppendChild(xmlDevice);

            XmlElement xmlRptTime = xmlDoc.CreateElement("RptTime");
            xmlRptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlDevice.AppendChild(xmlRptTime);

            XmlElement xmlRptType2 = xmlDoc.CreateElement("RptType");
            xmlRptType2.InnerText = "Sync";
            xmlDevice.AppendChild(xmlRptType2);

            XmlElement xmlRelatedEBRPS = xmlDoc.CreateElement("RelatedEBRPS");
            xmlDevice.AppendChild(xmlRelatedEBRPS);

            XmlElement xmlEBRID = xmlDoc.CreateElement("EBRID");
            xmlEBRID.InnerText = sHBRONO;
            xmlRelatedEBRPS.AppendChild(xmlEBRID);

            XmlElement xmlDeviceID = xmlDoc.CreateElement("EBRID");
            xmlDeviceID.InnerText = sHBRONO;
            xmlDevice.AppendChild(xmlDeviceID);

            XmlElement xmlDeviceName = xmlDoc.CreateElement("EBRName");
            xmlDeviceName.InnerText = serverini.ReadValue("PLATFORMINFO", "EBRName");//"丹阳县应急广播平台";
            xmlDevice.AppendChild(xmlDeviceName);

            XmlElement Address = xmlDoc.CreateElement("Address");
            Address.InnerText = serverini.ReadValue("PLATFORMINFO", "Address");//"丹阳县广电";
            xmlDevice.AppendChild(Address);

            XmlElement Contact = xmlDoc.CreateElement("Contact");
            Contact.InnerText = serverini.ReadValue("PLATFORMINFO", "Contact");//"老铁";
            xmlDevice.AppendChild(Contact);

            XmlElement PhoneNumber = xmlDoc.CreateElement("PhoneNumber");
            PhoneNumber.InnerText = serverini.ReadValue("PLATFORMINFO", "PhoneNumber");//"12345678901";
            xmlDevice.AppendChild(PhoneNumber);

            XmlElement Longitude = xmlDoc.CreateElement("Longitude");
            Longitude.InnerText = SingletonInfo.GetInstance().Longitude;
            xmlDevice.AppendChild(Longitude);

            XmlElement Latitude = xmlDoc.CreateElement("Latitude");
            Latitude.InnerText = SingletonInfo.GetInstance().Latitude;
            xmlDevice.AppendChild(Latitude);

            XmlElement URL = xmlDoc.CreateElement("URL");
            URL.InnerText = "192.168.34.98";
            xmlDevice.AppendChild(URL);

            return xmlDoc;
        }

        /// <summary>
        /// 平台状态信息
        /// </summary>
        /// <param name="ebdsr"></param>
        /// <returns></returns>
        public XmlDocument platformstateInfoResponse(EBD ebdsr, List<Device> lDev, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();

            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;//
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBRPSState";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");

            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);

            if (ebdsr != null)
            {
                //RelatedEBD
                XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
                xmlElem.AppendChild(xmlRelatedEBD);
                XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
                xmlReEBDID.InnerText = ebdsr.EBDID;//与EBDID一致就用这个写
                xmlRelatedEBD.AppendChild(xmlReEBDID);
            }


            XmlElement xmlDeviceInfoReport = xmlDoc.CreateElement("EBRPSState");
            xmlElem.AppendChild(xmlDeviceInfoReport);

            XmlElement xmlDevice = xmlDoc.CreateElement("EBRPS");//Term
            xmlDeviceInfoReport.AppendChild(xmlDevice);

            XmlElement xmlRptTime = xmlDoc.CreateElement("RptTime");
            xmlRptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlDevice.AppendChild(xmlRptTime);

            XmlElement xmlDeviceID = xmlDoc.CreateElement("EBRID");
            xmlDeviceID.InnerText = sHBRONO;
            xmlDevice.AppendChild(xmlDeviceID);

            XmlElement StateCode = xmlDoc.CreateElement("StateCode");
            StateCode.InnerText = "1";
            xmlDevice.AppendChild(StateCode);

            XmlElement StateDesc = xmlDoc.CreateElement("StateDesc");
            StateDesc.InnerText = "系统运行正常";
            xmlDevice.AppendChild(StateDesc);

            return xmlDoc;
        }

        public XmlDocument platformstateInfoResponse(string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();

            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;// strebdid;//
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBRPSState";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");

            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);


            //RelatedEBD
            //XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            //xmlElem.AppendChild(xmlRelatedEBD);
            //XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            //xmlReEBDID.InnerText = strebdid;//与EBDID一致就用这个写
            //xmlRelatedEBD.AppendChild(xmlReEBDID);


            XmlElement xmlDeviceInfoReport = xmlDoc.CreateElement("EBRPSState");
            xmlElem.AppendChild(xmlDeviceInfoReport);

            XmlElement xmlDevice = xmlDoc.CreateElement("EBRPS");//Term
            xmlDeviceInfoReport.AppendChild(xmlDevice);

            XmlElement xmlRptTime = xmlDoc.CreateElement("RptTime");
            xmlRptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlDevice.AppendChild(xmlRptTime);

            XmlElement xmlDeviceID = xmlDoc.CreateElement("EBRID");
            xmlDeviceID.InnerText = sHBRONO;
            xmlDevice.AppendChild(xmlDeviceID);

            XmlElement StateCode = xmlDoc.CreateElement("StateCode");
            StateCode.InnerText = "1";
            xmlDevice.AppendChild(StateCode);

            XmlElement StateDesc = xmlDoc.CreateElement("StateDesc");
            StateDesc.InnerText = "系统运行正常";
            xmlDevice.AppendChild(StateDesc);

            return xmlDoc;
        }

        /// <summary>
        /// 设备状态数据
        /// </summary>
        /// <param name="ebdsr"></param>
        /// <returns></returns>
        public XmlDocument DeviceStateResponse(EBD ebdsr, List<Device> lDevState, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;//
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBRDTState";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End
            //RelatedEBD
            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);
            if (ebdsr != null)
            {
                XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
                xmlReEBDID.InnerText = ebdsr.EBDID.ToString();//与EBDID一致就用这个写
                xmlRelatedEBD.AppendChild(xmlReEBDID);
            }
            #region DeviceInfoReport
            XmlElement xmlDeviceStateReport = xmlDoc.CreateElement("EBRDTState");
            xmlElem.AppendChild(xmlDeviceStateReport);

            string DeviEBRID = sHBRONO.Substring(4, sHBRONO.Length - 6);
            Console.WriteLine(DeviEBRID);

            #region Device
            if (lDevState.Count > 0)
            {
                for (int l = 0; l < lDevState.Count; l++)
                {
                    XmlElement xmlDevice = xmlDoc.CreateElement("EBRDT");
                    xmlDeviceStateReport.AppendChild(xmlDevice);

                    XmlElement xmlDeviceCategory = xmlDoc.CreateElement("RptTime");
                    xmlDeviceCategory.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    xmlDevice.AppendChild(xmlDeviceCategory);

                    XmlElement xmlDeviceID = xmlDoc.CreateElement("EBRID");
                    xmlDeviceID.InnerText = "0601" + lDevState[l].AreaCode.Substring(0,12) + lDevState[l].DeviceID; //"0601" + "321323000000" + lDevState[l].DeviceID;
                    xmlDevice.AppendChild(xmlDeviceID);

                    XmlElement xmlDeviceType = xmlDoc.CreateElement("StateCode");
                    xmlDeviceType.InnerText = "1";
                    xmlDevice.AppendChild(xmlDeviceType);
                    XmlElement xmlDeviceName = xmlDoc.CreateElement("StateDesc");
                    xmlDeviceName.InnerText = "正常";//
                    xmlDevice.AppendChild(xmlDeviceName);
                }
            }
            #endregion End
            #endregion End
            return xmlDoc;
        }

        public XmlDocument DeviceStateResponse(List<Device> lDevState, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;//
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBRDTState";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;
            xmlSRC.AppendChild(xmlSRCAreaCode);

            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End

            //RelatedEBD
            //XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            //xmlElem.AppendChild(xmlRelatedEBD);

            //XmlElement xmlReEBDID = xmlDoc.CreateElement("EBDID");
            //xmlReEBDID.InnerText = sHBRONO;//与EBDID一致就用这个写
            //xmlRelatedEBD.AppendChild(xmlReEBDID);

            #region DeviceInfoReport
            XmlElement xmlDeviceStateReport = xmlDoc.CreateElement("EBRDTState");
            xmlElem.AppendChild(xmlDeviceStateReport);

            string DeviEBRID = sHBRONO.Substring(4, sHBRONO.Length - 6);
            Console.WriteLine(DeviEBRID);
            #region Device
            if (lDevState.Count > 0)
            {
                for (int l = 0; l < lDevState.Count; l++)
                {
                    XmlElement xmlDevice = xmlDoc.CreateElement("EBRDT");
                    xmlDeviceStateReport.AppendChild(xmlDevice);

                    XmlElement xmlDeviceCategory = xmlDoc.CreateElement("RptTime");
                    xmlDeviceCategory.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    xmlDevice.AppendChild(xmlDeviceCategory);

                    XmlElement xmlDeviceID = xmlDoc.CreateElement("EBRID");
                    xmlDeviceID.InnerText = "0601" + lDevState[l].AreaCode.Substring(0,12) + lDevState[l].DeviceID;
                    xmlDevice.AppendChild(xmlDeviceID);

                    XmlElement xmlDeviceType = xmlDoc.CreateElement("StateCode");
                    xmlDeviceType.InnerText = "1";
                    xmlDevice.AppendChild(xmlDeviceType);
                    XmlElement xmlDeviceName = xmlDoc.CreateElement("StateDesc");
                    xmlDeviceName.InnerText = "正常";//
                    xmlDevice.AppendChild(xmlDeviceName);
                }
            }
            #endregion End
            #endregion End
            return xmlDoc;
        }

        public XmlDocument SignResponse(string refbdid, SignatureStructReply sigresult)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));

            XmlElement xmlElem = xmlDoc.CreateElement("Signature");
            xmlDoc.AppendChild(xmlElem);

            //Version
            XmlElement xmlVersion = xmlDoc.CreateElement("Version");
            xmlVersion.InnerText = "1.0";
            xmlElem.AppendChild(xmlVersion);

            //RelatedEBD
            XmlElement xmlRelatedEBD = xmlDoc.CreateElement("RelatedEBD");
            xmlElem.AppendChild(xmlRelatedEBD);

            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = refbdid;
            xmlRelatedEBD.AppendChild(xmlEBDID);

            // SignatureCert
            XmlElement xmlSignatureCert = xmlDoc.CreateElement("SignatureCert");
            xmlElem.AppendChild(xmlSignatureCert);

            XmlElement xmlCertType = xmlDoc.CreateElement("CertType");
            xmlCertType.InnerText = sigresult.certType;
            xmlSignatureCert.AppendChild(xmlCertType);

            XmlElement xmlIssuerID = xmlDoc.CreateElement("IssuerID");
            xmlIssuerID.InnerText = Base64str2Hexstr(sigresult.base64IssuerID);
            xmlSignatureCert.AppendChild(xmlIssuerID);

            //CertSN
            XmlElement xmlCertSN = xmlDoc.CreateElement("CertSN");
            xmlCertSN.InnerText = Base64str2Hexstr(sigresult.base64CertificateSN);
            xmlSignatureCert.AppendChild(xmlCertSN);


            //SignatureTime
            XmlElement xmlSignatureTime = xmlDoc.CreateElement("SignatureTime");
            xmlSignatureTime.InnerText = Convert.ToString(Convert.ToInt64(sigresult.signatureTime.ToString()), 16);
            xmlElem.AppendChild(xmlSignatureTime);
            //DigestAlgorithm
            XmlElement xmlDigestAlgorithm = xmlDoc.CreateElement("DigestAlgorithm");
            xmlDigestAlgorithm.InnerText = "SM3";
            xmlElem.AppendChild(xmlDigestAlgorithm);
            //SignatureAlgorithm
            XmlElement xmlSignatureAlgorithm = xmlDoc.CreateElement("SignatureAlgorithm");
            xmlSignatureAlgorithm.InnerText = "SM2";
            xmlElem.AppendChild(xmlSignatureAlgorithm);

            XmlElement xmlSignatureValue = xmlDoc.CreateElement("SignatureValue");
            xmlSignatureValue.InnerText = sigresult.base64Signature;
            xmlElem.AppendChild(xmlSignatureValue);
            return xmlDoc;
        }

        private string Base64str2Hexstr(string pp)
        {
           
            byte[] bpath = Convert.FromBase64String(pp);
            string str = "";
            for (int i = 0; i < bpath.Length; i++)
            {
                str += bpath[i].ToString("X2");
            }
            return str;
        }
        public XmlDocument ResponeEBMStateRequrest(string EBMID, string strebdid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = strebdid;
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBMStateResponse";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");

            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;//ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);


            //EBDTime
            XmlElement xmlEBDTime = xmlDoc.CreateElement("EBDTime");
            xmlEBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(xmlEBDTime);
            #endregion End

            XmlElement xmlEBMStateResponse = xmlDoc.CreateElement("EBMStateResponse");
            xmlElem.AppendChild(xmlEBMStateResponse);

            XmlElement RptTime = xmlDoc.CreateElement("RptTime");
            RptTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//从100000000000开始编号
            xmlEBMStateResponse.AppendChild(RptTime);

            XmlElement xmlEBM = xmlDoc.CreateElement("EBM");
            xmlEBMStateResponse.AppendChild(xmlEBM);

            XmlElement xmlEBMID = xmlDoc.CreateElement("EBMID");
            xmlEBMID.InnerText = EBMID;//从100000000000开始编号
            xmlEBM.AppendChild(xmlEBMID);

            //不加
            //XmlElement xmlRPTTime = xmlDoc.CreateElement("RptTime");
            //xmlRPTTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //xmlEBMStateResponse.AppendChild(xmlRPTTime);

            XmlElement xmlBRDState = xmlDoc.CreateElement("BrdStateCode");
            xmlBRDState.InnerText = "2";
            xmlEBMStateResponse.AppendChild(xmlBRDState);

            XmlElement BrdStateDesc = xmlDoc.CreateElement("BrdStateDesc");
            BrdStateDesc.InnerText = "完成";
            xmlEBMStateResponse.AppendChild(BrdStateDesc);

            return xmlDoc;
        }

        public XmlDocument SendEBM(string EBMID, string MusicName, string MusicDescName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            #region 标准头部
            //加入XML的声明段落,Save方法不再xml上写出独立属性
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            //加入根元素
            XmlElement xmlElem = xmlDoc.CreateElement("", "EBD", "");
            xmlDoc.AppendChild(xmlElem);
            XmlAttribute xmlns = xmlDoc.CreateAttribute("xmlns:xs");
            xmlns.Value = "http://www.w3.org/2001/XMLSchema";
            xmlElem.Attributes.Append(xmlns);

            //Version
            XmlElement xmlProtocolVer = xmlDoc.CreateElement("EBDVersion");
            xmlProtocolVer.InnerText = "1.0";
            xmlElem.AppendChild(xmlProtocolVer);
            //EBDID
            XmlElement xmlEBDID = xmlDoc.CreateElement("EBDID");
            xmlEBDID.InnerText = EBMID;
            xmlElem.AppendChild(xmlEBDID);

            //EBDType
            XmlElement xmlEBDType = xmlDoc.CreateElement("EBDType");
            xmlEBDType.InnerText = "EBM";
            xmlElem.AppendChild(xmlEBDType);

            //Source
            XmlElement xmlSRC = xmlDoc.CreateElement("SRC");
            xmlElem.AppendChild(xmlSRC);

            XmlElement xmlSRCAreaCode = xmlDoc.CreateElement("EBRID");
            xmlSRCAreaCode.InnerText = sHBRONO;//ebdsr.SRC.EBEID;
            xmlSRC.AppendChild(xmlSRCAreaCode);


            XmlElement DEST = xmlDoc.CreateElement("DEST");
            xmlElem.AppendChild(DEST);

            XmlElement EBRID = xmlDoc.CreateElement("EBRID");
            EBRID.InnerText = sHBRONO;//ebdsr.SRC.EBEID;
            DEST.AppendChild(EBRID);


            //EBDTime
            XmlElement EBDTime = xmlDoc.CreateElement("EBDTime");
            EBDTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlElem.AppendChild(EBDTime);
            #endregion End

            XmlElement xmlEBM = xmlDoc.CreateElement("EBM");
            xmlElem.AppendChild(xmlEBM);

            XmlElement EBMVersion = xmlDoc.CreateElement("EBMVersion");
            xmlEBM.AppendChild(EBMVersion);

            XmlElement xmlEBMID = xmlDoc.CreateElement("EBMID");
            xmlEBMID.InnerText = sHBRONO + DateTime.Now.ToString("yyyyMMddHHmm");
            xmlEBM.AppendChild(xmlEBMID);

            XmlElement xmlMesg = xmlDoc.CreateElement("MsgBasicInfo");
            xmlEBM.AppendChild(xmlMesg);

            XmlElement MsgType = xmlDoc.CreateElement("MsgType");
            MsgType.InnerText = "1";
            xmlMesg.AppendChild(MsgType);

            XmlElement SenderName = xmlDoc.CreateElement("SenderName");
            SenderName.InnerText = "江苏省应急平台";
            xmlMesg.AppendChild(SenderName);

            XmlElement SenderCode = xmlDoc.CreateElement("SenderCode");
            SenderCode.InnerText = "010232000000000001";
            xmlMesg.AppendChild(SenderCode);

            XmlElement SentTime = xmlDoc.CreateElement("SentTime");
            SentTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlMesg.AppendChild(SentTime);

            XmlElement EventType = xmlDoc.CreateElement("EventType");
            EventType.InnerText = "11000";
            xmlMesg.AppendChild(EventType);

            XmlElement Severity = xmlDoc.CreateElement("Severity");
            Severity.InnerText = "4";
            xmlMesg.AppendChild(Severity);

            XmlElement StartTime = xmlDoc.CreateElement("StartTime");
            StartTime.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            xmlMesg.AppendChild(StartTime);

            XmlElement EndTime = xmlDoc.CreateElement("EndTime");
            EndTime.InnerText = DateTime.Now.AddMinutes(5).ToString("yyyy-MM-dd HH:mm:ss");
            xmlMesg.AppendChild(EndTime);

            XmlElement LinkTypeSel = xmlDoc.CreateElement("EndTime");
            LinkTypeSel.InnerText = "0";
            xmlMesg.AppendChild(LinkTypeSel);

            XmlElement MsgContent = xmlDoc.CreateElement("MsgContent");
            xmlEBM.AppendChild(MsgContent);

            XmlElement LanguageCode = xmlDoc.CreateElement("LanguageCode");
            LanguageCode.InnerText = "zho";
            MsgContent.AppendChild(LanguageCode);

            XmlElement MsgTitle = xmlDoc.CreateElement("MsgTitle");
            MsgTitle.InnerText = "图南点歌台";
            MsgContent.AppendChild(MsgTitle);

            XmlElement MsgDesc = xmlDoc.CreateElement("MsgDesc");
            MsgDesc.InnerText = MusicName;
            MsgContent.AppendChild(MsgDesc);

            XmlElement AreaCode = xmlDoc.CreateElement("AreaCode");
            AreaCode.InnerText = "320102000000";
            MsgContent.AppendChild(AreaCode);

            XmlElement Auxiliary = xmlDoc.CreateElement("Auxiliary");
            MsgContent.AppendChild(Auxiliary);

            XmlElement AuxiliaryType = xmlDoc.CreateElement("AuxiliaryType");
            AuxiliaryType.InnerText = "2";
            Auxiliary.AppendChild(AuxiliaryType);

            XmlElement AuxiliaryDesc = xmlDoc.CreateElement("AuxiliaryDesc");
            AuxiliaryDesc.InnerText = MusicDescName;
            Auxiliary.AppendChild(AuxiliaryDesc);

            XmlElement Size = xmlDoc.CreateElement("Size");
            Size.InnerText = "0204286";
            Auxiliary.AppendChild(Size);

            XmlElement Digest = xmlDoc.CreateElement("Digest");
            Digest.InnerText = "";
            Auxiliary.AppendChild(Digest);

            return xmlDoc;
        }

    }
}
