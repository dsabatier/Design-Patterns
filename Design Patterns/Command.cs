using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Command
{
    // Command
    public interface IBattleAction
    {
        void Execute();
        // command pattern is often used in stacks or queues of commands
        // undo functionality is a common use
        // void Undo()

    }

    // ConcreteCommand
    // stores or calculates parameters and then performs some action, usually/sometimes/often on a receiver
    public class AttackBattleAction : IBattleAction
    {
        private Character _target;
        private int _damage;

        public AttackBattleAction(Character target, int damage)
        {
            _target = target;
            _damage = damage;
        }

        public void Execute()
        {
            _target.Damage(_damage);
            Console.WriteLine($"Basic attack on {_target.Name}!");
        }
    }

    // ConcreteCommand
    public class EscapeBattleAction : IBattleAction
    {
        Character _character;

        public EscapeBattleAction(Character character)
        {
            _character = character;
        }

        public void Execute()
        {
            _character.Escape();
        }
    }

    // ConcreteCommand
    public class UseItemBattleAction : IBattleAction
    {
        private Item _item;

        public UseItemBattleAction(Item item)
        {
            _item = item;
        }

        public void Execute()
        {
            _item.Use();
        }
    }

    // Invoker - executes commands
    public class BattleActionInvoker
    {
        private IBattleAction _basicAction;
        private IBattleAction _specialAction;

        public void SetBasicAction(IBattleAction action)
        {
            _basicAction = action;
        }

        public void SetSpecialAction(IBattleAction action)
        {
            _specialAction = action;
        }

        public void PerformBasicAction()
        {
            _basicAction.Execute();
        }

        public void PerformSpecialAction()
        {
            _specialAction.Execute();
        }
    }

    // Receiver - receiver carries out the hard work
    public class Character
    {
        private int _health;
        public string Name { get; private set; }

        public Character(string name)
        {
            Name = name;
        }

        public void Damage(int damage)
        {
            _health -= damage;
            Console.WriteLine($"Took {damage} damage! {_health} hp left!");
        }

        public void Escape()
        {
            Console.WriteLine($"{Name} attempted a daring escape!");
        }

    }

    // A different receiver
    public class Item
    {
        public void Use()
        {
            Console.WriteLine("Used an item!");
        }
    }
}
