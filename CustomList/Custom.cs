using System.Collections;
namespace CustomList
{
    public partial class CustomList<Type>:IEnumerable,IEnumerator
    {
        //Using IEnumerator interface to use foreach functionality
        int position;
        public IEnumerator GetEnumerator()
        {
            position = -1;
            return this;
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
        public object Current{get{return _array[position];}}
    }
}