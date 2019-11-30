using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace SouffleConsole
{
    class Order
    {
        double billTotal;
        public double BillTotal { get { return billTotal; } }

        readonly ArrayList orderItems;
        public ArrayList OrderItems { get { return orderItems; } }
        
        readonly int orderId;
        public int OrderId { get { return orderId; } }

        //static
        static int numberOfOrders = 0;
        public static int NumberOfOrders { get { return numberOfOrders; } }

        static ArrayList orderArray;
        public static ArrayList OrderArray { get { return orderArray; } set { orderArray.Add(value); } }        

        public Order(ArrayList inputOrder)
        {
            this.orderItems = inputOrder;
            billTotal = OrderTotal(orderItems);            
            this.orderId = ++numberOfOrders;
            numberOfOrders++;
            orderArray.Add(this);
            OrderOverView(orderItems, orderId);
        }

        public static double OrderTotal(ArrayList inputArrayList) 
        {
            // need to assign total before for loop, because the loop may never run
            double total = 0;
            for (int i = 0; i < inputArrayList.Count; i++) {
                //Cast inputArrayList to object Drink to access properties
                total += ((Drink)inputArrayList[i]).DrinkPrice;                
            }
            return total;
        }

        public static void OrderOverView(ArrayList inputArrayList, int orderId) {
            double orderTotal = OrderTotal(inputArrayList);
            int itemIndex = 1;
            WriteLine($"{inputArrayList.Count} items ordered ({orderId}): ");
            foreach (Drink drinkItem in inputArrayList)
            {
                WriteLine($"{itemIndex} for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
                itemIndex++;
            }
            WriteLine("Total: {0}", orderTotal);
        }



    }
}

      