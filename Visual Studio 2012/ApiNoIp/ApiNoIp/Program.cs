using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ApiNoIp
{
    class Program
    {
        #region Const
        private const string _pathLog = "NoIpLop{0}.txt";

        private const string _urlNoIp = "https://www.noip.com/api/mdns/api-rpc.php";

        private const string _codeResultSuccesful = "1";

        private const string _noipAddDomain = "noipAddDomain";

        private const string _noipModifyHost = "noipModifyHost";

        private const string _noipAddCname = "noipAddCname";

        private const string _noipRemoveHost = "noipDeleteDomain";

        //private const string _email = "udigital@carvajal.com";
        private const string _email = "dns@publicar.com";

        //private const string _customer_id = "carvajal_dns";
        private const string _customer_id = "publicar_dns";

        private const string _domain = "estefanultralab.com";

        private const string _package = "plus";

        private const string _default_ip = "107.23.132.196";

        private const string _ip = "107.23.132.196";

        private const string _mx1 = "sitemail.everyone.net";

        private const string _mx2 = "sitemail2.everyone.net";

        private const string _group_name = "";

        private const string _targetCorreo = "siteurl.everyone.net";

        private const string _targetWebmail = "siteurl.everyone.net";

        private const string _targetPop = "pop.everyone.net";

        private const string _targetSmtp = "smtp.everyone.net";

        private const string _targetImap = "imap.everyone.net";

        public class Host
        {
            public const string _www = "www";

            public const string _correo = "correo";

            public const string _webmail = "webmail";

            public const string _pop = "pop";

            public const string _smtp = "smtp";

            public const string _imap = "imap";
        }

        #endregion

        #region Methods
        public static void Main(string[] args)
        {
            AddDomain();
            Console.Read();
        }

        private static void AddDomain()
        {
            try
            {
                ValuesNoIp.AddDomain valuesNoIpAddDomain = new ValuesNoIp.AddDomain
                {
                    cmd = _noipAddDomain,
                    email = _email,
                    customer_id = _customer_id,
                    domain = _domain,
                    package = _package,
                    default_ip = _default_ip
                };
                SendPost(valuesNoIpAddDomain);

                ValuesNoIp.ModifyHost valuesNoIpModifyHost = new ValuesNoIp.ModifyHost
                {
                    cmd = _noipModifyHost,
                    email = _email,
                    customer_id = _customer_id,
                    host = "-",
                    domain = _domain,
                    ip = _default_ip,
                    mx = new string[] 
                    {
                        _mx1,
                        _mx2 
                    },
                    group_name = _group_name
                };
                SendPost(valuesNoIpModifyHost);

                ValuesNoIp.AddCname valuesNoIpAddCname = new ValuesNoIp.AddCname
                {
                    cmd = _noipAddCname,
                    email = _email,
                    customer_id = _customer_id,
                    domain = _domain,
                    host = Host._www,
                    target = _domain
                };
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._correo;
                valuesNoIpAddCname.target = _targetCorreo;
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._webmail;
                valuesNoIpAddCname.target = _targetWebmail;
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._pop;
                valuesNoIpAddCname.target = _targetPop;
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._smtp;
                valuesNoIpAddCname.target = _targetSmtp;
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._imap;
                valuesNoIpAddCname.target = _targetImap;
                SendPost(valuesNoIpAddCname);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void AddSubDomain()
        {
            try
            {
                ValuesNoIp.AddCname valuesNoIpAddCname = new ValuesNoIp.AddCname
                {
                    cmd = _noipAddCname,
                    email = "dns@publicar.com",
                    customer_id = "publicar_dns",
                    domain = "prueba.carvajalinformacion.com",
                    host = "prueba",
                    target = "carvajalinformacion.com"
                };
                SendPost(valuesNoIpAddCname);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void ModifyDomain()
        {
            try
            {
                ValuesNoIp.ModifyHost valuesNoIpModifyHost = new ValuesNoIp.ModifyHost
                {
                    cmd = _noipModifyHost,
                    email = _email,
                    customer_id = _customer_id,
                    host = "-",
                    domain = _domain,
                    ip = _default_ip,
                    mx = new string[] { _mx1, _mx2 },
                    group_name = _group_name
                };
                SendPost(valuesNoIpModifyHost);

                ValuesNoIp.AddCname valuesNoIpAddCname = new ValuesNoIp.AddCname
                {
                    cmd = _noipAddCname,
                    email = _email,
                    customer_id = _customer_id,
                    domain = _domain,
                    host = Host._www,
                    target = _domain
                };
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._correo;
                valuesNoIpAddCname.target = _targetCorreo;
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._webmail;
                valuesNoIpAddCname.target = _targetWebmail;
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._pop;
                valuesNoIpAddCname.target = _targetPop;
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._smtp;
                valuesNoIpAddCname.target = _targetSmtp;
                SendPost(valuesNoIpAddCname);

                valuesNoIpAddCname.host = Host._imap;
                valuesNoIpAddCname.target = _targetImap;
                SendPost(valuesNoIpAddCname);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void RemoveDomain()
        {
            ValuesNoIp.RemoveDomain jsonNoIpRemoveDomain = new ValuesNoIp.RemoveDomain
            {
                cmd = _noipRemoveHost,
                email = _email,
                customer_id = _customer_id,
                domain = _domain
            };
            SendPost(jsonNoIpRemoveDomain);
        }

        private static void SendPost(ValuesNoIp.IValuesNoIp valuesNoIp)
        {
            using (StringReader readerResponse = new StringReader(GetResponse(ConvertObjectToJson(valuesNoIp))))
            {
                string lastResponse = string.Empty;

                do
                {
                    lastResponse = readerResponse.ReadLine();
                } while (readerResponse.Peek() != -1);

                ResultNoIp resultNoIP = ConvertJsonToObject<ResultNoIp>(lastResponse);

                readerResponse.Close();

                RegisterLog(new Log()
                {
                    dateTime = DateTime.Now,
                    valuesNoIP = valuesNoIp,
                    resultNoIp = resultNoIP
                });

                if (resultNoIP.result != _codeResultSuccesful)
                    throw new Exception(resultNoIP.error);
            }
        }

        private static string ConvertObjectToJson(Object objectValue)
        {
            string objectJsonString = string.Empty;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(objectValue.GetType());

                    dataContractJsonSerializer.WriteObject(memoryStream, objectValue);

                    memoryStream.Position = 0;

                    using (StreamReader streamReader = new StreamReader(memoryStream))
                    {
                        objectJsonString = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
                finally
                {
                    memoryStream.Close();
                }
            }

            return objectJsonString;
        }

        private static T ConvertJsonToObject<T>(string objectJsonString)
        {
            T objectValue;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] postBinary = Encoding.ASCII.GetBytes(objectJsonString);

                memoryStream.Write(postBinary, 0, postBinary.Length);
                memoryStream.Position = 0;

                try
                {
                    DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));

                    objectValue = (T)dataContractJsonSerializer.ReadObject(memoryStream);

                }
                finally
                {
                    memoryStream.Close();
                }
            }

            return objectValue;
        }

        private static string GetResponse(string requestString)
        {
            string responseString = string.Empty;
            byte[] requestBinary = Encoding.ASCII.GetBytes(requestString);

            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(_urlNoIp);

            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "text/plain";
            httpWebRequest.ContentLength = requestBinary.Length;

            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                requestStream.Write(requestBinary, 0, requestBinary.Length);
                requestStream.Close();
            }

            using (WebResponse webResponse = httpWebRequest.GetResponse())
            {
                using (Stream responseStream = webResponse.GetResponseStream())
                {
                    using (StreamReader responseReader = new StreamReader(responseStream))
                    {
                        responseString = responseReader.ReadToEnd();
                        responseReader.Close();
                    }
                    responseStream.Close();
                }
                webResponse.Close();
            }

            return responseString;
        }

        private static void RegisterLog(Log log)
        {
            using (StreamWriter streamLog = new StreamWriter(string.Format(_pathLog, string.Empty), true, Encoding.Default))
            {
                streamLog.WriteLine(ConvertObjectToJson(log) + ",");
                streamLog.Close();
            }
        }
        #endregion
    }
}
