namespace CustomStack
{
    public class CustomStack<Type>
    {
        private int _top;
        private int _capacity;
        public int Count { get { return _top + 1; } }
        public int Capacity { get { return _capacity; } }
        private Type[] _array;
        public CustomStack()
        {
            _top = -1;
            _capacity = 4;
            _array = new Type[Capacity];
        }
        public CustomStack(int size)
        {
            _top = -1;
            _capacity = size;
            _array = new Type[Capacity];
        }
        public void Push(Type value)
        {
            //IF capacity is not available increase capacity
            if (_top + 1 == _capacity)
            {
                Grow();
            }
            //Add element to array
            _array[_top + 1] = value;
            _top++;
        }
        public void Grow()
        {
            //Increase capacity 
            _capacity *= 2;
            Type[] temp = new Type[_capacity];
            for (int i = 0; i < _top + 1; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
        }

        public Type Peek()
        {
            //Show the top element of the array
            if (_top == -1)
            {
                return default(Type);
            }
            return _array[_top];
        }

        public Type Pop()
        {
            //Return the top element of the array and delete
            if (_top == -1)
            {
                return default(Type);
            }
            _top--;
            return _array[_top + 1];

        }
    }
}