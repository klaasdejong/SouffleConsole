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

        //Lijst items bevat de producten in de order.
        List<Product> orderedProducts = new List<Product>();
        public List<Product> OrderedProducts { get { return orderedProducts; } }

        public Order(Cart cart) {
            id = AllOrders.Orders.Count; // Nieuwe order krijgt zelfde Id als index Allorders.orders
            total = cart.CartTotal(); // Nieuwe order bewaart het totaal
            orderedProducts = cart.Items.ToList(); // voegt de items uit de cart toe aan de order
            AllOrders.AddOrderToList(this); // voegt de order toe aan de AllOrder.orders-lijst
        } 

        public override string ToString()
        {
            String str = "\nYour order:";

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
                    from x in orderedProducts // voor alle items (x) in items
                    group x by x into g // groepeer alle unieke items in g
                    let countOc = g.Count() // definieert countOC (hoevaak een item voorkomt)
                    orderby countOc descending // zet in volgorde van hoeveelheid
                    select new { Value = g.Key, Count = countOc };
            // Loopt door alle unieke items heen en voegt ze toe aan string.
            foreach (var x in distinctItems)
            {
                str += $"\n{x.Count}x  an order of {x.Value}";
            }
            // Voegt totaal toe aan de string.
            str += $"\n--------------\nTotal: {Currency.CentsToWhole(total)}";
            return str;
        }
    }
}