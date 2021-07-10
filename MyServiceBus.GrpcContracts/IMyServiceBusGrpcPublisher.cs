using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MyServiceBus.GrpcContracts
{
    [ServiceContract(Name = "engine.Publisher")]
    public interface IMyServiceBusGrpcPublisher
    {
        [OperationContract(Action = "Publish")]
        ValueTask<ResponseGrpc> PublishAsync(IAsyncEnumerable<PublisherContracts> messages);
    }
}