using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;

// Waiter is a class that could largely be replaced by a GUI at a later stage, but it does implement some logic that would need to move

namespace SouffleConsole
{
    static class Waiter
    {
        static Cart cart = new Cart();

        static ArrayList drinkItemArray = Menu.Create();

        public static void MainWaiter()
        {
            while (true)
            {
                ShowMenu();

                if (cart.cartItems.Count > 0) { ShowCurrentOrder(); }

                string choice = GetInput();

                ProcessInput(choice);

                Console.Clear();
            }
        }

        public static string GetInput()
        {
            string choice = Console.ReadLine();
            return choice;
            //Will catch if choice cannot be converted to int
           
        }

        public static void ProcessInput(string choice) {
            try
            {
                AddItem(Convert.ToInt32(choice) - 1); // Decrements by 1 to correct for + 1 in UI
            }
            catch
            {
                switch (choice)
                {
                    case "Ready":
                    case "READY":
                    case "ready":
                        if (cart.cartItems.Count > 0)
                        {
                            int orderId = SubmitOrder(cart.cartItems);//will trigger OrderOverView to be displayed on the screen
                            WriteLine($"Your order Id is: {orderId + 1}");
                            WriteLine("Press any key  to go back");
                            ReadKey();
                        }
                        else
                        {
                            WriteLine("Add some items first");
                            ReadKey();
                        }
                        break;
                    case "Clear":
                    case "CLEAR":
                    case "clear": cart.cartItems.Clear(); break;                    
                    default:
                        if (choice.StartsWith("r") || choice.StartsWith("R"))
                        {
                            RemoveItem(choice);
                        }
                        else if (choice.StartsWith("o") || choice.StartsWith("O")) {
                            RequestPrevious(choice);
                        }
                        break;
                }
            }
        }

        public static void ShowCurrentOrder() // Similar to Order.OrderOverView, but doesn't require orderId
        {
            double orderTotal = Order.OrderTotal(cart.cartItems);
            int itemIndex = 1;
            WriteLine($"{cart.cartItems.Count} items ordered: ");
            WriteLine("");
            foreach (Drink drinkItem in cart.cartItems)
            {
                WriteLine($"{itemIndex} for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
                itemIndex++;
            }
            WriteLine("Total: ${0}", orderTotal);

        }

        public static void AddItem(int choiceInt)
        {
            cart.cartItems.Add(drinkItemArray[choiceInt]);
        }

        public static void RemoveItem(string itemToRemove)
        {
            try
            {
                int index = Convert.ToInt32(Regex.Match(itemToRemove, @"\d+").Value) - 1;// Decrements by 1 to correct for + 1 in UI
                if (index < cart.cartItems.Count && index >= 0)
                {
                    string thisDrinkname = ((Drink)cart.cartItems[index]).DrinkName;
                    double thisDrinkPrice = ((Drink)cart.cartItems[index]).DrinkPrice;
                    WriteLine($"{0} removed, {1} deducted from the total", thisDrinkname, thisDrinkPrice);
                    cart.cartItems.RemoveAt(index);
                }
                else { WriteLine($"Item {Regex.Match(itemToRemove, @"\d+").Value} does not exist"); ReadKey(); }
            }
            catch {
                WriteLine($"{itemToRemove} is an invalid input");
                ReadKey();
            }
        }

        public static void ShowMenu()
        {
            ArrayList drinkItemArray = Menu.Create();

            WriteLine("What would you like to order?");
            WriteLine("Enter 'ready' to finish your order");
            WriteLine("Enter 'clear' to clear your order");
            WriteLine("Enter 'r' + <number of item> to remove and item");
            WriteLine("Enter 'o' + <number of previous order> to retrieve previous order");
            WriteLine("");
            foreach (Drink drinkItem in drinkItemArray)
            {
                WriteLine($"{drinkItemArray.IndexOf(drinkItem) + 1}. for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
            }
            WriteLine();
            WriteLine($"{drinkItemArray.Count} items on the menu");
            WriteLine();
        }
                
        public static int SubmitOrder(ArrayList cartItems)
        {
            int orderId = Order.NumberOfOrders; //or add ++???
            _ = new Order(cartItems);
            cart.cartItems.Clear();
            return orderId;            
        }
        
        public static void RequestPrevious(string orderId)
        {
            try
            {
                int orderIdInt = Convert.ToInt32(Regex.Match(orderId, @"\d+").Value) - 1;
                Order result = Order.GetPrevious(orderIdInt);
                ArrayList orderItems = result.OrderItems;

                WriteLine($"This is your order number {orderId}");
                /* slow way to do this
                int itemIndex = 1;
                foreach (Drink drinkItem in result.OrderItems)             
                {
                    WriteLine($"{itemIndex} for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
                    itemIndex++;
                }
                Fast way to do this: */

                for (int i = 0; i < result.OrderItems.Count; i++)
                {
                    WriteLine($"{i + 1} for {((Drink)orderItems[i]).DrinkName} (${((Drink)orderItems[i]).DrinkPrice})"); // Increments by 1 for readability in UI                
                }
                ReadKey();
            }
            catch {
                WriteLine("Invalid input");
                ReadKey();
            }
        }        
    }
}