using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.ConsoleApp.Delegates
{
    public delegate int Operation(int a, int b);

    public class DelegateExample
    {
        public int AddDelegate(int x, int y)
        {
            Operations operations = new Operations();
            Operation addOperation = new Operation(operations.Add);

            return addOperation(x, y);
        }

        public int SubstractDelegate(int x, int y)
        {
            Operations operations = new Operations();
            Operation diffOperation = new Operation(operations.Diff);

            return diffOperation(x, y);
        }
    }

    public class Operations
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Diff(int x, int y)
        {
            return x - y;
        }
    }

}
