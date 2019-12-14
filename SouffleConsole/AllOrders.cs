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

        public static void GetOrder(string choice) {
            
            try
            {
                int orderNo = Convert.ToInt32(Regex.Match(choice, @"\d+").Value);
                WriteLine("Order number {0}", choice);
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