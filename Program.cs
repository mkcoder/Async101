using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch(); 

            sw.Start();

            Console.WriteLine("What numbers do you want to add 5 to. Type S to stop");
            List<int> nums = new List<int>();

            string x;
            while ((x = Console.ReadLine()).ToLower() != "s" )
            {
                nums.Add(Convert.ToInt32(x));
            }

            nums.ForEach(num => 
                Console.WriteLine("Adding 5 to {0} gives {1}",
                                    num, AddFiveToNumber(num)));

            sw.Stop();

            Console.WriteLine("{0}ms {1}s {2}m", sw.ElapsedMilliseconds, sw.ElapsedMilliseconds/1000.0, sw.ElapsedMilliseconds/1000.0/60.0);

        }

        private static int AddFiveToNumber(int num)
        {
            return num + 5;
        }

    }
}
