internal class Program
{
    private static void Main(string[] args)
    {
        string a;
        Console.WriteLine("type an all number string to convert it to int or ingame to get true'd");
        a = Console.ReadLine();
        Console.WriteLine(a);
        Console.WriteLine(Equals(a, "ingame"));
        int.TryParse(a, out int b);
        if (b == 0)
        {
            Console.WriteLine("That is not an all number string");
        }
        else
        {
            Console.WriteLine(b);
        }
    }
}