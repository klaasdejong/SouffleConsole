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
        public static ArrayList OrderArray { get { return orderArray; } }        

        public Order(ArrayList inputOrder)
        {
            this.orderItems = inputOrder;
            billTotal = OrderTotal(orderItems);            
            this.orderId = ++numberOfOrders;
            numberOfOrders++;
            orderArray.Add(this);
        }

        double OrderTotal(ArrayList inputArrayList) 
        {
            // need to assign total before for loop, because the loop may never run
            double total = 0;
            for (int i = 0; i < orderItems.Count; i++) {
                //Cast inputArrayList to object Drink to access properties
                total += ((Drink)inputArrayList[i]).DrinkPrice;                
            }
            return total;
        }



    }
}

      