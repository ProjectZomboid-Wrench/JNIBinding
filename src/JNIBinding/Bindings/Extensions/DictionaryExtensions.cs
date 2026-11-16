namespace JNIBinding.Bindings.Extensions;

public static class DictionaryExtensions
{
    public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> self, TKey key)
    {
        return self.TryGetValue(key, out var v)
            ? v
            : throw new ArgumentOutOfRangeException($"Key not found: {key}");
    }
}