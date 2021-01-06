using System;

/// <summary>
/// https://www.dofactory.com/img/diagrams/net/abstract.gif
/// Abstract factory pattern provides a way to create groups of related objects without specifying their concrete classes
/// </summary>

namespace Design_Patterns.Factory
{
    // Client
    public class Spaceship
    {
        private Engine _engine;
        private Hull _hull;

        public Spaceship(ConfigurationFactory factory)
        {
            _engine = factory.CreateEngine();
            _hull = factory.CreateHull();
        }

        public void Activate()
        {
            _engine.Activate();
        }
    }

    //ConcreteFactory1
    public class AssaultConfigurationFactory : ConfigurationFactory
    {
        public override Engine CreateEngine()
        {
            return new FastEngine();
        }

        public override Hull CreateHull()
        {
            return new LightHull();
        }
    }

    //ConcreteFactory2
    public class HeavyTransportConfigurationFactory : ConfigurationFactory
    {
        public override Engine CreateEngine()
        {
            return new SlowEngine();
        }

        public override Hull CreateHull()
        {
            return new HeavyHull();
        }
    }

    //AbstractFactory
    public abstract class ConfigurationFactory
    {
        public abstract Engine CreateEngine();
        public abstract Hull CreateHull();

    }

    // ConcreteProductA1
    public class AssaultShip : Spaceship
    {
        public AssaultShip(ConfigurationFactory configurationFactory) : base(configurationFactory) { }
    }

    // ConcreteProductA2
    public class HeavyTransportShip : Spaceship
    {
        public HeavyTransportShip(ConfigurationFactory configurationFactory) : base(configurationFactory) { }
    }

    //AbstractProductA
    public abstract class Engine
    {
        public abstract void Activate();
    }

    //ConcreteProductA1
    public class SlowEngine : Engine
    {
        public override void Activate()
        {
            Console.WriteLine("We're going slow!");
        }
    }

    //ConcreteProductA1
    public class FastEngine : Engine
    {
        public override void Activate()
        {
            Console.WriteLine("We're going fast!");
        }
    }

    //AbstractProductB
    public abstract class Hull
    {

    }

    // ConcreteProductB1
    public class HeavyHull : Hull
    {

    }

    // ConcreteProductB2
    public class LightHull : Hull 
    {
        
    }




}
