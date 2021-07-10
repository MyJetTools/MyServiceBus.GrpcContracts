using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MyServiceBus.GrpcContracts
{

    internal class AsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _src;

        public AsyncEnumerator(IEnumerator<T> src)
        {
            _src = src;
        }
        
        public ValueTask DisposeAsync()
        {
            _src.Dispose();
            return new ValueTask();
        }

        public ValueTask<bool> MoveNextAsync()
        {
            var result = _src.MoveNext();
            return new ValueTask<bool>(result);
        }

        public T Current => _src.Current;
    }

    public class AsyncEnumerable<T> : IAsyncEnumerable<T>
    {
        private readonly IEnumerable<T> _src;

        public AsyncEnumerable(IEnumerable<T> src)
        {
            _src = src;
        }
        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = new CancellationToken())
        {
            return new AsyncEnumerator<T>(_src.GetEnumerator());
        }
    }
    
    
    internal static class AsyncEnumerableUtils
    {
        public static IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IEnumerable<T> items)
        {
            return new AsyncEnumerable<T>(items);
        }
    }
}