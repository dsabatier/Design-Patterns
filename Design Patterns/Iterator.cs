using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Iterator pattern allows you to provide access to elements of an object
/// sequentially without exposing its underlying implementation.
/// 
/// The benefit being that once 
/// </summary>
namespace Design_Patterns.Iterator
{
    // AbstractIterator
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
        T Current();
    }

    // ConcreteIterator
    public class LootIterator : IIterator<Loot>
    {
        private int _index = 0;

        private Loot[] _loots;

        public LootIterator(Loot[] loots)
        {
            _loots = loots;

        }
        public Loot Current()
        {
            return _loots[_index];
        }

        public bool HasNext()
        {
            return _index < _loots.Length - 1;
        }

        public Loot Next()
        {
            return _loots[++_index];
        }
    }

   
    // AbstractAggregate
    public interface IBag<Loot>
    {
        IIterator<Loot> GetIterator();
    }


    // ConcreteAggregate
    public class GoldBag : IBag<Loot>
    {
        private int _quantity;
        private Loot[] _loots;

        public GoldBag(int quantity, bool guaranteeMaxReward)
        {
            _quantity = quantity;

            _loots = new Loot[_quantity];

            int index = 0;
            if(guaranteeMaxReward)
            {
                _loots[index++] = new GoldLoot(100);
            }

            Random random = new Random(1000);
            while(index < _loots.Length)
                _loots[index++] = new GoldLoot(random.Next(1, 100));

        }

        public IIterator<Loot> GetIterator()
        {
            return new LootIterator(_loots);
        }
    }

    // ConcreteAggregate
    public class EquipmentBag : IBag<Loot>
    {
        private Loot[] _loots;

        public EquipmentBag(EquipmentLoot[] loot)
        {
            _loots = loot;
        }

        public IIterator<Loot> GetIterator()
        {
            return new LootIterator(_loots);
        }
    }

    public abstract class Loot
    {
        public abstract void Open();
    }

    public class GoldLoot : Loot
    {
        public int Value { get; private set; }
        public GoldLoot(int value) 
        {
            Value = value;
        }

        public override void Open()
        {
            Console.WriteLine($"Got {Value} gold!");
        }
    }

    public class EquipmentLoot : Loot
    {
        public string Name { get; private set; }
        public EquipmentLoot(string name)
        {
            Name = name;
        }

        public override void Open()
        {
            Console.WriteLine($"Got a {Name}!");
        }
    }


}
