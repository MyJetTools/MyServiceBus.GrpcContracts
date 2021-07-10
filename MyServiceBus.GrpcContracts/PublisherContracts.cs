using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyServiceBus.GrpcContracts
{

    [DataContract]
    public class CreateTopicGrpcContract
    {
        [DataMember(Order = 1)]
        public long SessionId { get; set; }
        
        [DataMember(Order = 2)]
        public string TopicId { get; set; }
    }
    
    [DataContract]
    public class MessagesToPublishGrpcContract
    {
        [DataMember(Order = 1)]
        public long SessionId { get; set; }
        
        [DataMember(Order = 2)]
        public string TopicId { get; set; }
        
        [DataMember(Order = 3)]
        public bool PersistImmediately { get; set; }
        
        [DataMember(Order = 4)]
        public List<MessageContentGrpcModel> Messages { get; set; }

    }

    [DataContract]
    public class BinaryDataGrpcWrapper
    {
        [DataMember(Order = 1)]
        public byte[] BinaryData { get; set; }
    }
}