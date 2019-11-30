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

        public static void mainWaiter() {

            ShowMenu();

            if (orderedItemArrayList.Count > 0) {ShowCurrentOrder();}

            GetOrder();

        }

        public static void GetOrder()
        {
            string choice = Console.ReadLine();

            try
            {
                int choiceInt = Convert.ToInt32(choice) - 1; // Decrements by 1 to correct for + 1 in UI
                orderedItemArrayList.Add(drinkItemArray[choiceInt]);
            }
            catch { 
                
            }

            if (Regex.IsMatch(choice, @"^\d+$") {  }
            elseif 

            switch (choice) { 
                case  { }
            }
            case 
        }

        public static void ShowCurrentOrder()
        {
            
        }

        public static void AddItem()
        {

        }

        public static void RemoveItem()
        {

        }

        public static void ShowMenu()
        {
            ArrayList drinkItemArray = Menu.Create();

            WriteLine("What would you like to order?");
            WriteLine("Enter 'ready' to finish your order");
            WriteLine("Optionally type 'r' + the ordered item, like so: r1, to remove ordered item 1 ");
            WriteLine();
            WriteLine($"{drinkItemArray.Count} items on the menu");
            WriteLine();

            foreach (Drink drinkItem in drinkItemArray)
            {
                WriteLine($"{drinkItemArray.IndexOf(drinkItem) + 1}. for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
            }
        }

        public static void ConfirmOrder(int orderId) 
        {
        Order order = FetchOrder(orderId);
            
        WriteLine($"This is your order number {orderId}: ");
        foreach (Drink item in order.OrderItems)
        {
            WriteLine($", {item.DrinkName}, ${item.DrinkPrice}");
        }
            WriteLine($"Total: {order.BillTotal}");
        }
        /* The preliminary total should be calculated through a method, not in the spaghetti
         * 
         * Below is a copy of the OrderTotal method of Order()
        double PreliminaryTotal(ArrayList inputArrayList)
        {
            // need to assign total before for loop, because the loop may never run
            double total = 0;
            for (int i = 0; i < .Count; i++)
            {
                //Cast inputArrayList to object Drink to access properties
                total += ((Drink)inputArrayList[i]).DrinkPrice;
            }
            return total;
        }
        */
        public static int SubmitOrder(ArrayList inputArrayList) 
        {
            int orderId = Order.NumberOfOrders; //or add ++???
            new Order(inputArrayList);
            return orderId;
        }

        public static Order FetchOrder(int orderId) {
            Order result = (Order)Order.OrderArray[orderId];
            return result;
            
        }
    }
}
