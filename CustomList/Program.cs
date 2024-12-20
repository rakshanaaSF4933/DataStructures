namespace CustomList;
class Program
{
    public static void Main()
    {
        CustomList<int> list = new CustomList<int>();
        //Add elements to list
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);
        list.Add(50);
        System.Console.WriteLine("LIST :");
        foreach (int number in list)
        {
            System.Console.Write($"{number} ");
        }
        //Add new list to existing list
        CustomList<int> list1 = [60,70,80];
        list.AddRange(list1);
        System.Console.WriteLine("AddRange :");
        foreach (int number in list)
        {
            System.Console.Write($"{number} ");
        }
        list.InsertRange(2, list1);
        System.Console.WriteLine("InsertRange :");
        foreach (int number in list)
        {
            System.Console.Write($"{number} ");
        }
        //Check if element is in list
        System.Console.WriteLine($"Contains(1) : {list.Contains(1)}");
        //get index of element in list
        System.Console.WriteLine($"IndexOF(30) : {list.IndexOf(30)}");
        //insert element at position 2
        list.Insert(2, 1000);
        System.Console.WriteLine("Insert :");
        foreach (int number in list)
        {
            System.Console.Write($"{number} ");
        }
        //Remove element at position 7
        list.RemoveAt(7);
        System.Console.WriteLine("RemoveAT(7):");
        foreach (int number in list)
        {
            System.Console.Write($"{number} ");
        }
        //Remove element from the list
        System.Console.WriteLine("Remove 30:");
        list.Remove(30);
        foreach (int number in list)
        {
            System.Console.Write($"{number} ");
        }
        //Reverse the list
        list.Reverse();
        System.Console.WriteLine("Reverse");
        foreach (int number in list)
        {
            System.Console.Write($"{number} ");
        }
        //Sort the list
        System.Console.WriteLine("Sort");
        list.Sort();
        foreach (int number in list)
        {
            System.Console.Write($"{number} ");
        }
    }
}