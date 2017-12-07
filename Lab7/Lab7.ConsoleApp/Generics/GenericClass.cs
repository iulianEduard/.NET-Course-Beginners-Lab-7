using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.ConsoleApp.Generics
{
    public class GenericClass<T> where T : class
    {
        private List<T> classList { get; set; }

        public void AddItem(T item)
        {
            classList.Add(item);
        }

        public T GetItem(int position)
        {
            return classList[position];
        }

        public void UpdateItem(int position, T item)
        {
            T itemList = classList[position];
            itemList = item;
        }

        public void Display()
        {
            Console.WriteLine("Display from generic class:");

            foreach(var item in classList)
            {
                Console.WriteLine($"{item.ToString()}");
            }
        }
    }
}
