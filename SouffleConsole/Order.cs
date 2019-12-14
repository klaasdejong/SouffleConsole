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

        Cart sessionCart;
        public Cart SessionCart { get { return sessionCart; } }
       
        public Order(Cart cart) {
            id = AllOrders.Orders.Count;
            total = cart.CartTotal();
            sessionCart = cart;
            AllOrders.addOrderToList(this);
        } 

        public override string ToString()
        {
            String str = "Your order:";

            var timesOrdered =
                    from x in sessionCart.Items
                    group x by x into g
                    let countOc = g.Count()
                    orderby countOc descending
                    select new { Value = g.Key, Count = countOc };

            foreach (var x in timesOrdered)
            {
                str += $"\n{x.Count}x  an order of {x.Value}";
            }
            str += $"\n--------------\nTotal: {Currency.CentsToWhole(total)}";


            return str;
        }
    }
}