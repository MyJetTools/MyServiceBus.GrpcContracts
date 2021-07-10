using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyServiceBus.GrpcContracts
{
    
    [DataContract]
    public class MessageHeaderGrpcModel
    {
        [DataMember(Order = 1)]
        public string Key { get; set; }

        [DataMember(Order = 2)]
        public string Value { get; set; }

    }

    [DataContract]
    public class MessageContentGrpcModel
    {
        [DataMember(Order = 1)] 
        public List<MessageHeaderGrpcModel> Headers { get; set; }
        
        [DataMember(Order = 2)] 
        public byte[] Content { get; set; }

    }
}