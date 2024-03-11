using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string a;
            Console.WriteLine("type an all number string to convert it to int or ingame to get true'd");
            a = Console.ReadLine();
            Console.WriteLine(a);
            Console.WriteLine(Equals(a, "ingame"));
            Conv conv = new Conv();
            conv.StringConv(a);
        }
    }
}

