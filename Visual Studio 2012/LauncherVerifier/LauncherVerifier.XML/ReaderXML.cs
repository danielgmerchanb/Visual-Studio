using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LauncherVerifier.Models;
using System.Xml.Linq;
using System.Xml;

namespace LauncherVerifier.XML
{
    public class ReaderXML:IReaderXML
    {
        List<CompanyBigTable> bigTable;

        public List<CompanyBigTable> BigTable
        {
            get { return bigTable; }
            set { bigTable = value; }
        }

        public ReaderXML()
        {
            bigTable = new List<CompanyBigTable>();
        }




        IEnumerable<XElement> SimpleStreamAxis(
                       string inputUrl, string matchName, string companyId)
        {
            using (XmlReader reader = XmlReader.Create(inputUrl))
            {
                int a = 0;
                reader.MoveToContent();
                while (!reader.EOF)
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name == matchName)
                            {
                                if (reader.GetAttribute("CompId") == companyId)
                                {
                                    XElement el = XElement.ReadFrom(reader)
                                                          as XElement;
                                    //if (el != null)
                                    //{
                                    a++;
                                    yield return el;
                                    //}
                                }
                                else
                                {
                                    reader.Read();
                                }
                            }
                            else
                            {
                                reader.Read();
                            }
                            break;
                        default:
                            reader.Read();
                            break;
                    }
                }
                reader.Close();
            }
        }

        public SummaryEntity GetSummary(string File)
        {
            XDocument xDoc = XDocument.Load(File);

            List<CompanyBigTable> aa = xDoc.Descendants().Elements("Company").Select(q => new CompanyBigTable
            {
                CompanyId = q.Attribute("CompId").Value,
                BranchInfo = q.Descendants().Elements("Branch").Select(p => p.Attribute("BranchId").Value).ToList(),
                BranchCount = q.Descendants().Elements("Branch").Count(),
                ProductInfo = q.Descendants().Elements("Product").Select(p => p.Attribute("ProductId").Value).ToList(),
                ProductCount = q.Descendants().Elements("Product").Count(),
                SponsorInfo = q.Descendants().Elements("Sponsor").Select(p => string.Join(";",p.Attributes().Select(r=>r.Name +"-"+r.Value))).ToList(),
                SponsorCount = q.Descendants().Elements("Sponsor").Count()
            }).ToList();

            bigTable.AddRange(aa);

            return new SummaryEntity
            {
                File = File,
                CompanyCount = xDoc.Descendants().Elements("Company").Count(),
                BranchCount = xDoc.Descendants().Elements("Branch").Count(),
                ListingCount = xDoc.Descendants().Elements("Listing").Count(),
                MicrositeCount = xDoc.Descendants().Elements("Microsite").Count(),
                ProductCount = xDoc.Descendants().Elements("Product").Count(),
                SponsorCount = xDoc.Descendants().Elements("Sponsor").Count()
            };

            //int bardQuotes =
            //    (from el in SimpleStreamAxis(inputUrl, "Branch")
            //    select el).Count();


            //IEnumerable<XElement> prueba = SimpleStreamAxis(inputUrl, "Company").ToList();

            

            //prueba = null;
        }


        public string GetCompany(string Path, string IdCompany)
        {

            var timer = System.Diagnostics.Stopwatch.StartNew();
            var a = SimpleStreamAxis(Path, "Company", IdCompany).ToList();
            timer.Stop();
            Int64 primermetodo = timer.ElapsedMilliseconds;
            timer.Restart();
            XDocument xDoc = XDocument.Load(Path);
            var aa = xDoc.Descendants("Company").Where(q => q.Attribute("CompId").Value.Equals(IdCompany)).FirstOrDefault();
                //.Where(q=>q.Attribute("CompId").Equals(IdCompany)).ToList();
                
            timer.Stop();
            Int64 segundometodo = timer.ElapsedMilliseconds;
            return string.Empty;
        }
    }
}
