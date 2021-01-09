using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// State pattern is useful when you want to alter the behaviour of an object when its internal state changes.
/// </summary>
namespace Design_Patterns.StatePattern
{
    // Context
    public class Car
    {
        ICarState _currentState;

        public Car()
        {
            _currentState = new OffState();
        }

        public void TurnKey()
        {
            _currentState = _currentState.TurnOn();
        }

        public void Drive(string direction)
        {
            _currentState = _currentState.Drive(direction);
        }

        public void Brake()
        {
            _currentState = _currentState.Brake();
        }

        public void TurnOff()
        {
            _currentState = _currentState.TurnOff();
        }
    }

    // AbstractState
    public interface ICarState
    {
        ICarState TurnOn();
        ICarState Drive(string direction);
        ICarState Brake();
        ICarState TurnOff();
    }

    // ConcreteState
    public class OffState : ICarState
    {
        public ICarState Brake()
        {
            // car is off
            return this;
        }

        public ICarState Drive(string direction)
        {
            // car is off, can't go anywhere
            return this;
        }

        public ICarState TurnOff()
        {
            // car is already off
            return this;
        }

        public ICarState TurnOn()
        {
            Console.WriteLine("Turning on the car.");
            return new OnState();
        }
    }

    // ConcreteState
    public class OnState : ICarState
    {
        public ICarState Brake()
        {
            Console.WriteLine("Braking, but we aren't moving anywhere.");
            return this;
        }

        // state behaviour can vary differently - there is a chance the engine might misfire and fall idle, for example
        public ICarState Drive(string direction)
        {
            Console.WriteLine("Driving: " + direction);

            if(new Random().Next(1, 10) <= 2)
            {
                Console.WriteLine("Engine misfired :(");
                return new OffState();
            }
                
            return new DrivingState();
        }

        public ICarState TurnOff()
        {
            Console.WriteLine("Turning off.");
            return new OffState();
        }

        public ICarState TurnOn()
        {
            Console.WriteLine("Car is already on.");
            return this;
        }
    }

    // ConcreteState
    public class DrivingState : ICarState
    {

        public ICarState Brake()
        {
            Console.WriteLine("Car stopped but is running.");
            return new OnState();
        }

        public ICarState Drive(string direction)
        {
            Console.WriteLine("Car is driving.");
            return this;
        }

        public ICarState TurnOff()
        {
            Console.WriteLine("Can't turn off while it's moving.");
            return this;
        }

        public ICarState TurnOn()
        {
            Console.WriteLine("Car is already on and in motion, you should brake first.");
            return this;
        }
    }
}
