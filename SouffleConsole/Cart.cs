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

        // Lijst items bevat de producten in het winkelwagentje.
        List<Product> items = new List<Product>();
        public List<Product> Items { get { return items; } }

        /* Constructor maakt alleen het menu aan, want lijst items wordt pas gevuld als je iets aan
         * winkelwagen toevoegd.
         */        
        public Cart() {
            cartMenu = new Menu();
        }

        //Voegt product van het menu toe aan lijst items aan de hand van argument choiceInt
        public void AddItem(int choice)
        {
            items.Add(cartMenu.getProductFromMenu(choice));
        }


        //Verwijdert product uit de winkelwagen of geeft waarschuwing als input invalid is.
        public void RemoveItem(string choice)
        {
            // RegularExpressions-bieb wordt gebruikt om int uit string te halen.
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

        // Berekent de totale prijs van van de winkelwagen door door alle items te loopen waarde op te tellen
        public decimal CartTotal()
        {            
            decimal total = 0;
            for (int i = 0; i < items.Count; i++)
            {
                total += items[i].Price;
            }
            return total;
        }

        // Maakt het mogelijk om van buiten een cart-object de items (private) te verwijderen.
        public void ClearAll() {
            items.Clear();
        }

        // Maakt een Order aan. De Order-constructor zal vervolgens de order ook in AllOrders.orders "database" zetten.
        public void SubmitOrder()
        {
            Order order = new Order(this);
            WriteLine("Your order number is {0}", order.Id);
            WriteLine("Press a key to go back");
            ReadKey();
        }

        // Overschrijft de ToString() methode van het object.
        public override string ToString()
        {
            String str = "Your cart:";

            /* Onderstaande LINQ Query zorgt er voor dat we niet een lijst krijgen met meerdere zelfde objecten
             * maar een lijst met unieke objecten met het aantal keer dat ze besteld zijn. 
             * 
             * Dus niet:
             * Tea
             * Tea
             * Tea
             * 
             * Maar:
             * 3x an order of Tea
             */
            var distinctItems =
                    from x in items // voor alle items (x) in items
                    group x by x into g // groepeer alle unieke items in g
                    let countOc = g.Count() // definieert countOC (hoevaak een item voorkomt)
                    orderby countOc descending // zet in volgorde van hoeveelheid
                    select new { Value = g.Key, Count = countOc };
            // Loopt door alle unieke items heen en voegt ze toe aan string.
            foreach (var x in distinctItems) {
                str += $"\n{x.Count}x  an order of {x.Value}";
            }
            // Voegt totaal en instructie toe aan de string.
            str += $"\n--------------\nTotal: {Currency.CentsToWhole(CartTotal())}\n--------------\nEnter 'r' + menu index to remove an item";       
            return str;
        }
    }
}