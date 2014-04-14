using System.Runtime.Serialization;

namespace ApiNoIp
{
    [DataContract]
    public struct ResultNoIp
    {
        [DataMember]
        public string result { get; set; }

        [DataMember]
        public string error { get; set; }
    }
}
