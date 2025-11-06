using System.Runtime.InteropServices;

namespace DevL.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) where TKey : notnull
        {
            ref TValue? val = ref CollectionsMarshal.GetValueRefOrAddDefault<TKey, TValue>(dictionary, key, out bool exists);
            if (exists)
            {
                return val!;
            }
            val = value!;
            return value;
        }
    }
}
