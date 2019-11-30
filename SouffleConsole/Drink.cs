using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouffleConsole
{
    public class Drink
    {
        string drinkName;
        public string DrinkName { get { return drinkName; } }

        double drinkPrice;
        public double DrinkPrice { get { return drinkPrice; } }

        static int numberOfDrinks = 0;
        public static int NumberOfDrinks { get { return numberOfDrinks; } }

        int drinkId;
        public int DrinkId { get { return drinkId; } }

        public Drink(string aDrinkName, double aDrinkPrice)
        {
            drinkName = aDrinkName;
            drinkPrice = aDrinkPrice;
            drinkId = ++numberOfDrinks;
            numberOfDrinks++;
        }
    }
}