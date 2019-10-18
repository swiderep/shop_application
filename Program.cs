using System;

namespace Workshop5_shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop Monopolowy = new Shop();
            Menu menu = new Menu(Monopolowy);

            while (true)
            {
                menu.PrintMenu();
                menu.SelectMenu();

                Console.Clear();
            }


        }
    }
}
