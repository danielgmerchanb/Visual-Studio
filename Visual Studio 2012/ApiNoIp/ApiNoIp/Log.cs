using System;
using System.Runtime.Serialization;

namespace ApiNoIp
{
    [DataContract]
    public struct Log
    {
        [DataMember]
        public DateTime dateTime { get; set; }

        [DataMember]
        public ValuesNoIp.IValuesNoIp valuesNoIP { get; set; }

        [DataMember]
        public ResultNoIp resultNoIp { get; set; }
    }
}
