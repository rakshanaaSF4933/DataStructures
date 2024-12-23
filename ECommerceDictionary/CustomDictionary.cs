using System;
using System.Collections;
namespace ECommerceDictionary
{
    public class CustomDictionary<TKey,TValue>: IEnumerable,IEnumerator
    {
        private int _count;
        private int _capacity;
        public int Count{get{return _count;}}
        private KeyValue<TKey,TValue> [] _array;
        public TValue this[TKey key]
        {
            get
            {
                //Get value from key
                TValue value = default(TValue);
                LinearSearch(key,out value);
                return value;
            }
            set
            {
                //Find position of key
                int position=LinearSearch(key,out TValue value1);
                //If position found set value to that key
                if(position >  -1)
                {
                    _array[position].Value = value;
                }
            }
        }
        public CustomDictionary()
        {
            _count = 0;
            _capacity = 4;
            _array = new KeyValue<TKey, TValue>[_capacity];
        }
        public CustomDictionary(int size)
        {
            _count = 0;
            _capacity = size;
            _array = new KeyValue<TKey, TValue>[_capacity];
        }
        public void Add(TKey key, TValue value)
        {
            //Check if capacity is available. If not available increase capacity
            if(_count == _capacity)
            {
                GrowSize();
            }
            //Find position to check if key is already present
            int position = LinearSearch(key, out TValue value2);
            //Add data only if key is not present already
            if(position == -1)
            {
                KeyValue<TKey,TValue> data = new KeyValue<TKey, TValue>();
                data.Key = key;
                data.Value = value;
                _array[_count]=data;
                _count++;
            }
        }
        public void GrowSize()
        {
            //Increase capacity
            _capacity *= 2;
            KeyValue<TKey,TValue> [] temp = new KeyValue<TKey, TValue>[_capacity];
            for(int i=0;i<_count;i++)
            {
                temp[i]=_array[i];
            }
            _array=temp;
        }
        public int LinearSearch(TKey key,out TValue value)
        {
            //Serach if key is present in the array
            value = default(TValue);
            for(int i =0 ;i<_count;i++)
            {
                if(_array[i].Key.Equals(key))
                {
                    value = _array[i].Value;
                    return i;
                }
            }
            return -1;
        }
        public bool ContainsKey(TKey key)
        {
            //check if key is present in the array
            int found = LinearSearch(key,out TValue value);
            if(found == -1)
            {
                return false;
            }
            return true;
        }
        public bool ContainsValue(TValue value)
        {
            //check if value is present in the array
            for(int i =0 ;i<_count;i++)
            {
                if(_array[i].Value.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }
        public void Remove(TKey key)
        {
            //check if key is present in the array
            int found = LinearSearch(key, out TValue value);
            //If key is present then delete the key valu pair
            if(found > -1)
            {
                _array[found]= null;
                _count -=1;
            }
        }
        public void Clear()
        {
            //Clear the whole dictionary
            _array = null;
            _capacity = 4;
            _count = 0;
        }
        //Use IEnumerator to use foreach functionality
        int position;
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return (IEnumerator)this;
        }
        public bool MoveNext()
        {
            if(position < _count-1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }
        public void Reset()
        {
            position = -1;
        }

        internal void Add(CustomDictionary<string, OrderDetails> orders)
        {
            throw new NotImplementedException();
        }

        public Object Current{get{return _array[position];}}
    }
}