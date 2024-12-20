namespace CustomStack;
class Program
{
    public static void Main()
    {
        CustomStack<int> stack = new CustomStack<int>();
        //Push element to stack
        stack.Push(100);
        stack.Push(200);
        stack.Push(300);
        stack.Push(400);
        stack.Push(500);
        //Peek element from stack
        System.Console.WriteLine($"PEEK : {stack.Peek()}");
        //Pop elements from the stack
        System.Console.WriteLine($"POP : {stack.Pop()}");
        System.Console.WriteLine($"POP : {stack.Pop()}");
        System.Console.WriteLine($"POP : {stack.Pop()}");
        System.Console.WriteLine($"POP : {stack.Pop()}");
    }
}