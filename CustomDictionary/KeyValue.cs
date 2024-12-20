namespace CustomDictionary
{
    //class to store a key value pair in array
    public class KeyValue<TKey,TValue>
    {
        public TKey Key{get;set;}
        public TValue Value{get;set;}
    }
}