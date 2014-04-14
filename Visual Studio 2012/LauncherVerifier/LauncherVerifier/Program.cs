using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LauncherVerifier.XML;
using LauncherVerifier.Models;

namespace LauncherVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string Prefix = @"C:\Total\Old\Total\";
            List<CompanyBigTable> anterior = Verify(Prefix);
            Prefix = @"C:\Total\New\Total\";
            List<CompanyBigTable> nueva = Verify(Prefix);

            int BranchCountAnt = anterior.Sum(q => q.BranchCount);
            int ProductCountAnt = anterior.Sum(q => q.ProductCount);
            int SponsorCountAnt = anterior.Sum(q => q.SponsorCount);

            int BranchCountNue = nueva.Sum(q => q.BranchCount);
            int ProductCountNue = nueva.Sum(q => q.ProductCount);
            int SponsorCountNue = nueva.Sum(q => q.SponsorCount);

            var badBranchCompanies = anterior.Join(nueva, q => q.CompanyId, p => p.CompanyId, (q, p) => new { ant = q, nue = p }).Where(q => q.ant.BranchCount != q.nue.BranchCount).Select(q => q).ToList();
            var badProductCompanies = anterior.Join(nueva, q => q.CompanyId, p => p.CompanyId, (q, p) => new { ant = q, nue = p }).Where(q => q.ant.ProductCount != q.nue.ProductCount).Select(q => q).ToList();
            var badSponsorCompanies = anterior.Join(nueva, q => q.CompanyId, p => p.CompanyId, (q, p) => new { ant = q, nue = p }).Where(q => q.ant.SponsorCount != q.nue.SponsorCount).Select(q => q).ToList();


        }

        private static List<CompanyBigTable> Verify(string Prefix)
        {
            ReaderXML target = new ReaderXML();
            string File = Prefix + "Companies_COL_F_1.xml";
            List<SummaryEntity> ret = new List<SummaryEntity>();
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_2.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_3.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_4.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_5.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_6.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_7.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_8.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_9.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_10.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_11.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_12.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_13.xml";
            ret.Add(target.GetSummary(File));
            File = Prefix + "Companies_COL_F_14.xml";
            ret.Add(target.GetSummary(File));
            SummaryEntity total = new SummaryEntity
            {
                BranchCount = ret.Sum(q => q.BranchCount),
                CompanyCount = ret.Sum(q => q.CompanyCount),
                File = "Total",
                ListingCount = ret.Sum(q => q.ListingCount),
                MicrositeCount = ret.Sum(q => q.MicrositeCount),
                ProductCount = ret.Sum(q => q.ProductCount),
                SponsorCount = ret.Sum(q => q.SponsorCount)
            };
            ret.Add(total);
            StringBuilder sb = new StringBuilder();
            ret.ForEach(q => sb.AppendFormat("{0} \n\t Company: {1}\n\t Branches: {2}\n\t Listings: {3}\n\t Microsites: {4}\n\t Products: {5}\n\t Sponsors: {6} \n",
                q.File,
                q.CompanyCount,
                q.BranchCount,
                q.ListingCount,
                q.MicrositeCount,
                q.ProductCount,
                q.SponsorCount));
            Console.Write(sb.ToString());
            return target.BigTable;
        }
    }
}
