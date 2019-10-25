using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arg = new string[6];
            arg[0] = "PMS_YXGL";
            arg[1] = "e44698ed-84ca-4092-ab4d-af7d1db0f958";
            arg[2] = "ZDPA";
            arg[3] = "值长日志";
            arg[4] = "2019-09-01";
            arg[5] = "2019-10-01";
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            //doc.LoadXml("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://ws.xzsoft.com\"> <soapenv:Header/><soapenv:Body></soapenv:Envelope");
            XmlElement Envelope = doc.CreateElement("soapenv:Envelope");
            doc.AppendChild(Envelope);
            Envelope.SetAttribute("xmlns:soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
            Envelope.SetAttribute("xmlns:ws", "http://ws.xzsoft.com");
            XmlElement Header = doc.CreateElement("soapenv" + ":" + "Header");
            Envelope.AppendChild(Header);

            XmlElement Body = doc.CreateElement("soapenv"+":"+"Body");
            Envelope.AppendChild(Body);
            XmlElement getNotepads = doc.CreateElement("ws:getNotepads");
            Body.AppendChild(getNotepads);
            //创建后台应用代码标签
            XmlElement appCode = doc.CreateElement("ws:appCode");
            getNotepads.AppendChild(appCode);
            appCode.InnerText = arg[0];
            //创建秘钥
            XmlElement secretKey = doc.CreateElement("ws:secretKey");
            getNotepads.AppendChild(secretKey);
            secretKey.InnerText = arg[1];
            //创建组号编号
            XmlElement orgCodes = doc.CreateElement("ws:orgCodes");
            getNotepads.AppendChild(orgCodes);
            orgCodes.InnerText = arg[2];
            XmlElement logTypeName = doc.CreateElement("ws:logTypeName");
            getNotepads.AppendChild(logTypeName);
            logTypeName.InnerText = arg[3];
            XmlElement createdStart = doc.CreateElement("ws:createdStart");
            getNotepads.AppendChild(createdStart);
            createdStart.InnerText = arg[4];
            XmlElement createdEnd = doc.CreateElement("ws:createdEnd");
            getNotepads.AppendChild(createdEnd);
            createdEnd.InnerText = arg[5];
            doc.Save("E:/印步软件edos系统/普安/showNotepads/ConsoleApp1/doc.xml");
        }
    }
}
