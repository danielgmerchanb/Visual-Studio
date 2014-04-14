using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace LauncherVerifier.Models
{
    public class CompanyBigTable
    {
        public string CompanyId { get; set; }
        public List<string> BranchInfo { get; set; }
        public int BranchCount { get; set; }
        public List<string> ProductInfo { get; set; }
        public int ProductCount { get; set; }
        public List<string> SponsorInfo { get; set; }
        public int SponsorCount { get; set; }
    }
}
