using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.ConsoleApp.Generics
{
    public class PersonCollection : IEnumerable
    {
        private ArrayList arrayList = new ArrayList();

        public Person GetPerson(int position)
        {
            return (Person)arrayList[position];
        }

        public void AddPerson(Person person)
        {
            arrayList.Add(person);
        }

        public void ClearPeople()
        {
            arrayList.Clear();
        }

        public int Count
        {
            get { return arrayList.Count; }
        }

        public IEnumerator GetEnumerator()
        {
            return arrayList.GetEnumerator();
        }
    }
}
