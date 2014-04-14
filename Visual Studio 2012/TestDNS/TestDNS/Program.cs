using System;
using System.IO;
using System.Net;

namespace TestDNS
{
    public static class Program
    {
        public const string pathFileDnsWriter = @"C:\Users\danmerbe\Desktop\dominios.csv";

        static void Main(string[] args)
        {
            string pathFileDnsReader = args[0];

            if (args.Length == 1)
            {
                if (File.Exists(pathFileDnsReader))
                {
                    using (StreamReader fileDNSReader = new StreamReader(pathFileDnsReader))
                    {
                        using (StreamWriter fileDNSWriter = new StreamWriter(pathFileDnsWriter))
                        {
                            int i = 0;

                            while (fileDNSReader.Peek() != -1)
                            {
                                string domain = fileDNSReader.ReadLine();

                                try
                                {
                                    fileDNSWriter.WriteLine("{0};{1}", domain, Dns.GetHostAddresses(domain)[0].ToString());
                                }
                                catch (Exception exception)
                                {
                                    fileDNSWriter.WriteLine("{0};{1}", domain, exception.Message);
                                }

                                i++;

                                Console.Clear();
                                Console.Write(i);
                            }

                            fileDNSWriter.Close();
                        }

                        fileDNSReader.Close();
                    }
                }
            }

            Console.Read();
        }
    }
}
