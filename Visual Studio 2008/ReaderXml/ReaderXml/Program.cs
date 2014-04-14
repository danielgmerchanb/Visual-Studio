using System;
using System.IO;
using System.Xml;

namespace ReaderXml
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader(@"C:\Documents and Settings\danmerbe\Escritorio\Valor1.xml");

            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.ConformanceLevel = ConformanceLevel.Fragment;

            using (XmlReader xmlReader = XmlReader.Create(streamReader, xmlReaderSettings))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.OmitXmlDeclaration = true;

                using (StringWriter stringWriter = new StringWriter())
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
                    {
                        if (xmlReader.IsStartElement("MoreInfoProduct"))
                        {
                            xmlWriter.WriteStartElement("MoreInfoProduct", "http://www.publicar.com");
                            xmlWriter.WriteAttributeString("xmlns", "xsi", "", "http://www.w3.org/2001/XMLSchema-instance");
                            xmlWriter.WriteAttributeString("xmlns", "schemaLocation", "", "./SaibaMais.xsd");
                            xmlWriter.WriteRaw(xmlReader.ReadInnerXml());
                            xmlWriter.WriteEndElement();
                        }

                        xmlWriter.Close();
                    }

                    Console.Write(stringWriter.ToString());
                    Console.Read();
                }
            }
        }
    }
}
