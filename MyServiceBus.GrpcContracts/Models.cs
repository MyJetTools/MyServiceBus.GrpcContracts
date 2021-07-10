using System.Runtime.Serialization;

namespace MyServiceBus.GrpcContracts
{
    
    [DataContract]
    public class MessageGrpcHeader
    {
        [DataMember(Order = 1)]
        public string Key { get; set; }

        [DataMember(Order = 2)]
        public string Value { get; set; }

    }
}