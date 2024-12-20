namespace CustomQueue;
class Program 
{
    public static void Main()
    {
        CustomQueue<int> queue = new CustomQueue<int>();
        //Add elements to queue
        queue.Enqueue(100);
        queue.Enqueue(200);
        queue.Enqueue(300);
        queue.Enqueue(400);
        queue.Enqueue(500);
        //Get queue count
        System.Console.WriteLine($"Count : {queue.Count}");
        //Get first element from queue
        System.Console.WriteLine($"PEEK : {queue.Peek()}");
        //Delete queue elements
        System.Console.WriteLine($"Dequeue : {queue.Dequeue()}");
        System.Console.WriteLine($"Dequeue : {queue.Dequeue()}");
        //Print queue
        foreach(int queue1 in queue)
        {
            System.Console.WriteLine(queue1);
        }

    }
}