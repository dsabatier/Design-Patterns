using System;


/// <summary>
/// Using a proxy (surrogate) lets you provide controlled access of that proxy's subject,
/// while still being used in the exact same manner of the subject
/// </summary>
namespace Design_Patterns.Proxy
{
    public interface IKnight
    {
        public abstract void DoTraining();
        public abstract void DoLocalAdventure();
        public abstract void DoEpicAdventure();

    }

    public class Knight : IKnight
    {
        public void DoEpicAdventure()
        {
            Console.WriteLine("I went a grand adventure!");
        }

        public void DoLocalAdventure()
        {
            Console.WriteLine("I saved some locals!");
        }

        public void DoTraining()
        {
            Console.WriteLine("Training as hard I can!");
        }

    }

    public class KnightInTraining : IKnight
    {
        private IKnight _subject;

        public KnightInTraining()
        {
            // in this example our proxy creates and wraps a subject
            // but a reference to a subject could also be passed in
            _subject = new Knight();
        }

        public void DoEpicAdventure()
        {
            Console.WriteLine("I'm not qualified to go an an epic adventure.  One day soon!");
        }

        public void DoLocalAdventure()
        {
            _subject.DoLocalAdventure();
        }

        public void DoTraining()
        {
            _subject.DoTraining();
        }
    }
}
