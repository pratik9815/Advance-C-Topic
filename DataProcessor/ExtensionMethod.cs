using System;
public class Program
{
  public static void Main(string[] args)
    {
        // Extension Methods allow an existing type to be extended with new methods without changing the definition 
        // of the original. It allows you to add functionality to a type that you may not be able to inherit 
        // (because it's sealed) or you don't have the source code.
       // Here is an C# code that demonstrates how to create an extension method and how to use it
        string str = "say my name.";
        Console.WriteLine(str.WordCount());
        Console.WriteLine(str.AddSingleQuote());
    }
}
public static class ExtensionMethod
{
    public static int WordCount(this string str)
    {
        return str.Split(new char[]{',','.',' '}, StringSplitOptions.RemoveEmptyEntries).Length;
    }
    
    public static string AddSingleQuote(this string str)
    {
        return String.Concat("'", str,"'");
        
    }
}
