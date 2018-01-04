using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.ConsoleApp.Delegates
{
    public class AnonymusFunctions
    {

    }

    public class SimpleMath
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public void PrintSum(int x, int y)
        {
            Console.WriteLine(x + y);
        }
    }

    public class SimpleMathLambda
    {
        public int Add(int x, int y) => x + y;

        public void PrintSum(int x, int y) => Console.WriteLine(x + y);
    }

}
