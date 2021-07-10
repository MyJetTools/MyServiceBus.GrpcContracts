using System.Runtime.Serialization;

namespace MyServiceBus.GrpcContracts
{
    [DataContract]
    public class GreetingGrpcRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
        
        [DataMember(Order = 2)]
        public string ClientVersion { get; set; }
    }


    [DataContract]
    public class GreetingGrpcResponse
    {
        [DataMember(Order = 1)]
        public long SessionId { get; set; }
    }

    [DataContract]
    public class PingGrpcContract
    {
        [DataMember(Order = 1)]
        public long SessionId { get; set; }
    }

    public enum ResponseStatus
    {
        
        Ok, InvalidSession
    }

    [DataContract]
    public class ResponseGrpc
    {
        [DataMember(Order = 1)]
        public ResponseStatus Status { get; set; }
    }
}