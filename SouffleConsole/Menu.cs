using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SouffleConsole
{
    static class Menu
    {
        public static ArrayList Create() {
            ArrayList drinksArrayList = new ArrayList();
            drinksArrayList.Add(new Drink("Tea", 2.3));
            drinksArrayList.Add(new Drink("Mint Tea", 1.2));
            drinksArrayList.Add(new Drink("Coffee", 2.5));
            drinksArrayList.Add(new Drink("Cappuccino", 2.8));
            drinksArrayList.Add(new Drink("Espresso", 2.0));
            drinksArrayList.Add(new Drink("Latte Machiatto", 2.7));
            drinksArrayList.Add(new Drink("Diet Coke", 1.2));
            drinksArrayList.Add(new Drink("Pilsner Beer", 2.8));
            drinksArrayList.Add(new Drink("Belgian White", 3.8));
            drinksArrayList.Add(new Drink("Belgian Quadruple", 4.5));
            drinksArrayList.Add(new Drink("White Wine", 4.0));
            drinksArrayList.Add(new Drink("Red Wine", 4.5));
            drinksArrayList.Add(new Drink("Irish Coffee", 3.3));
            return drinksArrayList;
        } 
    }
}
