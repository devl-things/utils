using System.Runtime.CompilerServices;

namespace DevL.Extensions
{
    public static class IAsyncEnumerableExtensions
    {
        public static readonly IAsyncEnumerable<object> Empty = EmptyAsync();

        private static async IAsyncEnumerable<object> EmptyAsync()
        {
            yield break;
        }

        /// <summary>
        /// Creates an async enumerable that returns a single value.
        /// </summary>
        public static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(this T value)
        {
            yield return value;
        }

        /// <summary>
        /// Creates an async enumerable from a regular enumerable.
        /// </summary>
        public static async IAsyncEnumerable<T> ToAsyncEnumerable<T>(this IEnumerable<T> source, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            foreach (var item in source)
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return item;
            }
        }
    }
}
