using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Workshop5_shop
{
    class Menu
    {
        public Menu(Shop shop)
        {
            Monopolowy = shop;
        }
        Shop Monopolowy;
        Product NewProduct;
        Client NewClient;

        public void PrintMenu()
        {
            Console.WriteLine("====== Welcome to the Szop =======");
            Console.WriteLine("1. Add product");
            Console.WriteLine("2. Remove product");
            Console.WriteLine("3. List of products");
            Console.WriteLine("4. Add client");
            Console.WriteLine("5. Remove client");
            Console.WriteLine("6. List of clients");
            Console.WriteLine("7. Sell item");
            Console.WriteLine("8. Quit program");
        }

        public void SelectMenu()
        {
            string UserChoice = Console.ReadLine();

            switch (UserChoice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    RemoveProduct();
                    break;
                case "3":
                    ListAddedProducts();
                    break;
                case "4":
                    AddClient();
                    break;
                case "5":
                    RemoveClients();
                    break;
                case "6":
                    ListAddedClients();
                    break;
                case "7":
                    SellItem();
                    break;
                case "8":
                    ExitProgram();
                    break;
            }

        }

        string name;
        string priceStr;
        float price;
        string availableStr;
        float available;
        string notes;
        public void AddRemainingParamsToProduct()
        {
            Console.WriteLine("Type a price of a product: ");
            priceStr = Console.ReadLine();
            price = Convert.ToInt32(priceStr);

            Console.WriteLine("Available amount of a product: ");
            availableStr = Console.ReadLine();
            available = Convert.ToInt32(availableStr);

            Product NewProduct = new Product(name, price, available, Monopolowy);

            Console.WriteLine("Notes for a product (optional): ");
            notes = Console.ReadLine();
            NewProduct.Notes = notes;

            Monopolowy.ProductList.Add(NewProduct);

            Console.WriteLine("Product added successfully! Please verify correctness on the list of products");
            PressAnyKey();
        }

        bool ProductExists = false;
        public void CheckIfProductExists()
        {
            foreach (Product product in Monopolowy.ProductList)
            {
                if (name == product.Name)
                {
                    ProductExists = true;
                }
            }
        }
        public void AddProduct()
        {
            
            Console.WriteLine("Type a name of a product: ");
            name = Console.ReadLine();

            if (Monopolowy.ProductList.Count != 0)
            {
                CheckIfProductExists();

                if (ProductExists == true)
                {
                    Console.WriteLine("Product with given name already exists");
                    ProductExists = false;
                    PressAnyKey();
                }
                else
                {
                    AddRemainingParamsToProduct();
                }
            }
            else
            {
                AddRemainingParamsToProduct();
            }
        }
                

        public void RemoveProduct()
        {
            string RemProduct;

            if (Monopolowy.ProductList.Count != 0)
            {
                Console.WriteLine("Type a name of a product to be removed: ");
                RemProduct = Console.ReadLine();
                int RemCounter = 0;

                foreach (Product item in Monopolowy.ProductList)
                {
                    if (item.Name == RemProduct)
                    {
                        Monopolowy.ProductList.Remove(item);
                        Console.WriteLine("Product successfully removed from the list!");
                        RemCounter += 1;
                        PressAnyKey();
                        break;
                    }
                }
                if (RemCounter < 1)
                {
                    Console.WriteLine($"Product with name '{RemProduct}' is not on the list. Please verify the list and try again.");
                    PressAnyKey();
                }
            }
            else
            {
                Console.WriteLine("List is empty, nothing to remove");
                PressAnyKey();
            }

        }

        public void ListAddedProducts()
        {
            if (Monopolowy.ProductList.Count != 0)
            {
                foreach (Product item in Monopolowy.ProductList)
                {
                    Console.WriteLine($"Product: {item.Name}; Price: {item.Price}; Avaliable: {item.AmountAvailable}; Notes: {item.Notes}");
                }
            }
            else Console.WriteLine("List is empty");
            Console.WriteLine("Press ESC for main menu");
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
        }

        string Name;
        string CashAmountStr;
        float CashAmount;
        public void AddAvailableAmountToClient()
        {
            do
            {
                try
                {
                    Console.WriteLine("Type a cash amount available for a client (must be greater than 0): ");
                    CashAmountStr = Console.ReadLine();
                    CashAmount = Convert.ToInt32(CashAmountStr);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Value must be a number");
                }
            }
            while (CashAmount <= 0);

            Client NewClient = new Client(Name, CashAmount, Monopolowy, NewProduct);

            Monopolowy.ClientList.Add(NewClient);

            Console.WriteLine("Client added successfully! Please verify correctness on the clients list");
            PressAnyKey();
        }

        public bool ClientExists = false;
        public void CheckIfClientExists()
        {
            foreach (Client client in Monopolowy.ClientList)
            {
                if (Name == client.Name)
                {
                    ClientExists = true;
                }
            }
        }

        public void AddClient()
        {
            Console.WriteLine("Type a name of a client: ");
            Name = Console.ReadLine();

            if (Monopolowy.ClientList.Count != 0)
            {
                CheckIfProductExists();

                if (ClientExists == true)
                    {
                    Console.WriteLine("Client with given name already exists");
                    PressAnyKey();
                }
                else
                {
                    AddAvailableAmountToClient();
                }
            }
            else
            {
                AddAvailableAmountToClient();
            }
        }

        public void RemoveClients()
        {
            string RemClient;

            if (Monopolowy.ClientList.Count != 0)
            {
                Console.WriteLine("Type a name of a client to be removed: ");
                RemClient = Console.ReadLine();
                int RemCounter = 0;

                foreach (Client item in Monopolowy.ClientList)
                {
                    if (item.Name == RemClient)
                    {
                        Monopolowy.ClientList.Remove(item);
                        RemCounter += 1;
                        Console.WriteLine("Client removed successfully.");
                        PressAnyKey();
                        break;
                    }
                }
                if (RemCounter < 1)
                {
                    Console.WriteLine($"Client with name '{RemClient}' is not on the list. Please verify the list and try again.");
                    PressAnyKey();
                }
            }
            else
            {
                Console.WriteLine("Nothing to remove.");
                PressAnyKey();
            }
        }


        public void ListAddedClients()
        {
            if (Monopolowy.ClientList.Count != 0)
            {
                foreach (Client item in Monopolowy.ClientList)
                {
                    Console.WriteLine($"Client: {item.Name}; Cash available: {item.CashAmount}");
                    Console.WriteLine("Bought products:");
                    if (item.BoughtProducts.Count != 0)
                    {
                        foreach (Product product in item.BoughtProducts)
                        {
                            Console.WriteLine(product.Name);
                        }
                    }
                        
                }
            }
            else Console.WriteLine("List is empty");
            Console.WriteLine("Press ESC for main menu");
            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
        }


        public void ListAvailableClients()
        {
            int ClientCounter = 1;

            Console.WriteLine("List of available clients: ");
            if (Monopolowy.ClientList.Count != 0)
            {
                foreach (Client item in Monopolowy.ClientList)
                {
                    Console.WriteLine($"{ClientCounter}. Client: {item.Name}; Cash available: {item.CashAmount}");
                    ClientCounter++;
                }
            }
            else
            {
                Console.WriteLine("List is empty");
            }
            Console.WriteLine(Environment.NewLine);
        }


        public void ListAvailableProducts()
        {
            int ProductCounter = 1;
            Console.WriteLine("List of available products: ");
            if (Monopolowy.ProductList.Count != 0)
            {
                foreach (Product item in Monopolowy.ProductList)
                {
                    Console.WriteLine($"{ProductCounter}. Product: {item.Name}; Price: {item.Price}; Avaliable: {item.AmountAvailable}; Notes: {item.Notes}");
                    ProductCounter++;
                }
            }
            else
            {
                Console.WriteLine("List is empty");
            }
            Console.WriteLine(Environment.NewLine);
        }


        public void SellItem()
        {
            ListAvailableClients();
            ListAvailableProducts();
            if (Monopolowy.ClientList.Count != 0 && Monopolowy.ProductList.Count != 0)
            {
                SelectClient();
                SelectProduct();
            }
            else
            {
                Console.WriteLine("--- You need to have at least one client and one product to proceed with any transaction ---");
                Console.WriteLine("------- Please verify client and product lists from main menu and add missing items --------");
                PressAnyKey();
            }
        }

        int ClientIndex;
        int? SelectedClient;
        public void SelectClient()
        {
            string SelectedClientStr;
            SelectedClient = null;
            int SelectedClientIndex;

            while (SelectedClient == null)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Select number of a client from above list you want to trade with: ");
                    SelectedClientStr = Console.ReadLine();
                    SelectedClient = Convert.ToInt32(SelectedClientStr);
                    SelectedClientIndex = Convert.ToInt32(SelectedClientStr);
                    ClientIndex = Convert.ToInt32(SelectedClientStr) -1;
                    try
                    {
                        Console.WriteLine($"Confirm client: {Monopolowy.ClientList[Convert.ToInt32(SelectedClient) - 1].Name} (y - Yes; n - No)");
                        ConfirmClient();
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Client with provided number does not exist");
                        SelectedClient = null;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Input value must be a number");
                }
            }
        }

        int? SelectedProduct;
        string SelectedProductStr;
        int SelectedProductIndex;
        int ProductIndex;

        public void SelectProduct()
        {
            SelectedProduct = null;
            while (SelectedProduct == null)
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine($"Select number of a product from above list you want to sell to a client: ");
                    SelectedProductStr = Console.ReadLine();
                    SelectedProduct = Convert.ToInt32(SelectedProductStr);
                    SelectedProductIndex = Convert.ToInt32(SelectedProductStr);
                    ProductIndex = SelectedProductIndex - 1;

                    if (Monopolowy.ProductList[ProductIndex].AmountAvailable > 0)
                    {
                        if (Monopolowy.ProductList[ProductIndex].Price <= Monopolowy.ClientList[ClientIndex].CashAmount)
                        {
                            try
                            {
                                Console.WriteLine($"Confirm product: {Monopolowy.ProductList[Convert.ToInt32(SelectedProduct) - 1].Name} (y - Yes; n - No)");
                                ConfirmProduct();
                                if (SelectedProduct != null)
                                {
                                    PutProductToBasket(ClientIndex, Monopolowy.ProductList[ProductIndex]);
                                    DecreaseProduct(ProductIndex);
                                    ReduceCashAmount(ClientIndex, ProductIndex);
                                }
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Product with provided number does not exist");
                                SelectedProduct = null;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Client does not have enough cash to purchase this product");
                            PressAnyKey();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Product currently not available");
                        PressAnyKey();
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Input value must be a number");
                }
            }
                    
        }


        public void DecreaseProduct(int prodIndex)
        {
            Monopolowy.ProductList[prodIndex].AmountAvailable--;
        }

        public void PutProductToBasket(int clientIndex, Product product)
        {
            Monopolowy.ClientList[clientIndex].BoughtProducts.Add(product);
        }

        public void ReduceCashAmount(int clientIndex, int prodIndex)
        {
            Monopolowy.ClientList[clientIndex].CashAmount -= Monopolowy.ProductList[prodIndex].Price;
        }


        public void ExitProgram()
        {
            Console.WriteLine("Are you sure want to quit?");
            Console.WriteLine("y - Yes; n - No");
            char key;

            while (true)
            {
                key = Console.ReadKey().KeyChar; 

                if (key.Equals('y'))
                {
                    Environment.Exit(0);
                }
                else if (key.Equals('n'))
                {
                    return;
                }
            }
            

        }


        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ConfirmClient()
        {
            char key;

            while (true)
            {
                key = Console.ReadKey().KeyChar;

                if (key.Equals('y'))
                {
                    return;
                }
                else if (key.Equals('n'))
                {
                    SelectedClient = null;
                    break;
                }
            }
        }

        public void ConfirmProduct()
        {
            char key;

            while (true)
            {
                key = Console.ReadKey().KeyChar;

                if (key.Equals('y'))
                {
                    return;
                }
                else if (key.Equals('n'))
                {
                    SelectedProduct = null;
                    break;
                }
            }
        }

    }
    }

