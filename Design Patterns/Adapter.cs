using System;
using System.Collections.Generic;

/// <summary>
/// The adapter pattern lets us convert one interface into another
/// </summary>
namespace Design_Patterns.Adapter
{
    public interface IShopItem
    {
        void Buy();
    }

    public interface IPurchasableProduct
    {
        void Purchase();
    }

    public class OurShopItem : IShopItem
    {
        public void Buy()
        {
            Console.WriteLine("Bought item!");
        }
    }

    public class NewVendorProduct : IPurchasableProduct
    {
        public void Purchase()
        {
            Console.WriteLine("Purchased a product!");
        }
    }

    public class NewVendorProductAdapter : IShopItem
    {
        private IPurchasableProduct _product;
        public NewVendorProductAdapter(NewVendorProduct product)
        {
            _product = product;
        }

        public void Buy()
        {
            _product.Purchase();
        }
    }

    public class Shop
    {
        private List<IShopItem> _items = new List<IShopItem>();
        public void AddToCart(IShopItem item)
        {
            _items.Add(item);
        }

        public void Checkout()
        {
            foreach (IShopItem item in _items)
                item.Buy();
        }
    }

}
