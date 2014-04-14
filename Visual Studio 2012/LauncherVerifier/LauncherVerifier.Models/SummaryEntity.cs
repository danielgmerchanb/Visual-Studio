using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LauncherVerifier.Models
{
    public class SummaryEntity
    {
        public string File { get; set; }
        public int CompanyCount { get; set; }
        public int ProductCount { get; set; }
        public int BranchCount { get; set; }
        public int ListingCount { get; set; }
        public int SponsorCount { get; set; }
        public int MicrositeCount { get; set; }
    }
}
