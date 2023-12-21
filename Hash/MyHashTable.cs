namespace Patterns.Hash
{
    internal class MyHashTable
    {
        public List<HashTableEntry>? Hashes 
        {
            get;
            set;
        }
        public MyHashTable() 
        {
            Hashes = new List<HashTableEntry>(){null, null, null, null, null, null, null, null, null, null};
        }
        
        public void AddHash(object value) 
        {
            var hash = GetHash(value);
            if (hash == null)
            {
                var newHash = new HashTableEntry(value);
                Hashes[newHash.Key] = newHash;
                Console.WriteLine($"Hash {newHash.Key} {newHash.Value} is added");
            }
            else
            {
                Console.WriteLine($"Hash {hash.Key}-{hash.Value} is edited -> {hash.Key}-{value}");
                hash.Value = value;
            }
        }
        public object? GetValue(int key)
        {
            var hash = Hashes[key];
            if (hash != null)
            {
                return hash.Value;
            }
            else
            {
                return null;
            }
        }
        public void RemoveHash(object obj) 
        {
            var hash = GetHash(obj);
            if (hash != null && obj.Equals(hash.Value))
            {
                Console.WriteLine($"({hash.Key},{hash.Value}) is deleted");
                Hashes[hash.Key]=null;
            }
            else 
            {
                Console.WriteLine("No such hashes - {0}", obj);
            }
        }
        public HashTableEntry? GetHash(object obj) 
        {
            if (Hashes.Count!=0)
            {
                int index = Math.Abs(obj.GetHashCode());
                index %= 10;
                return Hashes[index]; 
            }
            return null;
        }
        public bool IsEmpty() 
        {
            return Hashes==null;
        }
        public void Clear() 
        {
            Hashes = null;
        }

        public void PrintHashes() 
        {
            if (!IsEmpty())
            {
                Console.WriteLine("Hash:");
                foreach (HashTableEntry entry in Hashes)
                {
                    if (entry != null)
                    {
                        Console.WriteLine($"{entry.Key} = {entry.Value}");
                    }
                }
            }
            else 
            {
                Console.WriteLine("No data!");
            }
        }
    }
}
