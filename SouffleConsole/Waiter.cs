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
        static ArrayList orderedItemArrayList = new ArrayList();

        static ArrayList drinkItemArray = Menu.Create();

        public static void mainWaiter()
        {
            while (true)
            {
                ShowMenu();

                if (orderedItemArrayList.Count > 0) { ShowCurrentOrder(orderedItemArrayList); }

                GetOrder();

                Console.Clear();
            }
        }

        public static void GetOrder()
        {
            string choice = Console.ReadLine();
            //Will catch if choice cannot be converted to int
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
                        SubmitOrder(orderedItemArrayList);//will trigger OrderOverView to be displayed on the screen
                        break;
                    case "Clear":
                    case "CLEAR":
                    case "clear": orderedItemArrayList.Clear(); break;
                    default:
                        if (choice.StartsWith("r") || choice.StartsWith("R")) { RemoveItem(choice); }
                        break;
                }
            }
        }

        public static void ShowCurrentOrder(ArrayList inputArrayList) // Similar to Order.OrderOverView, but doesn't require orderId
        {
            double orderTotal = Order.OrderTotal(inputArrayList);
            int itemIndex = 1;
            WriteLine($"{inputArrayList.Count} items ordered: ");
            WriteLine("");
            foreach (Drink drinkItem in inputArrayList)
            {
                WriteLine($"{itemIndex} for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
                itemIndex++;
            }
            WriteLine("Total: ${0}", orderTotal);

        }

        public static void AddItem(int choiceInt)
        {
            orderedItemArrayList.Add(drinkItemArray[choiceInt]);
        }

        public static void RemoveItem(string itemToRemove)
        {

            int index = Convert.ToInt32(Regex.Match(itemToRemove, @"\d+").Value) - 1;// Decrements by 1 to correct for + 1 in UI
            if (index < orderedItemArrayList.Count && index >= 0)
            {
                string thisDrinkname = ((Drink)orderedItemArrayList[index]).DrinkName;
                double thisDrinkPrice = ((Drink)orderedItemArrayList[index]).DrinkPrice;
                WriteLine($"{0} removed, {1} deducted from the total", thisDrinkname, thisDrinkPrice);
                orderedItemArrayList.RemoveAt(index);
            }
            else { WriteLine($"Item {Regex.Match(itemToRemove, @"\d+").Value} does not exist"); ReadKey(); }
        }

        public static void ShowMenu()
        {
            ArrayList drinkItemArray = Menu.Create();

            WriteLine("What would you like to order?");
            WriteLine("Enter 'ready' to finish your order");
            WriteLine("Enter 'clear' to clear your order");
            WriteLine("Enter 'r' + <number of item> to remove and item");
            WriteLine("");
            foreach (Drink drinkItem in drinkItemArray)
            {
                WriteLine($"{drinkItemArray.IndexOf(drinkItem) + 1}. for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
            }
            WriteLine();
            WriteLine($"{drinkItemArray.Count} items on the menu");
            WriteLine();
        }
                
        public static int SubmitOrder(ArrayList inputArrayList)
        {
            int orderId = Order.NumberOfOrders; //or add ++???
            new Order(inputArrayList);
            return orderId;
        }
        /* Not currently used
        public static Order FetchOrder(int orderId)
        {
            Order result = (Order)Order.OrderArray[orderId];
            return result;
        }
        */
    }
}
