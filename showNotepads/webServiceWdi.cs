using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace showNotepads
{
    public class webServiceWdi
    {
        public static void WriteLog(string message)
        {
            try
            {
                //string filed = @"E:\印步软件edos系统\普安\showNotepads\showNotepads\calcLog2.txt";
                string filed = @"E:\新建文件夹\calcLog2.txt";
                //string filed = Environment.CurrentDirectory + @"\calcLog2.txt";
                if (File.Exists(filed))
                {
                    using (StreamWriter sw = File.AppendText(filed))
                    {
                        sw.WriteLine(DateTime.Now.ToString() + " " + message);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(filed))
                    {
                        sw.WriteLine(DateTime.Now.ToString() + " " + message);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        #region
        //        private static Hashtable _xmlNamespaces = new Hashtable();//缓存xmlNamespace，避免重复调用GetNamespace

        //        /// <summary>
        //        /// 需要WebService支持Post调用
        //        /// </summary>
        //        /// <summary>
        //        /// 需要WebService支持Get调用
        //        /// </summary>
        //        public static XmlDocument QuerySoapWebService(String URL, String MethodName, string[] dataArray)
        //        {
        //            WriteLog("uRl:" + URL + "方法名:" + MethodName + "值:" + dataArray[0]);
        //            WriteLog("if判断:" + _xmlNamespaces.ContainsKey(URL));
        //            if (_xmlNamespaces.ContainsKey(URL))
        //            {
        //                WriteLog("执行第一个方法");
        //                return QuerySoapWebService(URL, MethodName, dataArray, _xmlNamespaces[URL].ToString());
        //            }
        //            else
        //            {
        //                WriteLog("执行否则");
        //                return QuerySoapWebService(URL, MethodName, dataArray, GetNamespace(URL));
        //            }
        //        }
        //        private static string GetNamespace(String URL)
        //        {
        //            return URL;
        //        }
        //        //类型 string
        //        private static XmlDocument QuerySoapWebService(String URL, String MethodName, string[] dataArray, string XmlNs)
        //        {
        //            //创建xml对象
        //            XmlDocument doc = new XmlDocument();
        //            XmlDocument doc2 = new XmlDocument();
        //            try
        //            {
        //                //如果字典集合中 就将url地址装入集合中
        //                _xmlNamespaces[URL] = XmlNs;//加入缓存，提高效率
        //                //采用http的链接方式访问webservice接口
        //                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
        //                WriteLog("request值:" + request);
        //                //定义传值方式
        //                request.Method = "POST";
        //                //获取或设置Content-Typehttp标头的值
        //                request.ContentType = "text/xml; charset=utf-8";
        //                //指定构成http标头的名称/值对的集合
        //                request.Headers.Add("SOAPAction", "\"" + XmlNs + (XmlNs.EndsWith("/") ? "" : "/") + MethodName + "\"");
        //                //设置验证时间
        //                SetWebRequest(request);
        //                //接受字节
        //                byte[] data = EncodeParsToSoap(dataArray, MethodName);
        //                for (int i = 0; i < data.Length; i++)
        //                {
        //                    WriteLog("字节的长度" + data[i]);

        //                }

        //                WriteRequestData(request, data);
        //                WriteLog("未进入WriteRequestData方法");
        //                WriteLog("响应" + request.GetResponse());
        //                doc = ReadXmlResponse(request.GetResponse());
        //                WriteLog(doc.OuterXml);

        //                XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
        //                mgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
        //                String RetXml = doc.SelectSingleNode("//soap:Body/*/*", mgr).InnerXml;
        //                //新加
        //                doc2.LoadXml("<root>" + RetXml + "</root>");
        //                WriteLog("装入xml的字段"+doc2.OuterXml);
        //;               AddDelaration(doc2);
        //                // return RetXml;
        //                return doc2;

        //            }
        //            catch (Exception)
        //            {
        //                WriteLog("异常信息");
        //                throw;
        //            }
        //            //catch (Exception ex)
        //            //{
        //            //    return "Error: " + ex.Message;
        //            //}
        //        }
        //        private static byte[] EncodeParsToSoap(string[] dataArray, String MethodName)
        //        {
        //            XmlDocument doc = new XmlDocument();
        //            doc.LoadXml("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:syn=\"http://syncuser.crp.com\"> <soapenv:Header/></soapenv:Envelope>");
        //            AddDelaration(doc);
        //            XmlElement soapBody = doc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
        //            XmlElement soapMethod = doc.CreateElement("syn", MethodName, "http://syncuser.crp.com/");
        //            soapBody.AppendChild(soapMethod);
        //            doc.DocumentElement.AppendChild(soapBody);
        //            return Encoding.UTF8.GetBytes(doc.OuterXml);
        //        }
        //        private static string ObjectToSoapXml(object o)
        //        {
        //            XmlSerializer mySerializer = new XmlSerializer(o.GetType());
        //            MemoryStream ms = new MemoryStream();
        //            mySerializer.Serialize(ms, o);
        //            XmlDocument doc = new XmlDocument();
        //            doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
        //            if (doc.DocumentElement != null)
        //            {
        //                return doc.DocumentElement.InnerXml;
        //            }
        //            else
        //            {
        //                return o.ToString();
        //            }
        //        }
        //        private static void SetWebRequest(HttpWebRequest request)
        //        {
        //            request.Credentials = CredentialCache.DefaultCredentials;
        //            request.Timeout = 100000;
        //        }
        //        private static void WriteRequestData(HttpWebRequest request, byte[] data)
        //        {
        //            request.ContentLength = data.Length;
        //            WriteLog("字节长度" + data.Length);
        //            Stream writer = request.GetRequestStream();
        //            WriteLog("写入请求数据值" + writer);
        //            writer.Write(data, 0, data.Length);
        //            writer.Close();
        //        }
        //        private static XmlDocument ReadXmlResponse(WebResponse response)
        //        {
        //            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        //            String retXml = sr.ReadToEnd();
        //            WriteLog("读取xml文件" + retXml);
        //            sr.Close();
        //            XmlDocument doc = new XmlDocument();
        //            doc.LoadXml(retXml);
        //            return doc;
        //        }
        //        private static void AddDelaration(XmlDocument doc)
        //        {
        //            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
        //            doc.InsertBefore(decl, doc.DocumentElement);
        //        }
        #endregion
        //<webServices>
        //  <protocols>
        //    <add name="HttpGet"/>
        //    <add name="HttpPost"/>
        //  </protocols>
        //</webServices>

        private static Hashtable _xmlNamespaces = new Hashtable();//缓存xmlNamespace，避免重复调用GetNamespace

        /// <summary>
        /// 需要WebService支持Post调用
        /// </summary>
        /// <summary>
        /// 需要WebService支持Get调用
        /// </summary>
        public static String QuerySoapWebService(String URL, String MethodName, string[] dataArray)
        {
            WriteLog("uRl:" + URL + "方法名:" + MethodName + "值:" + dataArray[0]);
            if (_xmlNamespaces.ContainsKey(URL))
            {
                WriteLog("返回第一个方法");
                return QuerySoapWebService(URL, MethodName, dataArray, _xmlNamespaces[URL].ToString());
            }
            else
            {
                WriteLog("返回否则");
                return QuerySoapWebService(URL, MethodName, dataArray, GetNamespace(URL));
            }
        }
        private static string GetNamespace(String URL)
        {
            return URL;
        }
        private static String QuerySoapWebService(String URL, String MethodName, string[] dataArray, string XmlNs)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                _xmlNamespaces[URL] = XmlNs;//加入缓存，提高效率
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
                WriteLog("request值:" + request);
                request.Method = "POST";
                request.ContentType = "text/xml; charset=utf-8";
                request.Headers.Add("SOAPAction", "\"" + XmlNs + (XmlNs.EndsWith("/") ? "" : "/") + MethodName + "\"");
                SetWebRequest(request);
                byte[] data = EncodeParsToSoap(dataArray, MethodName);
                for (int i = 0; i < data.Length; i++)
                {
                    WriteLog("字节：" + data[i]);

                }
                WriteRequestData(request, data);

                doc = ReadXmlResponse(request.GetResponse());
                WriteLog(doc.OuterXml);
                WriteLog(request.GetResponse().ToString());
                XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
                mgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
                String RetXml = doc.SelectSingleNode("//soap:Body/*/*", mgr).InnerXml;
                return RetXml;

            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        private static byte[] EncodeParsToSoap(string[] dataArray, String MethodName)
        {
            #region
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.xzsoft.com\"> <soapenv:Header/></soapenv:Envelope>");
            // doc.LoadXml("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:syn=\"http://syncuser.crp.com\"> <soapenv:Header/></soapenv:Envelope>");
            ////AddDelaration(doc);
            XmlElement soapBody = doc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
            //XmlElement soapMethod = doc.CreateElement("syn", MethodName, "http://syncuser.crp.com/");
            XmlElement soapMethod = doc.CreateElement("ws", MethodName, "http://ws.xzsoft.com/");

            #region
            foreach (string k in dataArray)
            {
                XmlElement soapPar = doc.CreateElement(k);
                soapPar.InnerXml = ObjectToSoapXml(k);
                soapMethod.AppendChild(soapPar);
            }
            #endregion
            soapBody.AppendChild(soapMethod);
            doc.DocumentElement.AppendChild(soapBody);
            //doc.Save("E:/印步软件edos系统/普安/showNotepads/ConsoleApp1/doc.xml");
            doc.Save("E:/erp/show3/doc.xml");
            return Encoding.UTF8.GetBytes(doc.OuterXml);
            #endregion
            #region
            //XmlDocument doc = new XmlDocument();
            //XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            ////doc.LoadXml("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.xzsoft.com\"> <soapenv:Header/><soapenv:Body></soapenv:Envelope");
            //XmlElement Envelope = doc.CreateElement("soapenv:Envelope");
            //doc.AppendChild(Envelope);
            //Envelope.SetAttribute("xmlns:soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            //Envelope.SetAttribute("xmlns:ws", "http://ws.xzsoft.com");
            //XmlElement Header = doc.CreateElement("soapenv" + ":" + "Header");
            //Envelope.AppendChild(Header);

            //XmlElement Body = doc.CreateElement("soapenv" + ":" + "Body");
            //Envelope.AppendChild(Body);
            //XmlElement getNotepads = doc.CreateElement("ws:getNotepads");
            //Body.AppendChild(getNotepads);
            ////创建后台应用代码标签
            //XmlElement appCode = doc.CreateElement("ws:appCode");
            //getNotepads.AppendChild(appCode);
            //appCode.InnerText = dataArray[0];
            ////创建秘钥
            //XmlElement secretKey = doc.CreateElement("ws:secretKey");
            //getNotepads.AppendChild(secretKey);
            //secretKey.InnerText = dataArray[1];
            ////创建组号编号
            //XmlElement orgCodes = doc.CreateElement("ws:orgCodes");
            //getNotepads.AppendChild(orgCodes);
            //orgCodes.InnerText = dataArray[2];
            //XmlElement logTypeName = doc.CreateElement("ws:logTypeName");
            //getNotepads.AppendChild(logTypeName);
            //logTypeName.InnerText = dataArray[3];
            //XmlElement createdStart = doc.CreateElement("ws:createdStart");
            //getNotepads.AppendChild(createdStart);
            //createdStart.InnerText = dataArray[4];
            //XmlElement createdEnd = doc.CreateElement("ws:createdEnd");
            //getNotepads.AppendChild(createdEnd);
            //createdEnd.InnerText = dataArray[5];
            //doc.Save("E:/印步软件edos系统/普安/showNotepads/ConsoleApp1/doc.xml");
            //return Encoding.UTF8.GetBytes(doc.OuterXml);
            #endregion

        }
        private static string ObjectToSoapXml(object o)
        {
            XmlSerializer mySerializer = new XmlSerializer(o.GetType());
            MemoryStream ms = new MemoryStream();
            mySerializer.Serialize(ms, o);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
            if (doc.DocumentElement != null)
            {
                return doc.DocumentElement.InnerXml;
            }
            else
            {
                return o.ToString();
            }
        }
        private static void SetWebRequest(HttpWebRequest request)
        {
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 100000;
        }
        private static void WriteRequestData(HttpWebRequest request, byte[] data)
        {
            WriteLog("字节长度" + data.Length);
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();
        }
        private static XmlDocument ReadXmlResponse(WebResponse response)
        {
           
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String retXml = sr.ReadToEnd();
            WriteLog("内容retXml：" + retXml);
            sr.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(retXml);
            return doc;
        }
    }

}
