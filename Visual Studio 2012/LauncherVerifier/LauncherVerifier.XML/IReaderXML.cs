using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LauncherVerifier.Models;

namespace LauncherVerifier.XML
{
    public interface IReaderXML
    {
        SummaryEntity GetSummary(string Path);

        string GetCompany(string Path, string IdCompany);
    }
}
