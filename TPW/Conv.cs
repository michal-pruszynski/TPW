using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPW
{
    public class Conv
    {
        public void StringConv(string a)
        {
            int.TryParse(a, out int b);
            if (b == 0)
            {
                Console.WriteLine("That is not an all number string");
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
    }
}
