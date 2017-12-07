using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7.ConsoleApp.Delegates
{
    public class CarEvents
    {
        public int CurrentSpeed { get; set; }

        public int MaxSpeed { get; set; } = 200;

        public string Name { get; set; }

        private bool carIsDead;

        public delegate void CarEngineHandler(string messageForCaller);

        public event CarEngineHandler Exploded;

        public event CarEngineHandler AboutToBlow;

        public CarEvents()
        {

        }

        public CarEvents(string name, int currentSpeed)
        {
            Name = name;
            CurrentSpeed = currentSpeed;
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
            {
                if (Exploded != null)
                {
                    Exploded("Car is dead, sorry...");
                }
            }
            else
            {
                CurrentSpeed += delta;

                int difference = MaxSpeed - CurrentSpeed;
                if (difference <= 20  && AboutToBlow != null)
                {
                    AboutToBlow("Careful, car will soon explode!");
                }

                if (CurrentSpeed >= MaxSpeed)
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
