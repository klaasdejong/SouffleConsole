using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SouffleConsole
{
    class Menu
    {
        List<Product> items = new List<Product>();
        public List<Product> Items { get { return items; } }

        /* Wanneer een Menu-object geinstantieerd wordt dan vult deze constructor de items-lijst
         * met nieuwe Drink- en Food-objecten. 
         */
        public Menu() {
            //Drinks:
            items.Add(new Drink("Tea", 230, false));
            items.Add(new Drink("Mint Tea", 120, false));
            items.Add(new Drink("Coffee", 250, false));
            items.Add(new Drink("Cappuccino", 280, false));
            items.Add(new Drink("Espresso", 200, false));
            items.Add(new Drink("Latte Machiatto", 270,false));
            items.Add(new Drink("Diet Coke", 120, true));
            items.Add(new Drink("Pilsner Beer", 280, false));
            items.Add(new Drink("Belgian White", 380, false));
            items.Add(new Drink("Belgian Quadruple", 450, false));
            items.Add(new Drink("White Wine", 400, false));
            items.Add(new Drink("Red Wine", 450, false));
            items.Add(new Drink("Irish Coffee", 330, false));
            //Foods:
            items.Add(new Food("Hamburger menu", 1250, false));
            items.Add(new Food("Pizza", 1200, false));
            items.Add(new Food("Soup", 550, false));
            items.Add(new Food("Steak menu", 2300, false));
            items.Add(new Food("Fish menu", 2200, false));
            items.Add(new Food("Vegan menu", 1300, false));
        }

        // Overschrijft de ToString() methode van het object.
        public override string ToString()
        {
            String str = "Menu:";

            /* Loopt door ieder item op het menu en voert ToString() uit en voegt return en een nieuwe regel
            /* to aan string str
             */

            foreach (Product item in items) {

                //if (str == null) { str = item.ToString(); } else { str += "\n" + item.ToString(); }
                str += "\n" + item.ToString();
            }
            return str;
        }

        // Haalt een product uit het menu en retourneerd het object product om in de cart te voegen.
        public Product getProductFromMenu(int choice)
        {
            Product toReturn = items[choice];
            return toReturn;
        }

        /*
        static List<Drink> menuItems;

        public Menu() { 
            menuItems = Create();
        }

        public static List<Drink> Create() {
            List<Drink> items = new List<Drink>();
            items.Add(new Drink("Tea", 2.3));
            items.Add(new Drink("Mint Tea", 1.2));
            items.Add(new Drink("Coffee", 2.5));
            items.Add(new Drink("Cappuccino", 2.8));
            items.Add(new Drink("Espresso", 2.0));
            items.Add(new Drink("Latte Machiatto", 2.7));
            items.Add(new Drink("Diet Coke", 1.2));
            items.Add(new Drink("Pilsner Beer", 2.8));
            items.Add(new Drink("Belgian White", 3.8));
            items.Add(new Drink("Belgian Quadruple", 4.5));
            items.Add(new Drink("White Wine", 4.0));
            items.Add(new Drink("Red Wine", 4.5));
            items.Add(new Drink("Irish Coffee", 3.3));
            return items;
        }

        public static Drink returnDrinkFromMenu(int choice) {
            Drink toReturn = menuItems[choice];
            return toReturn;
        }
                
        public override string ToString()
        {
            List<string> items = new List<string>();

            foreach (Drink item in menuItems) { items.Add(item.ToString()); }

            return string.Format("The menu is as follows: {0},", items);
        }
        */
    }
}
