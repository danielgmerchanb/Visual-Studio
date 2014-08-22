using System;
using System.Collections.Generic;
using Heijden.DNS;

namespace TestDNS
{
    public class DnsServer
    {
        private readonly Resolver _resolver;

        public DnsServer()
        {
            _resolver = new Resolver();
            _resolver.Recursion = true;
            _resolver.UseCache = true;
            _resolver.DnsServer = "8.8.8.8"; // Google Public DNS

            _resolver.TimeOut = 1000;
            _resolver.Retries = 3;
            _resolver.TransportType = TransportType.Udp;
        }

        public List<ProgramThreading.RecordMX> MxRecords(string name)
        {
            List<ProgramThreading.RecordMX> records = new List<ProgramThreading.RecordMX>();
            const QType qType = QType.MX;
            const QClass qClass = QClass.IN;

            Response response = _resolver.Query(name, qType, qClass);

            foreach (RecordMX record in response.RecordsMX)
            {
                records.Add(new ProgramThreading.RecordMX() { Preference = record.PREFERENCE.ToString(), Exchange = record.EXCHANGE });
            }

            return records;
        }

        public IList<string> TxtRecords(string name)
        {
            IList<string> records = new List<string>();
            const QType qType = QType.TXT;
            const QClass qClass = QClass.IN;

            Response response = _resolver.Query(name, qType, qClass);

            foreach (RecordTXT record in response.RecordsTXT)
            {
                records.Add(record.ToString());
            }

            return records;
        }

        public IList<string> GetQTypes()
        {
            IList<string> items = new List<string>();
            Array types = Enum.GetValues(typeof(QType));

            for (int index = 0; index < types.Length; index++)
            {
                items.Add(types.GetValue(index).ToString());
            }

            return items;
        }

        public IList<string> GetQClasses()
        {
            IList<string> items = new List<string>();
            Array types = Enum.GetValues(typeof(QClass));

            for (int index = 0; index < types.Length; index++)
            {
                items.Add(types.GetValue(index).ToString());
            }

            return items;
        }
    }
}
