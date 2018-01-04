using Lab7.ConsoleApp.Delegates;
using Lab7.ConsoleApp.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkingWithGenericDictionaryExample2();

            Console.ReadKey();
        }

        #region Generics

        static void WorkWithGenericImplementation()
        {
            PersonCollection personCollection = new PersonCollection();
            personCollection.AddPerson(new Person("Eduard", "Romulus", 29));
            personCollection.AddPerson(new Person("Radu", "Constatin", 30));
            personCollection.AddPerson(new Person("August", "Cezar", 31));
            personCollection.AddPerson(new Person("Ragnar", "Floki", 40));

            foreach (Person person in personCollection)
            {
                Console.WriteLine(person.ToString());
            }
        }

        static void WorkingWithGenericListExample1()
        {
            List<Person> personList = new List<Person>();

            personList.Add(new Person("Eduard", "Romulus", 29));
            personList.Add(new Person("Radu", "Constatin", 30));
            personList.Add(new Person("August", "Cezar", 31));
            personList.Add(new Person("Ragnar", "Floki", 40));

            foreach (Person person in personList)
            {
                Console.WriteLine(person.ToString());
            }
        }

        static void WorkingWithGenericListExample2()
        {
            List<int> listOfInt = new List<int>();
            listOfInt.Add(2);
            listOfInt.Add(4);

            var person = new Person { Age = 1, FirstName = "sdadsa" };

            List<int> anotherListOfInt = new List<int>
            {
                1, 3, 5
            };

            listOfInt.AddRange(anotherListOfInt);

            Console.WriteLine($"Length of list: {listOfInt.Count}");

            foreach (int i in listOfInt)
            {
                Console.WriteLine(i);
            }

            int _value = listOfInt[3];

            listOfInt.Reverse();

            foreach (int i in listOfInt)
            {
                Console.WriteLine(i);
            }

        }

        static void WorkingWithGenericDictionaryExample1()
        {
            Dictionary<int, Person> personDictionary = new Dictionary<int, Person>();

            List<Person> personList = new List<Person>();
            personList.Add(new Person("Eduard", "Romulus", 29));
            personList.Add(new Person("Radu", "Constatin", 30));
            personList.Add(new Person("August", "Cezar", 31));
            personList.Add(new Person("Ragnar", "Floki", 40));

            personDictionary.Add(1, personList[0]);
            personDictionary.Add(2, personList[1]);
            personDictionary.Add(3, personList[2]);
            personDictionary.Add(4, personList[3]);

            foreach (KeyValuePair<int, Person> keyValuePair in personDictionary)
            {
                Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value.ToString()}");
            }
        }

        static void WorkingWithGenericDictionaryExample2()
        {
            Dictionary<int, Person> personDictionary = new Dictionary<int, Person>();

            List<Person> personList = new List<Person>();
            List<int> x = new List<int>();

            personList.Add(new Person("Eduard", "Romulus", 29));
            personList.Add(new Person("Radu", "Constatin", 30));
            personList.Add(new Person("August", "Cezar", 30));
            personList.Add(new Person("Ragnar", "Floki", 40));

            foreach (Person person in personList)
            {
                if (!personDictionary.ContainsKey(person.Age))
                {
                    personDictionary.Add(person.Age, person);
                }
            }

            foreach (KeyValuePair<int, Person> keyValuePair in personDictionary)
            {
                Console.WriteLine($"Key: {keyValuePair.Key}, Value: {keyValuePair.Value.ToString()}");
            }
        }

        static void WorkingWithGenericClassesExample1()
        {
            var personCollection = new GenericClass<Person>();

            personCollection.AddItem(new Person("Eduard", "M", 23));
            personCollection.AddItem(new Person("Iulian", "Z", 24));
            personCollection.AddItem(new Person("Maria", "T", 25));
            personCollection.AddItem(new Person("Margareta", "K", 26));

            personCollection.Display();

            var employeeCollection = new GenericClass<Employee>();

            employeeCollection.AddItem(new Employee { Id = 1, Name = "Eduard", Position = "Developer", Salary = 1000.0 });
            employeeCollection.AddItem(new Employee { Id = 2, Name = "Iulian", Position = "Developer", Salary = 1200.0 });
            employeeCollection.AddItem(new Employee { Id = 3, Name = "Constantin", Position = "Developer", Salary = 1030.0 });
            employeeCollection.AddItem(new Employee { Id = 4, Name = "Dumitry", Position = "Developer", Salary = 1004.0 });

            employeeCollection.Display();
        }

        #endregion Generics

        #region Delegates

        static void WorkingWithDelegatesExample1()
        {
            DelegateExample delegateExample = new DelegateExample();

            var addResult = delegateExample.AddDelegate(1, 2);
            Console.WriteLine(addResult);

            var diffResult = delegateExample.SubstractDelegate(3, 2);
            Console.WriteLine(diffResult);
        }

        static void WorkingWithDelegatesExample2()
        {
            Car car1 = new Car("Audi", 140);

            car1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

            for (int i = 10; i <= 100; i = i + 10)
            {
                car1.Accelerate(i);
            }
        }

        static void WorkingWithActionDelegatesExample1()
        {
            ActionAndFunc actionAndFunc = new ActionAndFunc();

            Action<int, int> displayAction = new Action<int, int>(actionAndFunc.DisplayAdd);
            displayAction(1, 2);

            displayAction += new Action<int, int>(actionAndFunc.DisplayDiff);
            displayAction(4, 1);

            Console.ReadKey();
        }

        static void WorkingWithFuncDelegateExample1()
        {
            ActionAndFunc actionAndFunc = new ActionAndFunc();

            Func<int, int, int> resultFunction = new Func<int, int, int>(actionAndFunc.Add);
            int result = resultFunction(1, 2);
            Console.WriteLine($"Result from function execution: {result}");

            resultFunction += new Func<int, int, int>(actionAndFunc.Diff);
            result = resultFunction(4, 2);
            Console.WriteLine($"Result from function execution: {result}");

            Console.ReadKey();
        }

        static void OnCarEngineEvent(string message)
        {
            Console.WriteLine("Message from Car object! ******");
            Console.WriteLine(message);
            Console.WriteLine("******");
        }

        static void WorkingWithEvents()
        {
            CarEvents car1 = new CarEvents("Audi", 150);

            car1.AboutToBlow += new CarEvents.CarEngineHandler(CarAboutToBlow);
            car1.Exploded += new CarEvents.CarEngineHandler(CarExploded);

            for (int i = 10; i <= 100; i = i + 10)
            {
                car1.Accelerate(i);
            }
        }

        static void CarAboutToBlow(string message)
        {
            Console.WriteLine($"-> Message from CarAboutToBlow event: {message}");
        }

        static void CarExploded(string message)
        {
            Console.WriteLine($"-> Message from CarExploed event: {message}");
        }

        static void AnonymusFunctions()
        {
            List<int> listOfInt = new List<int>();
            listOfInt.Add(2);
            listOfInt.Add(7);
            listOfInt.Add(4);
            listOfInt.Add(5);

            var numerePare = new List<int>();
            listOfInt.ForEach(x =>
            {
                if (x % 2 == 0)
                {
                    numerePare.Add(x);
                }
            });
        }

        static void TraditionalDelegateSyntax()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            Predicate<int> callback = IsEvenNumber;
            List<int> evenNumbers = list.FindAll(callback);

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);

            }
            Console.WriteLine();
        }

        static bool IsEvenNumber(int i)
        {
            return (i % 2) == 0;
        }

        static void AnonymousMethodSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            // Now, use an anonymous method.
            List<int> evenNumbers = list.FindAll(delegate (int i)
            {
                return (i % 2) == 0;
            });

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }

        static void LambdaExpressionSyntax()
        {
            // Make a list of integers.
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });
            
            // Now, use a C# lambda expression.
            List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);

            Console.WriteLine("Here are your even numbers:");

            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }

            Console.WriteLine();
        }


        #endregion Delegates
    }
}
