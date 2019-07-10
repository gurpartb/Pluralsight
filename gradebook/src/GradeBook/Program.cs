using System;

namespace GradeBook
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]+args[1]}!");
            }
            else
            {
                System.Console.WriteLine("Hello!");
            }
            return 0;
        }
    }
}
