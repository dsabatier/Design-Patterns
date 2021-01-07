using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Command
{
    // Command
    public interface IBattleAction
    {
        void PerformAction();
    }

    // ConcreteCommand
    public class BasicAttackBattleAction : IBattleAction
    {
        private BattleActionController _controller;

        public BasicAttackBattleAction(BattleActionController controller)
        {
            _controller = controller;
        }

        public void PerformAction()
        {
            Console.WriteLine("Basic attack!");
        }
    }

    // ConcreteCommand
    public class UseItemBattleAction : IBattleAction
    {
        private BattleActionController _controller;
        private Item _item;

        public UseItemBattleAction(BattleActionController controller, Item item)
        {
            _controller = controller;
            _item = item;
        }

        public void PerformAction()
        {
            _item.Use();
        }
    }

    // ConcreteCommand
    public class EscapeBattleAction : IBattleAction
    {
        private BattleActionController _controller;

        public EscapeBattleAction(BattleActionController controller)
        {
            _controller = controller;
        }

        public void PerformAction()
        {
            Console.WriteLine("Escaping!");
        }
    }

    // Invoker
    public class BattleActionController
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
            _basicAction.PerformAction();
        }

        public void PerformSpecialAction()
        {
            _specialAction.PerformAction();
        }
    }

    // Receiver
    public class PartyMember
    {
        private BattleActionController _actionController;

        public PartyMember(BattleActionController actionController)
        {
            _actionController = actionController;
        }

        public void Battle()
        {
            _actionController.PerformBasicAction();
            _actionController.PerformSpecialAction();
        }

    }

    public class Item
    {
        public void Use()
        {
            Console.WriteLine("Item was used!");
        }
    }
}
