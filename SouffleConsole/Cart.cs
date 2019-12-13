using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;

namespace SouffleConsole
{
    class Cart
    {
        Menu cartMenu;

        int id;
        public int Id { get { return id; } }

        List<Product> items = new List<Product>();
        public List<Product> Items { get { return items; } }

        public Cart() {
            cartMenu = new Menu();
            id = 1212;
        }

        public void AddItem(int choiceInt)
        {
            items.Add(cartMenu.getProductFromMenu(choiceInt));
        }

        public void RemoveItem(int choiceInt)
        {
            items.RemoveAt(choiceInt);
        }

        public decimal cartTotal()
        {
            // need to assign total before for loop, because the loop may never run
            decimal total = 0;
            for (int i = 0; i < items.Count; i++)
            {
                //Cast inputArrayList to object Drink to access properties
                total += ((Product)items[i]).Price;
            }
            return total;
        }

        public void ClearAll() {
            items.Clear();
        }

        public static int SubmitOrder(Cart cart)
        {
            Order order = new Order(cart);
            WriteLine("Your order number is {0}", order.Id);
            return order.Id;
        }
        

        public override string ToString()
        {
            return string.Format("{0}", items);
            //List<string> toStringItems = new List<string>();
            //foreach (Drink item in items) { toStringItems.Add(item.ToString()); }
            //return string.Format("Cart: Id {0}, order total: {1}, contains: {2}", id, cartTotal(), toStringItems);
        }

        /*
        public ArrayList items = new ArrayList();

        public double OrderTotal()
        {
            // need to assign total before for loop, because the loop may never run
            double total = 0;
            for (int i = 0; i < items.Count; i++)
            {
                //Cast inputArrayList to object Drink to access properties
                total += ((Drink)items[i]).DrinkPrice;
            }
            return total;
        }

        public override string ToString()
        {
            List<string> items = new List<string>();

            foreach (string item in items) { items.Add(item.ToString()); }

            return string.Format("Cart total: {0}, cart contains: {1}", OrderTotal(), items);
        }

        public void AddItem(int choiceInt)
        {
            items.Add(Menu.returnDrinkFromMenu(choiceInt));
        }

        public void RemoveItem(string itemToRemove)
        {
            try
            {
                int index = Convert.ToInt32(Regex.Match(itemToRemove, @"\d+").Value) - 1;// Decrements by 1 to correct for + 1 in UI
                if (index < items.Count && index >= 0)
                {
                    string thisDrinkname = ((Drink)items[index]).DrinkName;
                    double thisDrinkPrice = ((Drink)items[index]).DrinkPrice;
                    WriteLine($"{0} removed, {1} deducted from the total", thisDrinkname, thisDrinkPrice);
                    items.RemoveAt(index);
                }
                else { WriteLine($"Item {Regex.Match(itemToRemove, @"\d+").Value} does not exist"); ReadKey(); }
            }
            catch
            {
                WriteLine($"{itemToRemove} is an invalid input");
                ReadKey();
            }
        }

        public static int SubmitOrder(ArrayList cart)
        {
            int orderId = Order.NumberOfOrders; //or add ++???
            _ = new Order(cart);
            cart.Clear();
            return orderId;
        }

        public void ShowCurrentOrder() // Similar to Order.OrderOverView, but doesn't require orderId
        {
            this.ToString();
        }
        */
    }

}