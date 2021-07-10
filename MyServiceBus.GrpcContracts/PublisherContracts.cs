using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyServiceBus.GrpcContracts
{
    
    
    [DataContract]
    public class PublisherContracts
    {
        [DataMember(Order = 1)]
        public long SessionId { get; set; }
        
        [DataMember(Order = 2)]
        public string TopicId { get; set; }
        
        [DataMember(Order = 3)]
        public List<MessageGrpcHeader> Headers { get; set; }
        
        [DataMember(Order = 4)]
        public byte[] Message { get; set; }
    }
}