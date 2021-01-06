using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Guarantees a single instance and provide global access
/// </summary>
namespace Design_Patterns.SingletonPattern
{
    public class Singleton
    {
        private static readonly Singleton _instance = new Singleton();
        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }

        static Singleton() { }
        private Singleton() { }

        public void DoAThing()
        {
            Console.WriteLine("D a thing");
        }
    }
}
