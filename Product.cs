using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop5_shop
{
    class Product
    {
        public Product(string name, float price, float amountavailable, Shop shop)
        {
            Monopolowy = shop;
            Name = name;
            Price = price;
            AmountAvailable = amountavailable;
        }

        Shop Monopolowy;
        public string Name;
        public string Notes;
        private float TempPrice;
        public float Price
        {
            get
            {
                return TempPrice;
            }
            set
            {
                if (value > 0)
                {
                    TempPrice = value;
                }
                else
                {
                    Console.WriteLine("Value of price must be positive");
                }
            }
        }

        private float TempAmountAvailable;
        public float AmountAvailable
        {
            get
            {
                return TempAmountAvailable;
            }
            set
            {
                if (value >= 0)
                {
                    TempAmountAvailable = value;
                }
            }
        }



    }
}
