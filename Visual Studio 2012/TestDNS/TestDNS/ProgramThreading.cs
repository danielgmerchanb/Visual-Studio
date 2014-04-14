using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading;

namespace TestDNS
{
    public static class ProgramThreading
    {
        #region Fields
        private static string pathFileDnsReader = ConfigurationManager.AppSettings["pathFileDnsReader"];

        private static string pathFileDnsWriter = ConfigurationManager.AppSettings["pathFileDnsWriter"];

        private static int maxThreads = Convert.ToInt32(ConfigurationManager.AppSettings["maxThreads"]);

        private static int countThreads = 0;

        private static int timeSleepMainProcess = Convert.ToInt32(ConfigurationManager.AppSettings["timeSleepMainProcess"]);

        private static string comma = ConfigurationManager.AppSettings["comma"];

        private static string finishMessage = ConfigurationManager.AppSettings["finishMessage"];

        private static object thisObject = new object();
        #endregion

        #region Methods
        public static void Main(string[] args)
        {
            List<Hostname>[] hostnameListArray = SplitListFileDNSReader(ReadFileDNSReader(pathFileDnsReader));

            for (int i = 0; i < maxThreads; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(GetHostAddressesList), hostnameListArray[i]);
            }

            while (maxThreads > countThreads)
            {
                Thread.Sleep(timeSleepMainProcess);
            }

            Console.WriteLine(finishMessage);
            Console.Read();
        }

        private static List<Hostname> ReadFileDNSReader(string pathFileDnsReader)
        {
            List<Hostname> hostnameList = new List<Hostname>();

            if (File.Exists(pathFileDnsReader))
            {
                using (StreamReader fileDNSReader = new StreamReader(pathFileDnsReader))
                {
                    while (fileDNSReader.Peek() != -1)
                        hostnameList.Add(new Hostname() { Domain = fileDNSReader.ReadLine().Replace("www.", "").Trim() });

                    fileDNSReader.Close();
                }
            }

            return hostnameList;
        }

        private static List<Hostname>[] SplitListFileDNSReader(List<Hostname> hostnameList)
        {
            List<Hostname>[] hostnameListArray = new List<Hostname>[maxThreads];

            if (hostnameList != null)
            {
                int mumDomain = (int)Math.Ceiling((float)hostnameList.Count / (float)maxThreads);

                int i = 0;

                for (int j = 0; j < hostnameListArray.Length; j++)
                {
                    hostnameListArray[j] = new List<Hostname>(mumDomain);

                    for (int k = 0; k < mumDomain; k++)
                    {
                        if (i < hostnameList.Count)
                        {
                            hostnameListArray[j].Add(hostnameList[i]);
                            i++;
                        }
                        else
                            break;
                    }
                }
            }

            return hostnameListArray;
        }

        private static string GetHostAddresses(string domain)
        {
            string hostAddresses = string.Empty;

            try
            {
                hostAddresses = Dns.GetHostAddresses(domain)[0].ToString();
            }
            catch (Exception exception)
            {
                hostAddresses = exception.Message;
            }

            return hostAddresses;
        }

        private static void GetHostAddressesList(object hostnameList)
        {
            foreach (Hostname hostname in (List<Hostname>)hostnameList)
            {
                hostname.HostAddresses = GetHostAddresses(hostname.Domain);
            }

            lock (thisObject)
            {
                using (StreamWriter streamWriter = new StreamWriter(pathFileDnsWriter, true))
                {
                    foreach (Hostname hostname in (List<Hostname>)hostnameList)
                    {
                        streamWriter.WriteLine(hostname.Domain + comma + hostname.HostAddresses);
                    }

                    streamWriter.Close();
                }
            }

            countThreads++;
        }
        #endregion

        #region Class
        public class Hostname
        {
            public string Domain { get; set; }
            public string HostAddresses { get; set; }
        }
        #endregion
    }
}
