using System;
using System.Collections.Generic;

/// <summary>
/// Define a one to many relationship that allow observers be notified of state changes
/// and control their own subscription/unsubscription
/// </summary>
namespace Design_Patterns.Observer
{
    public class Zergling : INotifiable
    {
        private Queen _queen;
        public Zergling(Queen queen)
        {
            _queen = queen;
            _queen.Subscribe(this);
        }

        public void Notify()
        {
            Console.WriteLine($"The queen is {_queen.GetState()}");
        }

        public void Die()
        {
            _queen.Unsubscribe(this);
        }
    }

    public class Queen : ISubscribable
    {
        private List<INotifiable> _minions = new List<INotifiable>();
        private string _state = "Alive";

        // use when observers fetch the state they need after a notify
        public string GetState()
        {
            return _state;
        }

        public void SetState(string newState)
        {
            _state = newState;
            Notify();
        }

        // pass no parameters when observers retrieve state on their own,
        // alternatively your notification could push state
        public void Notify()
        {
            foreach (INotifiable notifiable in _minions)
                notifiable.Notify();
        }

        public void Subscribe(INotifiable subscriber)
        {
            if (!_minions.Contains(subscriber))
                _minions.Add(subscriber);
        }

        public void Unsubscribe(INotifiable subscriber)
        {
            if (_minions.Contains(subscriber))
                _minions.Remove(subscriber);
        }
    }

    // subject
    public interface ISubscribable
    {
        public void Subscribe(INotifiable subscriber);

        public void Unsubscribe(INotifiable subscriber);

        public void Notify();

    }

    // observer
    public interface INotifiable
    {
        public void Notify();
    }
}
