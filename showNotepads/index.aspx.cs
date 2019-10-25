using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace showNotepads
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region
            ///// <summary>
            ///// 使用WebClient下载WSDL信息
            ///// </summary>
            //WebClient web = new WebClient();
            //Stream stream = web.OpenRead("http://10.70.101.233:8000/pms/services/runlogeWebService?wsdl");
            ////2创建和格式化WSDL文档
            //ServiceDescription description = ServiceDescription.Read(stream);
            ////3创建客户端代理代理类
            //ServiceDescriptionImporter importer = new ServiceDescriptionImporter();
            //importer.ProtocolName = "Soap";//指定访问协议
            //importer.Style = ServiceDescriptionImportStyle.Client;//生成客户端代理
            //importer.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties | CodeGenerationOptions.GenerateNewAsync;
            //importer.AddServiceDescription(description, null, null);//添加WSDL文档
            ////4.使用CodeDom编译客户端代理类
            //CodeNamespace nmspace = new CodeNamespace();//为代理类添加命名空间，缺省为全局空间
            //CodeCompileUnit unit = new CodeCompileUnit();
            //unit.Namespaces.Add(nmspace);

            //ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit);
            //CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");

            //CompilerParameters parameters = new CompilerParameters();
            //parameters.GenerateExecutable = false;
            //parameters.GenerateInMemory = true;
            //parameters.ReferencedAssemblies.Add("System.dll");
            //parameters.ReferencedAssemblies.Add("System.XML.dll");
            //parameters.ReferencedAssemblies.Add("System.Web.Services.dll");
            //parameters.ReferencedAssemblies.Add("System.Data.dll");
            //CompilerResults result = provider.CompileAssemblyFromDom(parameters, unit);

            ////5.使用Reflection调用Webservice
            //if (!result.Errors.HasErrors)
            //{
            //    Assembly asm = result.CompiledAssembly;
            //    Type t = asm.GetType("WebService");

            //    object o = Activator.CreateInstance(t);
            //    MethodInfo method = t.GetMethod("getNotepads");
            //}
            #endregion
           // WriteLog("第一次加载");

            //string type = Request["type"].ToString().Trim();
            //string start = Request["startTime"].ToString().Trim();
            //string endtime = Request["endtime"].ToString().Trim();
            DateTime ds = DateTime.Now;
            string endtime = ds.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime de = ds.AddHours(-48);
            string start = de.ToString("yyyy-MM-dd HH:mm:ss");
        //    WriteLog(type + "" + start + "" + endtime);
            // string URL = "http://10.70.101.233:8000/pms/services/runlogeWebService?wsdl";
            string[] args = new string[6];
            args[0] = "PMS_YXGL";
            args[1] = "e44698ed-84ca-4092-ab4d-af7d1db0f958";
            args[2] = "ZDPA";
            //args[3] = "值长日志";
            //args[4] = "2019-09-01";
            //args[5] = "2019-10-01";
            args[3] = "值长日志";
            args[4] = start;
            args[5] = endtime;
           // WriteLog("第一次加载下拉框的值：" + args[3]);

            XmlDocument xx = cget_Api(args);
            XmlNodeList nodeList = xx.DocumentElement.ChildNodes;
            List<string> list = new List<string>();
            string[] si = nodeList[0].ChildNodes[0].InnerText.Split(new char[] { ',' });
            for (int i = 0; i < si.Length; i++)
            {
               // WriteLog("i第" + si[i]);
                if (si[i].Contains("happenTime"))
                {
                    list.Add(si[i]);
                }
                if (si[i].Contains("notePadContent"))
                {
                    list.Add(si[i] + "}");

                }
                if (si[i].Contains("empName"))
                {
                    list.Add("{" + si[i]);
                }
            }
            foreach (var item in list)
            {
               // WriteLog("集合中的内容" + item);
            }
            //StringBuilder sb = new StringBuilder();
            //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //jss.Serialize(list, sb);
            string sb = JsonConvert.SerializeObject(list);
            string Json = sb.Replace("\"{", "{");
            string Json1 = Json.Replace("\\", "");
            string Json2 = Json1.Replace("\",\"", ",");

            string Json4 = Json2.Replace("}\"", "\"}");
            string Json3 = Json4.Replace("\"\"", "\"");
         //   WriteLog("List转换json" + Json3);
            //StringBuilder Json1 = sb.Replace("\"", "");
            Response.Write(Json3);
            #region
            //DataTable dt = new DataTable();
            //DataColumn dc1 = new DataColumn("happenTime", Type.GetType("System.String"));
            //DataColumn dc2 = new DataColumn("notePadContent", Type.GetType("System.String"));
            //DataColumn dc3 = new DataColumn("empName", Type.GetType("System.String"));
            //dt.Columns.Add(dc1);
            //dt.Columns.Add(dc2);
            //dt.Columns.Add(dc3);
            //DataRow dr = dt.NewRow(); 
            //for (int i = 0; i < si.Length; i++)
            //{             
            //    if (si[i].Contains("happenTime"))
            //    {
            //        WriteLog("happenTime:" + si[i]);
            //        string[] time = si[i].Split(new char[] { ':' });
            //        WriteLog(time[0] + "," + time[1] + "");
            //        dr["happenTime"] = time[1];

            //    }
            //    else if (si[i].Contains("notePadContent"))
            //    {
            //        WriteLog("notePadContent:" + si[i]);
            //        string[] note = si[i].Split(new char[] { ':' });
            //        dr["notePadContent"] = note[1];
            //    }
            //    else if (si[i].Contains("empName"))
            //    {
            //        WriteLog("empName:" + si[i]);
            //        string[] emp = si[i].Split(new char[] { ':' });
            //        dr["empName"] = emp[1];
            //    }
            //    dt.Rows.Add(dr);
            //}
            #endregion
            //将xml转成json数据源
            // string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xx);        
            //   WriteLog("json:" + json);
            // string Json=json.Replace("\\","");
            //WriteLog("table:" + JsonConvert.SerializeObject(dt));
            //Response.Write(JsonConvert.SerializeObject(dt));


            //Response.Write(JsonConvert.SerializeObject(json));
            //Hashtable ht = new Hashtable();
            //ht.Add("ty", type);
            //ht.Add("st", start);
            //ht.Add("end", endtime);
            //接受webservice返回的xml文件 需要参数：webservice  URL地址 方法名  参数
            //  XmlDocument xx = new XmlDocument();
            // xx = WebServiceCaller.QuerySoapWebService("http://10.70.101.233:8000/pms/services/runlogWebService?wsdl", "getNotepads", args);
            //string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xx);
            // object xx = webservice.InvokeWebService("http://10.70.101.233:8000/pms/services/runlogWebService?wsdl", "getNotepads", args);
            #region 调用webservicewdi方法
            //WriteLog("开始执行调用webservice接口");
            //for (int i = 0; i < args.Length; i++)
            //{
            //    WriteLog("传入的值:" +i + ":" + args[i]);
            //}
            //string xx = webServiceWdi.QuerySoapWebService("http://10.70.101.233:8000/pms/services/runlogWebService?wsdl", "getNotepads", args);
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //List<DataTable> burnList = serializer.Deserialize<List<DataTable>>(xx);
            //Response.Write("转换datatable的值:" + burnList);
            //WriteLog(JsonConvert.SerializeObject(burnList));
            //WriteLog("接受到的值:" + xx);
            #endregion

            // List<DataTable> burnList = new List<DataTable>();
            //将接受到的xml转换成json对象



            //  WriteLog(json);
            //将json对象返回跟前台
            //Response.Write(json);
            //Response.Write(JsonConvert.SerializeObject(xx));


            //WriteLog(webservice.InvokeWebService(URL, "getNotepads", args).ToString());
            ////调用webservice方法
            //DataTable dt =new DataTable(webservice.InvokeWebService(URL, "getNotepads", args).ToString());
            //Response.Write(JsonConvert.SerializeObject(dt));
        }
        public static XmlDocument cget_Api(string[] data)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.xzsoft.com\">");
            str.Append("<soapenv:Header/>");
            str.Append("<soapenv:Body>");
            str.Append("<ws:getNotepads>");
            //str.Append("<![CDATA[<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            str.Append(string.Format("<ws:appCode>{0}</ws:appCode>", data[0]));
            str.Append(string.Format("<ws:secretKey>{0}</ws:secretKey>", data[1]));
            str.Append(string.Format("<ws:orgCodes>{0}</ws:orgCodes>", data[2]));
            str.Append(string.Format("<ws:logTypeName>{0}</ws:logTypeName>", data[3]));
            str.Append(string.Format("<ws:createdStart>{0}</ws:createdStart>", data[4]));
            str.Append(string.Format("<ws:createdEnd>{0}</ws:createdEnd>", data[5]));
            //str.Append("]]>");
            //str.Append(string.Format("<xs:appCode><![CDATA[<?xml version=\"1.0\" encoding=\"UTF-8\"?>{0}]]></xs:appCode>", data[0]));
            //str.Append(string.Format("<xs:secretKey><![CDATA[<?xml version=\"1.0\" encoding=\"UTF-8\"?>{0}]]></xs:secretKey>", data[1]));
            //str.Append(string.Format("<xs:orgCodes><![CDATA[<?xml version=\"1.0\" encoding=\"UTF-8\"?>{0}]]></xs:orgCodes>", data[2]));
            //str.Append(string.Format("<xs:logTypeName><![CDATA[<?xml version=\"1.0\" encoding=\"UTF-8\"?>{0}]]></xs:logTypeName>", data[3]));
            //str.Append(string.Format("<xs:createdStart><![CDATA[<?xml version=\"1.0\" encoding=\"UTF-8\"?>{0}]]></xs:createdStart>", data[4]));
            //str.Append(string.Format("<xs:createdEnd><![CDATA[<?xml version=\"1.0\" encoding=\"UTF-8\"?>{0}]]></xs:createdEnd>", data[5]));
            str.Append("</ws:getNotepads>");
            str.Append("</soapenv:Body>");
            str.Append("</soapenv:Envelope>");


            //发送请求
            // Uri uri = new Uri("http://10.70.101.233:8000/pms/services/runlogWebService?wsdl");
            // string xmlUlr = "http://10.70.101.233:8000/pms/services/runlogWebService?wsdl";
            Uri uri = new Uri("http://10.70.101.233:8000/pms/services/runlogWebService?wsdl");
            // WebRequest webRequest = WebRequest.Create(uri);
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
            webRequest.ContentType = "text/xml; charset=utf-8";
            webRequest.Method = "POST";
            //string MethodName = "getNotepads";
            // webRequest.Headers.Add("SOAPAction", "\"" + xmlUlr + (xmlUlr.EndsWith("/") ? "" : "/") + MethodName + "\"");
           // WriteLog("标头的值" + webRequest.Headers);

            using (Stream requestStream = webRequest.GetRequestStream())
            {
              //  WriteLog("str:" + str.ToString());
                byte[] paramBytes = Encoding.UTF8.GetBytes(str.ToString());
                //for (int i = 0; i < paramBytes.Length; i++)
                //{
                //    WriteLog("发送报文:" + i + ":" + paramBytes[i]);
                //}
               // WriteLog("发送长度" + paramBytes.Length);
                requestStream.Write(paramBytes, 0, paramBytes.Length);
            }

            //响应   
            WebResponse webResponse = webRequest.GetResponse();
            using (StreamReader myStreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
            {
              //  WriteLog("是否有响应" + myStreamReader == null ? "有" : "没有");
                string result = "";
                result = myStreamReader.ReadToEnd();
              //  WriteLog("读取接受" + result);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(result);
                return doc;
            }

        }
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

    }
}