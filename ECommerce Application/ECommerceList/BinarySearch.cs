namespace ECommerceList
{
    public class BinarySearch<Type>
    {
        public int Search(CustomList<Type> list,Type ID)
        {
            
            int low = 0, mid;
            int high = list.Count - 1;
            while (low <= high)
            {
                mid = (low + high) / 2;
                if (list.IsGreater(ID,list[mid]) == true)
                {
                    low = mid + 1;
                }
                else if (ID.Equals(list[mid]))
                {
                    return mid;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
    }
}