using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop5_shop
{
    class Client
    {
        public Client(string name, float cashamount, Shop shop, Product product)
        {
            Name = name;
            CashAmount = cashamount;
            Monopolowy = shop;
            NewProduct = product;
        }

        Product NewProduct;
        Shop Monopolowy;
        public string Name;
        private float TempCashAmount;
        public List<Product> BoughtProducts = new List<Product>();

        public float CashAmount
        {
            get
            {
                return TempCashAmount;
            }
            set
            {
                    TempCashAmount = value;
            }
        }
    }
}
