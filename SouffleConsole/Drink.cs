using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouffleConsole
{
    // Drink erft de attributen en methoden van Product
    class Drink : Product
    {
        bool straw;
        public bool Straw { get { return straw; } }        

        /* De constructor hierbeneden zal eerst de base constructor aanroepen met de argumenten "aName" en "aPrice"
         * vervolgens zal deze constructor zelf uitgevoerd worden.
         * Uitleg waarom er gebruikt gemaakt wordt van een constructor in de abstracte klasse Product is ook te vinden
         * in de comment boven de constructor van die klasse.
         */
        public Drink(string aName, decimal aPrice, bool aStraw) : base(aName, aPrice)
        {
            this.straw = aStraw;
        }

        public override string ToString()
        {
            /* Omdat ik de klasse Product private attributen gebruik in combinatie met publieke getters 
             * roep ik hier het publieke attribuut (met hoofdletter) aan. Dit is nodig omdat de klasse 
             * Food geen toegang heeft tot private attributen van Product. Voor this.straw is dit niet nodig
             * omdat we in de context van Drink zitten.
             */
            return string.Format("ID: {0}, Name: {1}, Price: {2}, Straw: {3}", this.Id, this.Name, this.Price, this.straw);
        }
        /*
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

        public override string ToString() {
            return string.Format("No.{0} {1}, price: ${2}", drinkId, drinkName, drinkPrice);
        }
        */
    }
}