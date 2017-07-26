using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Demo
{
    public class AmazingDictionary<TKey, TValue>
    {
        public bool IsEmpty { get; private set; }

        private readonly List<KeyValuePair<TKey, TValue>> _list;

        public AmazingDictionary(int capacity = 10)
        {
            Contract.Requires(capacity > 0, "Capacity should be at least 1");
            _list = new List<KeyValuePair<TKey, TValue>>(capacity);
        }

        public KeyValuePair<TKey, TValue> Set(TKey key, TValue value)
        {
            Contract.Ensures(!IsEmpty, "Dictionary should not be empty");

            if (_list.Any(kv => kv.Key.Equals(key)))
            {
                _list.RemoveAll(kv => kv.Key.Equals(key));
            }

            var newPair = new KeyValuePair<TKey, TValue>(key, value);
            _list.Add(newPair);
            IsEmpty = false;

            return newPair;
        }

        public TValue Get(TKey key)
        {
            Contract.Requires(Contains(key), "Dictionary should already contain the key");

            foreach (var pair in _list)
                if (pair.Key.Equals(key))
                    return pair.Value;

            throw new KeyNotFoundException($"Key not found in dictionary: {key}");
        }

        [Pure]
        public bool Contains(TKey key)
        {
            Contract.Requires(!IsEmpty, "Dictionary should have at least one element");

            foreach (var pair in _list)
                if (pair.Key.Equals(key))
                    return true;

            return false;
        }

        [ContractInvariantMethod]
        private void Invariants()
        {
            Contract.Invariant(_list != null);
        }
    }
}
