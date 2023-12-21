namespace Patterns.Hash
{
    internal class HashTableEntry
    {
        public int Key
        {
            get;
            init;
        }
        public object Value 
        { 
            get; 
            set; 
        }
        public HashTableEntry(object value) 
        {
            int index = value.GetHashCode();
            index %= 10;
            Key = Math.Abs(index);
            Value = value;
        }
    }
}
