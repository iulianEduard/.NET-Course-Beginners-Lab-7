using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.ConsoleApp.Generics
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public double Salary { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Position: {Position}, Salary: {Salary}";
        }
    }
}
