using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SouffleConsole
{
    /* Ik gebruik een statische klasse met een statische lijst met Order-ojbecten,
     * omdat ik (nog) geen database gebruik om orders op te slaan
     */
    static class AllOrders
    {
        static List<Order> orders = new List<Order>();
        public static List<Order> Orders { get { return orders; } }

        // Deze methode maakt het mogelijk iets aan de private orders-list toe te voegen
        public static void addOrderToList(Order input) {
            orders.Add(input);
        }

        public static Order GetOrder(string choice) {
            int choiceInt = Convert.ToInt32(Regex.Match(choice, @"\d+").Value);
            Order toReturn = orders[choiceInt];
            return toReturn;
        }
    }
}