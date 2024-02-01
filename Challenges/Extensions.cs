using System.Runtime.CompilerServices;

namespace Challenges
{
    public static class Extensions
    {
        public static IEnumerable<T> RemoveEvery<T>(this IEnumerable<T> collection, uint n) where T : unmanaged
            => InternalRemoveEvery(collection, n);

        public static IEnumerable<string> RemoveEvery(this IEnumerable<string> collection, uint n)
            => InternalRemoveEvery(collection, n);

        private static IEnumerable<T> InternalRemoveEvery<T>(IEnumerable<T> collection, uint n)
        {
            var result = new List<T>();
            var enumerator = collection.GetEnumerator();
            for (uint i = 1; enumerator.MoveNext(); i++)
            {
                if (i % n != 0)
                    result.Add(enumerator.Current);
            }

            return result;
        }
    }
}
