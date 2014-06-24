using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Async method calls and other utlity information printed out
            // DoThingsAsync();

            // Do things in a non-async manner 
            // DoThingsNonAsync();
            

        }

        /// <summary>
        /// This is a stub method that does nothing but clears up the cluttered code.
        /// The main purpose of thie method is to print out the elapsed time this method took
        /// </summary>
        public static void DoThingsNonAsync()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            // Console.WriteLine("What numbers do you want to add 5 to. Type S to stop");
            List<int> nums = new List<int>();

            const int MAX = 100000;

            int count = 0;
            while (count++ != MAX)
            {
                nums.Add(count);
            }

            int num = 0;
            nums.ForEach(_ =>
            {
                num = AddFiveToNumber(_);
            });

            sw.Stop();

            Console.WriteLine("Doing things in a async manner took: {0}ms {1}s {2}m",
                sw.ElapsedMilliseconds, sw.ElapsedMilliseconds / 1000.0, sw.ElapsedMilliseconds / 1000.0 / 60.0);
        }

        /// <summary>
        /// The main purpose of the method is to get the elapsed time the async method took.
        /// </summary>
        public static void DoThingsAsync()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            // Console.WriteLine("What numbers do you want to add 5 to. Type S to stop");
            List<int> nums = new List<int>();

            const int MAX = 100000;

            int count = 0;
            while (count++ != MAX)
            {
                nums.Add(count);
            }

            int num = 0;
            nums.ForEach(_ =>
            {
                Task<int> t = AddFiveToNumberAsync(_);
                num = t.Result;
            });

            sw.Stop();

            Console.WriteLine("Doing things in a async manner took: {0}ms {1}s {2}m",
                sw.ElapsedMilliseconds, sw.ElapsedMilliseconds / 1000.0, sw.ElapsedMilliseconds / 1000.0 / 60.0);
        }

        /// <summary>
        /// Add five to a number passed.
        /// </summary>
        /// <param name="num">What number do want to add five to?</param>
        /// <returns>return the value of num + 5</returns>
        private static int AddFiveToNumber(int num)
        {
            return num + 5;
        }

        /// <summary>
        /// This add five to a number using the async and tasks
        /// </summary>
        /// <param name="num">What number to you want to add five to?</param>
        /// <returns>return a Task of int that has already been started.</returns>
        private static async Task<int> AddFiveToNumberAsync(int num)
        {
            Func<int> func = () => num+5;
            Task<int> task = new Task<int>(func);
            task.Start();


            return await task;
        }
    }
}