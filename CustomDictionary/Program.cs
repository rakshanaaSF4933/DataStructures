using System;
namespace CustomDictionary;
class Program
{
    public static void Main()
    {
        //Create custom dictionary
        CustomDictionary<string,string> name = new CustomDictionary<string, string>();
        //Add key and value to dictionary
        name.Add("SF3001","aaa");
        name.Add("SF3002","bbb");
        name.Add("SF3002","ccc");
        //Print key and value of dictionary
        foreach(KeyValue<string,string> data in name)
        {
            Console.WriteLine($"ID : {data.Key}   Name : {data.Value}");
        }
        //Check if value is present int the dictionary
        System.Console.WriteLine(name.ContainsValue("aa"));
        //Check if key is present in the dictionary
        System.Console.WriteLine(name.ContainsKey("SF3002"));
        //Change value of key
        name["SF3001"] = "rrr";
        System.Console.WriteLine($"{name["SF3001"]}");
        //Remove a pair using key
        name.Remove("SF3002");
        System.Console.WriteLine($"Removed SF3002 : {name["SF3001"]}");
        //Clear whole dictionary
        name.Clear();
        foreach(KeyValue<string,string> data in name)
        {
            Console.WriteLine($"ID : {data.Key}   Name : {data.Value}");
        }
        System.Console.WriteLine("dictionary cleared");
    }
}