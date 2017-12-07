using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.ConsoleApp.Delegates
{
    public class Car
    {

        public int CurrentSpeed { get; set; }

        public int MaxSpeed { get; set; } = 200;

        public string Name { get; set; }

        private bool carIsDead;

        public delegate void CarEngineHandler(string messageForCaller);

        private CarEngineHandler listOfHandlers;

        public Car()
        {

        }

        public Car(string name, int currentSpeed)
        {
            Name = name;
            CurrentSpeed = currentSpeed;
        }

        public void RegisterWithCarEngine(CarEngineHandler carEngineHandler)
        {
            listOfHandlers = carEngineHandler;
        }

        public void Accelerate(int delta)
        {
            if(carIsDead)
            {
                if(listOfHandlers != null)
                {
                    listOfHandlers("Car is dead, sorry...");
                }
            }
            else
            {
                CurrentSpeed += delta;

                if(10 == MaxSpeed - CurrentSpeed)
                {
                    listOfHandlers("Careful, car will soon explode!");
                }

                if(CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                }
                else
                {
                    Console.WriteLine($"Current speed: {CurrentSpeed}");
                }
            }
        }
    }
}
