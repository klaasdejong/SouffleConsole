using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouffleConsole
{
    /* Hier wordt een abstracte klasse Product gebruikt omdat een Product niet geinstantieerd dient te worden.
     * Ieder product is ofwel een Drink of een Food.
     */
    abstract class Product
    {
        int id;
        public int Id { get { return id; } }

        string name;
        public string Name { get { return name; } }

        /* price is een decimal en niet een double/float omdat dit niet aangeraden wordt.
         * Een float met een getal achter de komma wordt in binary opgeslagen als een benadering
         * van de waarde die het representeert. Als je met floats meerdere repetatieve berekeningen (* of /)
         * gaat doen kan het voorkomen dat je met afrondingsfouten te maken krijgt. Over het algemeen wordt
         * data type Decimal aangeraden voor simpele toepassingen, maar er zijn ook libraries die je kunt gebruiken.
         * Uitleg: https://dzone.com/articles/never-use-float-and-double-for-monetary-calculatio
         */
        decimal price;
        public decimal Price { get { return price; } }

        static int numberOfProducts = 0;

        /* Omdat Food en Drink overerven van Product, maar ze wel gedeelde eigenschappen hebben (zoals naam, id, prijs)
         * gebruik ik hieronder een constructor in deze abstracte klasse. De constructor niet public maar protected.
         * Er is geen noodzaak om bij deze constructor te komen behalve als het via de constructor van de overervende
         * klassen Drink en Food gaat.
         */
        protected Product(string aName, decimal aPrice) {
            this.name = aName;
            this.price = aPrice;
            this.id = numberOfProducts;
            numberOfProducts++;
        }
    }
}
