using System.ServiceModel;
using System.Threading.Tasks;

namespace MyServiceBus.GrpcContracts
{
    [ServiceContract(Name = "engine.Sessions")]
    public interface IMyServiceBusGrpcSessions
    {
        [OperationContract(Action = "Greeting")]
        ValueTask<GreetingGrpcResponse> GreetingAsync(GreetingGrpcRequest request);

        [OperationContract(Action = "Ping")]
        ValueTask<ResponseGrpc> PingAsync(PingGrpcContract request);
    }
}