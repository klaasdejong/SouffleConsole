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
        public Menu cartMenu;

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

        public void RemoveItem(string choice)
        {
            int resultInt = System.Convert.ToInt32(Regex.Match(choice, @"\d+").Value);
            
            try {
                Product toRemove = cartMenu.Items[resultInt];
                items.Remove(toRemove);
            }
            catch
            {
                WriteLine("Not a valid input, press a key to go back");
                ReadKey();
            }
        }

        public decimal CartTotal()
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
        
        /*
        public override string ToString()
        {
            return string.Format("{0}", items);
            //List<string> toStringItems = new List<string>();
            //foreach (Drink item in items) { toStringItems.Add(item.ToString()); }
            //return string.Format("Cart: Id {0}, order total: {1}, contains: {2}", id, cartTotal(), toStringItems);
        }
        */

        // Overschrijft de ToString() methode van het object.
        public override string ToString()
        {
            String str = "Your cart:";

            // Kan item.IndexOf niet gebruiken 

            var timesOrdered =
                    from x in items
                    group x by x into g
                    let countOc = g.Count()
                    orderby countOc descending
                    select new { Value = g.Key, Count = countOc };

            foreach (var x in timesOrdered) {
                str += $"\n{x.Count}x  an order of {x.Value}";
            }
            str += $"\n--------------\nTotal: {Currency.CentsToWhole(CartTotal())}\n--------------\nEnter 'r' + menu index to remove an item";


            /* Loopt door ieder item op het menu en voert ToString() uit en voegt return en een nieuwe regel
            /* to aan string str
             */

            /*
            foreach (Product item in items.Distinct())
            {   

                var timesOrdered =
                    from x in items
                    group x by x into g
                    let countOc = g.Count()
                    orderby countOc descending
                    select new { Value = g.Key, Count = countOc };

                foreach (var x in timesOrdered) { 
                    WriteLine
                }
                //if (str == null) { str = item.ToString(); } else { str += "\n" + item.ToString(); }
                str += "\n" + $"Index {index} || " + item.ToString() + $"times: {Items.Count<Product>}";
                index++;
                */        
            return str;
        }

        
    }
}