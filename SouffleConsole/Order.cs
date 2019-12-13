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
        int id;
        public int Id { get { return id; } }

        decimal total;
        public decimal Total { get { return total; } }

        Cart sessionCart;
        public Cart SessionCart { get { return sessionCart; } }
       
        public Order(Cart cart) {
            id = AllOrders.Orders.Count;
            total = cart.cartTotal();
            sessionCart = cart;
            AllOrders.addOrderToList(this);
        } 

        public override string ToString()
        {
            List<string> items = new List<string>();

            foreach (Drink item in sessionCart.Items) { items.Add(item.ToString()); }

            return string.Format("Order {0}, order total: {1}, contains: {2}", id, total, items);
        }

        //ArrayList orderItems;
        //public ArrayList OrderItems { get { return orderItems; } }



        //static
        //static int numberOfOrders = 0;
        //public static int NumberOfOrders { get { return numberOfOrders; } }

        //static ArrayList orderArray = new ArrayList();
        /*
        public Order(ArrayList cartItems)
        {
            orderItems = cartItems;
            billTotal = OrderTotal(orderItems);
            orderId = ++numberOfOrders;
            numberOfOrders++;
            //AddToOrderArray(this);
            orderArray.Add(this);
        }

        public static double OrderTotal(ArrayList inputArrayList)
        {
            // need to assign total before for loop, because the loop may never run
            double total = 0;
            for (int i = 0; i < inputArrayList.Count; i++)
            {
                //Cast inputArrayList to object Drink to access properties
                total += ((Drink)inputArrayList[i]).DrinkPrice;
            }
            return total;
        }

        public static void OrderOverView(ArrayList inputArrayList, int orderId)
        {
            double orderTotal = OrderTotal(inputArrayList);
            int itemIndex = 1;
            WriteLine($"{inputArrayList.Count} items ordered ({orderId}): ");
            foreach (Drink drinkItem in inputArrayList)
            {
                WriteLine($"{itemIndex} for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
                itemIndex++;
            }
            WriteLine("Total: ${0}", orderTotal);
        }

        public static Order GetPrevious(int orderId)
        {
            Order previousOrder = ((Order)orderArray[orderId]);
            return previousOrder;
        }

        public override string ToString()
        {
            List<string> items = new List<string>();

            foreach (Drink item in orderItems) { items.Add(item.ToString()); }

            return string.Format("Order {0}, order total: {1}, contains: {2}", orderId, billTotal, items);
        }
        */
    }
}

