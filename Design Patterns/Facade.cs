using System;

/// <summary>
/// Use Facade to create a simpler interface from a much more complex one
/// </summary>
namespace Design_Patterns.Facade
{
    // Facade
    public class Face
    {

        Eye _leftEye;
        Eye _rightEye;
        Mouth _mouth;

        public Face(Eye leftEye, Eye rightEye, Mouth mouth)
        {
            _leftEye = leftEye;
            _rightEye = rightEye;
            _mouth = mouth;
        }

        public void ExpressJoy()
        {
            _leftEye.Shine();
            _rightEye.Shine();
            _mouth.Smile();
        }

        public void ExpressSad()
        {
            _rightEye.LookAway();
            _leftEye.LookAway();
            _mouth.Frown();
        }

        public void ExpressMurderousIntent()
        {
            _rightEye.LookAway();
            _leftEye.Stare();
            _mouth.Groan();
        }
    }

    // subsystem
    public class Eye
    {
        private string _color;

        public Eye(string color)
        {
            _color = color;
        }

        public void Stare()
        {
            Console.WriteLine($"Staring with {_color} eyes.");
        }

        public void Shine()
        {
            Console.WriteLine("Bright Eyed!");
        }

        public void LookAway()
        {
            Console.WriteLine("Looking away..");
        }


    }

    // subsystem
    public class Mouth
    {
        public void Groan()
        {
            Console.WriteLine("Groaning.");
        }

        public void Smile()
        {
            Console.WriteLine("Smiling!");
        }

        public void Frown()
        {
            Console.WriteLine("Opened Wide!");
        }
    }

}
