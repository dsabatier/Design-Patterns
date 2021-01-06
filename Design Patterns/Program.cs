using System.Collections.Generic;
using Design_Patterns.Strategy;
using Design_Patterns.Observer;
using Design_Patterns.Decorator;
using Design_Patterns.AbstractFactory;
using Design_Patterns.SingletonPattern;
using System;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. strategy pattern

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

            Queen queen = new Queen();
            List<Zergling> zerglings = new List<Zergling>();
            for(int i = 0; i < 3; i++)
            {
                zerglings.Add(new Zergling(queen));
            }


            queen.SetState("DEAD");

            // 3. decorator

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

            // 4. factory

            ConfigurationFactory assaultShipFactory = new AssaultConfigurationFactory();
            Spaceship assaultShip = new AssaultShip(assaultShipFactory);
            assaultShip.Activate();


            ConfigurationFactory transportShipFactory = new HeavyTransportConfigurationFactory();
            Spaceship transportShip = new HeavyTransportShip(transportShipFactory);
            transportShip.Activate();

            // Fleet fleet = new Fleet(assaultShip, transportShip);

            // 5. singleton

            Singleton.Instance.DoAThing();
            

        }
    }
}
