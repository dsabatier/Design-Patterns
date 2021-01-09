using System.Collections.Generic;
using Design_Patterns.Strategy;
using Design_Patterns.Observer;
using Design_Patterns.Decorator;
using Design_Patterns.AbstractFactory;
using Design_Patterns.SingletonPattern;
using Design_Patterns.Command;
using Design_Patterns.Adapter;
using Design_Patterns.Facade;
using Design_Patterns.TemplateMethod;
using Design_Patterns.Iterator;
using Design_Patterns.Composite;

using System;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. strategy pattern
            Console.WriteLine("1");
            // note that all of these are treated as actors rather than their specific type
            Actor knight = new Knight();
            knight.Attack();
            knight.Defend();

            Actor wizard = new Wizard();
            wizard.Attack();
            wizard.Defend();

            Actor archer = new Archer();
            archer.Attack();
            archer.Defend();

            // allows you to operate on objects without caring what they are doing, only that they can perform that operation
            List<Actor> actors = new List<Actor>()
            {
                new Knight(),
                new Wizard(),
                new Archer()
            };

            foreach(Actor actor in actors)
            {
                actor.Attack();
                actor.Defend();
            }

            // 2. observer pattern
            Console.WriteLine("2");
            Queen queen = new Queen();
            List<Zergling> zerglings = new List<Zergling>();
            for(int i = 0; i < 3; i++)
            {
                zerglings.Add(new Zergling(queen));
            }


            queen.SetState("DEAD");

            // 3. decorator
            Console.WriteLine("3");
            // make a gun
            GunChassis machineGun = new HeavyGunChassis();

            // add automatic mod
            machineGun = new Automatic(machineGun);
            Console.WriteLine(machineGun.GetAccuracy());
            Console.WriteLine(machineGun.GetRateOfFire());

            // make a sniper..
            GunChassis sniper = new LightGunChassis();
            sniper = new Scope(sniper);
            Console.WriteLine(sniper.GetAccuracy());
            Console.WriteLine(sniper.GetRateOfFire());

            // make the sniper automatic!
            sniper = new Automatic(sniper);
            Console.WriteLine(sniper.GetAccuracy());
            Console.WriteLine(sniper.GetRateOfFire());

            // 4. abstract factory
            Console.WriteLine("4");
            ConfigurationFactory assaultShipFactory = new AssaultConfigurationFactory();
            Spaceship assaultShip = new AssaultShip(assaultShipFactory);
            assaultShip.Activate();


            ConfigurationFactory transportShipFactory = new HeavyTransportConfigurationFactory();
            Spaceship transportShip = new HeavyTransportShip(transportShipFactory);
            transportShip.Activate();

            // Fleet fleet = new Fleet(assaultShip, transportShip);

            // 5. singleton
            Console.WriteLine("5");

            Singleton.Instance.DoAThing();

            // 6. command pattern
            Console.WriteLine("6");

            // set up some receivers
            Character roy = new Character("Roy");
            Character targetDummy = new Character("Dummy");

            // set up invoker
            BattleActionInvoker royActionInvoker = new BattleActionInvoker();

            // some commands
            royActionInvoker.SetBasicAction(
                new AttackBattleAction(targetDummy, 10));

            royActionInvoker.SetSpecialAction(
                new EscapeBattleAction(roy));

            // perform basic attack!
            royActionInvoker.PerformBasicAction();

            // equip an item
            royActionInvoker.SetBasicAction(
                new UseItemBattleAction(new Item()));

            // use an item!
            royActionInvoker.PerformBasicAction();

            // escape! 
            royActionInvoker.PerformSpecialAction();

            // 7. adapter pattern
            Console.WriteLine("7");

            Shop shop = new Shop();

            OurShopItem ourShopItem = new OurShopItem();
            NewVendorProduct newVendorProduct = new NewVendorProduct();

            // add our shop item
            shop.AddToCart(ourShopItem);
            // we can't add the new vendor product using our cart because it does not match our interface
            // shop.AddToCart(newVendorProduct);

            // our adapter conforms to our interface
            NewVendorProductAdapter newVendorProductAdapter = new NewVendorProductAdapter(newVendorProduct);
            shop.AddToCart(newVendorProductAdapter);

            shop.Checkout();

            // 8. facade pattern
            Console.WriteLine("7");

            Eye leftEye = new Eye("Green");
            Eye rightEye = new Eye("Green");
            Mouth mouth = new Mouth();

            // put all those subsystems into the Face (Facade)
            // The face is asked to do work (express an emotion) and knows 
            // how to call the subsystems methods to accomplish that
            Face face = new Face(leftEye,rightEye, mouth);
            face.ExpressJoy();
            face.ExpressSad();
            face.ExpressMurderousIntent();

            // 9. Template Method

            // create some combos
            ComboAttack comboAttack = new BoxerCombo();
            ComboAttack fencerAttack = new FencerCombo();

            // execute them directly
            comboAttack.Execute();
            fencerAttack.Execute();

            // add them to a collection
            Queue<ComboAttack> comboAttacks = new Queue<ComboAttack>();
            comboAttacks.Enqueue(comboAttack);
            comboAttacks.Enqueue(fencerAttack);

            // call any of them without caring about their implementation
            comboAttacks.Dequeue().Execute();
            comboAttacks.Dequeue().Execute();

            // 10. Iterator

            IBag<Loot> goldBag = new GoldBag(10, true);
            IIterator<Loot> goldBagIterator = goldBag.GetIterator();

            IBag<Loot> equipmentBag = new EquipmentBag(
                new EquipmentLoot[]
                {
                    new EquipmentLoot("Shirt"),
                    new EquipmentLoot("Pants"),
                    new EquipmentLoot("Shoes") });

            IIterator<Loot> equipmentIterator = equipmentBag.GetIterator();

            List<IIterator<Loot>> iterators = new List<IIterator<Loot>>()
            { 
                goldBagIterator, 
                equipmentIterator
            };

            // just having fun with polymorphism
            foreach (IIterator<Loot> iterator in iterators)
            {
                iterator.Current().Open();

                // the important part is that we dont care how the collection is implemented, we just iterate through to the end
                // the iterator could be pulling randomly or popping from a stack/queue and it doesn't matter
                while (iterator.HasNext())
                    iterator.Next().Open();
            }

            // 11. Composite

            Node edmonton = new NodeComposite("Edmonton");
            Node westEdmonton = new NodeComposite("West Edmonton");
            Node aldergrove = new NodeLeaf("Aldergrove");
            Node callingwood = new NodeLeaf("Callingwood");
            Node southEdmonton = new NodeComposite("South Edmonton");
            Node millwoods = new NodeLeaf("Mill Woods");
            Node strathcona = new NodeLeaf("Strathcona");

            edmonton.Add(westEdmonton);
            edmonton.Add(southEdmonton);

            westEdmonton.Add(aldergrove);
            westEdmonton.Add(callingwood);

            southEdmonton.Add(millwoods);
            southEdmonton.Add(strathcona);

            edmonton.Print(); // print all of edmonton areas and neighborhoods
            westEdmonton.Print(); // only print west edmonton neighborhoods


        }
    }
}
