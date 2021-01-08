using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Template Methods allow you define how to call some series of functions
/// and letting subclasses implement those functions
/// </summary>
namespace Design_Patterns.TemplateMethod
{
    public abstract class ComboAttack
    {
        // this is the template method
        public void Execute()
        {
            LightAttack();
            LightAttack();
            MediumAttack();
            FierceAttack();
            SpecialAttack();
        }

        protected abstract void LightAttack();
        protected abstract void MediumAttack();
        protected abstract void FierceAttack();
        protected virtual void SpecialAttack()
        {

        }
    }

    public class BoxerCombo : ComboAttack
    {
        protected override void FierceAttack()
        {
            Console.WriteLine("Uppercut!");
        }

        protected override void LightAttack()
        {
            Console.WriteLine("Jab!");
        }

        protected override void MediumAttack()
        {
            Console.WriteLine("Left Hook!");
        }

        // does not override special attack
    }

    public class FencerCombo : ComboAttack
    {
        protected override void FierceAttack()
        {
            Console.WriteLine("Stab!");
        }

        protected override void LightAttack()
        {
            Console.WriteLine("Thrust!");
        }

        protected override void MediumAttack()
        {
            Console.WriteLine("Slash!");
        }

        protected override void SpecialAttack()
        {
            Console.WriteLine("Wild blade throw!");
        }
    }
}
