using System;
using System.Collections;
namespace CustomQueue
{
    public class CustomQueue<Type>: IEnumerable,IEnumerator
    {
        private int _head;
        private int _tail;
        private int _capacity;
        private int _count;
        private Type[] _array;
        public int Count{get{return _count;}}

        public CustomQueue()
        {
            _head = 0;
            _tail = 0;
            _count = 0;
            _capacity = 4;
            _array = new Type[_capacity];
        }
        public CustomQueue(int size)
        {
            _head = 0;
            _tail = 0;
            _count = 0;
            _capacity = size;
            _array = new Type[_capacity];
        }
        public void Enqueue(Type value)
        {
            //Check capacity whether capacity is enough to add element
            if(_tail == _capacity)
            {
                Grow();
            }
            //Add element to queue
            _array[_tail] = value;
            _tail++;
            _count++;
        }
        public void Grow()
        {
            //Increase capacity
            _capacity *=2;
            Type [] temp = new Type[_capacity];
            for(int i =_head;i<_tail;i++)
            {
                temp[i]=_array[i];
            }
            _array = temp;
        }
        public Type Peek()
        {
            //return first element in array
            if(_head == _tail)
            {
                return default(Type);
            }
            return _array[_head];
        }
        public Type Dequeue()
        {
            //return first element of array and delete it from array
            if(_head == _tail)
            {
                return default(Type);
            }
            _head ++;
            _count--;
            return _array[_head];
        }
        //Using IEnumerator to use foreach functionality
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
        public Object Current{get {return _array[position];}}
    }
}