using System.ServiceModel;
using System.Threading.Tasks;
using ProtoBuf.Grpc;

namespace MyServiceBus.GrpcContracts
{
    [ServiceContract(Name = "engine.Sessions")]
    public interface IMyServiceBusGrpcSessions
    {
        [OperationContract(Action = "Greeting")]
        ValueTask<GreetingGrpcResponse> GreetingAsync(GreetingGrpcRequest request,
            CallContext context = default);

        [OperationContract(Action = "Ping")]
        ValueTask<MyServiceBusGrpcResponse> PingAsync(PingGrpcContract request);
    }
}