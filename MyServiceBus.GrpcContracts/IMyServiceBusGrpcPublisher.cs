using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MyServiceBus.GrpcContracts
{
    [ServiceContract(Name = "engine.Publisher")]
    public interface IMyServiceBusGrpcPublisher
    {

        [OperationContract(Action = "CreateTopicIfNotExists")]
        ValueTask<MyServiceBusGrpcResponse> CreateTopicIfNotExistsAsync(CreateTopicGrpcContract contract);

        [OperationContract(Action = "Publish")]
        ValueTask<MyServiceBusGrpcResponse> PublishBinaryAsync(IAsyncEnumerable<BinaryDataGrpcWrapper> messages);
    }

    public static class MyServiceBusGrpcPublisher
    {

        private static IEnumerable<BinaryDataGrpcWrapper> SplitToPayloads(this MemoryStream payload, int maxPayloadSize)
        {

            var array = payload.GetBuffer();

            var pos = 0;

            while (pos < payload.Length)
            {

                var chunkSize = array.Length - pos;

                if (chunkSize > maxPayloadSize)
                    chunkSize = maxPayloadSize;


                var chunk = new ReadOnlyMemory<byte>(array, pos, chunkSize);

                yield return new BinaryDataGrpcWrapper
                {
                    BinaryData = chunk.ToArray()
                };

                pos += chunkSize;
            }

        }

        public static ValueTask<MyServiceBusGrpcResponse> PublishAsync(this IMyServiceBusGrpcPublisher grpc, MessagesToPublishGrpcContract messages, int maxPayloadSize)
        {
            var memStream = new MemoryStream();
            ProtoBuf.Serializer.Serialize(memStream, messages);

            return grpc.PublishBinaryAsync(memStream.SplitToPayloads(maxPayloadSize).ToAsyncEnumerable());
        }


        public static async ValueTask<T> ParseFromPayloadAsync<T>(this IAsyncEnumerable<BinaryDataGrpcWrapper> messagesAsyncStream)
        {
            var memoryStream = new MemoryStream();

            await foreach (var wrapper in messagesAsyncStream)
                memoryStream.Write(wrapper.BinaryData);

            var payload = new ReadOnlyMemory<byte>(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);

            return ProtoBuf.Serializer.Deserialize<T>(payload);
        }

    }
}