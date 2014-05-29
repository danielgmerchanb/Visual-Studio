using System.Runtime.Serialization;

namespace ApiNoIp
{
    public class ValuesNoIp
    {
        private const string _www = "www.";

        public static string RemoveWww(string domain)
        {
            return domain.Replace(_www, string.Empty);
        }

        public interface IValuesNoIp
        {
            [DataMember]
            string cmd { get; set; }

            [DataMember]
            string email { get; set; }

            [DataMember]
            string customer_id { get; set; }

            [DataMember]
            string domain { get; set; }
        }

        [KnownTypeAttribute(typeof(AddDomain))]
        [DataContract]
        public struct AddDomain : IValuesNoIp
        {
            [DataMember]
            public string cmd { get; set; }

            [DataMember]
            public string email { get; set; }

            [DataMember]
            public string customer_id { get; set; }

            private string internalDomain;

            [DataMember]
            public string domain
            {
                get { return this.internalDomain; }
                set { this.internalDomain = ValuesNoIp.RemoveWww(value); }
            }

            [DataMember]
            public string package { get; set; }

            [DataMember]
            public string default_ip { get; set; }
        }

        [KnownTypeAttribute(typeof(ModifyHost))]
        [DataContract]
        public struct ModifyHost : IValuesNoIp
        {
            [DataMember]
            public string cmd { get; set; }

            [DataMember]
            public string email { get; set; }

            [DataMember]
            public string customer_id { get; set; }

            [DataMember]
            public string host { get; set; }

            private string internalDomain;

            [DataMember]
            public string domain
            {
                get { return this.internalDomain; }
                set { this.internalDomain = ValuesNoIp.RemoveWww(value); }
            }

            [DataMember]
            public string ip { get; set; }

            [DataMember]
            public string[] mx { get; set; }

            [DataMember]
            public string group_name { get; set; }

            public void RemoveWww()
            {
                this.domain = this.domain.Replace(_www, string.Empty);
            }
        }

        [KnownTypeAttribute(typeof(AddCname))]
        [DataContract]
        public struct AddCname : IValuesNoIp
        {
            [DataMember]
            public string cmd { get; set; }

            [DataMember]
            public string email { get; set; }

            [DataMember]
            public string customer_id { get; set; }

            private string internalDomain;

            [DataMember]
            public string domain
            {
                get { return this.internalDomain; }
                set { this.internalDomain = ValuesNoIp.RemoveWww(value); }
            }

            [DataMember]
            public string host { get; set; }

            [DataMember]
            public string target { get; set; }
        }

        /// <summary>
        /// Class encapsulates parameters for remove existing domain.
        /// </summary>
        [KnownTypeAttribute(typeof(RemoveDomain))]
        [DataContract]
        public struct RemoveDomain : IValuesNoIp
        {
            /// <summary>
            /// Name of the command sent to NoIp.
            /// </summary>
            [DataMember]
            public string cmd { get; set; }

            /// <summary>
            /// Email sent to NoIp.
            /// </summary>
            [DataMember]
            public string email { get; set; }

            /// <summary>
            /// Customer Identifier sent to NoIp.
            /// </summary>
            [DataMember]
            public string customer_id { get; set; }

            private string internalDomain;

            /// <summary>
            /// Namehost sent to NoIp.
            /// </summary>
            [DataMember]
            public string domain
            {
                get { return this.internalDomain; }
                set { this.internalDomain = ValuesNoIp.RemoveWww(value); }
            }
        }
    }
}
