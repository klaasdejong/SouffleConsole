using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Console;

namespace SouffleConsole
{
    /* Ik gebruik een statische klasse met een statische lijst met Order-ojbecten,
     * omdat ik (nog) geen database gebruik om orders op te slaan.
     */
    static class AllOrders
    {
        static List<Order> orders = new List<Order>();
        public static List<Order> Orders { get { return orders; } }

        // Deze methode maakt het mogelijk iets aan de private orders-list toe te voegen
        public static void AddOrderToList(Order input) {
            orders.Add(input);
        }

        // Geeft order weer (ToString) of geeft waarschuwing als input invalid is.
        public static void GetOrder(string choice) {
            
            try
            {
                // RegularExpressions-bieb wordt gebruikt om int uit string te halen.
                int orderNo = Convert.ToInt32(Regex.Match(choice, @"\d+").Value);
                WriteLine(orders[orderNo].ToString());
                WriteLine("Press a key to go back");
                ReadKey();
            }
            catch
            {
                WriteLine("Not a valid input, press a key to go back");
                ReadKey();
            }
        }
    }
}