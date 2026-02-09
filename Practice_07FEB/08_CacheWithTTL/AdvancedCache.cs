using System;
using System.Collections.Generic;

public class AdvancedCache<TKey, TValue>
{
    private readonly int _capacity;

    private readonly Dictionary<TKey, LinkedListNode<CacheItem>> _map;
    private readonly LinkedList<CacheItem> _lruList;

    private class CacheItem
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public DateTime Expiry { get; set; }
    }

    public AdvancedCache(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than 0.");

        _capacity = capacity;
        _map = new Dictionary<TKey, LinkedListNode<CacheItem>>();
        _lruList = new LinkedList<CacheItem>();
    }

    public void Set(TKey key, TValue value, int ttlSeconds)
    {
        var expiry = DateTime.UtcNow.AddSeconds(ttlSeconds);

        if (_map.ContainsKey(key))
        {
            var node = _map[key];
            node.Value.Value = value;
            node.Value.Expiry = expiry;

            MoveToFront(node);
            return;
        }

        if (_map.Count >= _capacity)
        {
            EvictLRU();
        }

        var newItem = new CacheItem
        {
            Key = key,
            Value = value,
            Expiry = expiry
        };

        var newNode = new LinkedListNode<CacheItem>(newItem);

        _lruList.AddFirst(newNode);
        _map[key] = newNode;
    }

    public TValue Get(TKey key)
    {
        if (!_map.TryGetValue(key, out var node))
            return default;

        // Check expiry
        if (DateTime.UtcNow > node.Value.Expiry)
        {
            RemoveNode(node);
            return default;
        }

        MoveToFront(node);
        return node.Value.Value;
    }

    private void MoveToFront(LinkedListNode<CacheItem> node)
    {
        _lruList.Remove(node);
        _lruList.AddFirst(node);
    }

    private void EvictLRU()
    {
        var lruNode = _lruList.Last;

        if (lruNode != null)
        {
            _map.Remove(lruNode.Value.Key);
            _lruList.RemoveLast();
        }
    }

    private void RemoveNode(LinkedListNode<CacheItem> node)
    {
        _map.Remove(node.Value.Key);
        _lruList.Remove(node);
    }
}
