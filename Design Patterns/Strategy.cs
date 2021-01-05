using System;

/// <summary>
/// Delegate behaviour that is likely to change so that it can be swapped out for other behaviour (even at runtime)
/// </summary>
namespace Design_Patterns.Strategy
{

    public class Knight : Actor
    {
        public Knight()
        {
            SetAttackBehaviour(new MeleeAttackBehaviour());
            SetDefendBehaviour(new ShieldDefendBehaviour());
        }
    }

    public class Wizard : Actor
    {
        public Wizard()
        {
            SetAttackBehaviour(new AttackBehaviour());
            SetDefendBehaviour(new MagicForceFieldBehaviour());
        }
    }

    public class Archer : Actor
    {
        public Archer()
        {
            SetAttackBehaviour(new RangedAttackBehaviour());
            SetDefendBehaviour(new DefendBehaviour());
        }
    }

    public abstract class Actor
    {
        private AttackBehaviour _attackBehaviour;
        private DefendBehaviour _defendBehaviour;

        public void SetAttackBehaviour(AttackBehaviour l)
        {
            _attackBehaviour = l;
        }

        public void SetDefendBehaviour(DefendBehaviour r)
        {
            _defendBehaviour = r;
        }

        public void Defend()
        {
            _defendBehaviour.Defend();
        }

        public void Attack()
        {
            _attackBehaviour.Attack();
        }
    }

    public class AttackBehaviour
    {
        public virtual void Attack()
        {
            Console.WriteLine("Punch");
        }
    }

    public class MeleeAttackBehaviour : AttackBehaviour
    {
        public override void Attack()
        {
            Console.WriteLine("Melee Attack!");
        }
    }

    public class RangedAttackBehaviour : AttackBehaviour
    {
        public override void Attack()
        {
            Console.WriteLine("Ranged Attack!");
        }
    }

    public class DefendBehaviour
    {
        public virtual void Defend()
        {
            Console.WriteLine("Duck!");
        }
    }

    public class ShieldDefendBehaviour : DefendBehaviour
    {
        public override void Defend()
        {
            Console.WriteLine("Shields Up!");
        }
    }

    public class MagicForceFieldBehaviour : DefendBehaviour
    {
        public override void Defend()
        {
            Console.WriteLine("Magic Force Field!");
        }
    }
}
