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
    public class Program
    {
        public static void Main(string[] args)
        {
            Cart cart = new Cart();

            while (true)
            {
                ShowMenu();

                if (cart.Items.Count > 0) { cart.ToString(); }

                string choice = GetInput();

                ProcessInput(choice);

                Console.Clear();
            }

            void ShowMenu()
            {
                /* De WriteLine-methode gebruikt @ om aan te geven dat het volgende letterlijk
                 * genomen moet worden (verbatim string literal). Dit zorgt er voor de de newline
                 * gebruikt kan worden. Dat is net wat makkelijker dan iedere keer /n gebruiken,
                 * of meerdere keren WriteLine te gebruiken.
                 * Daaronder roep ik de ToString() methode voor cartMenu aan in de Menu klasse.
                 */
                Menu cartMenu = new Menu();
                WriteLine(@"What would you like to order?

                Enter 'ready' to finish your order
                Enter 'clear' to clear your order
                Enter 'r' + <number of item> to remove and item
                Enter 'o' + <number of previous order> to retrieve previous order
                ");
                WriteLine(cartMenu.ToString());
                WriteLine();
                WriteLine($"{cartMenu.Items.Count} items on the menu");
            }

            string GetInput()
            {
                string choice = Console.ReadLine();
                return choice;
                //Will catch if choice cannot be converted to int
            }

            void ProcessInput(string choice)
            {
                try
                {
                    cart.AddItem(Convert.ToInt32(choice));
                }
                catch
                {
                    switch (choice)
                    {
                        case "Ready":
                        case "READY":
                        case "ready":
                            if (cart.Items.Count > 0)
                            {
                                Cart.SubmitOrder(cart);//will trigger OrderOverView to be displayed on the screen
                                WriteLine("Press any key  to go back");
                                ReadKey();
                            }
                            else
                            {
                                WriteLine("Add some items first");
                                ReadKey();
                            }
                            break;
                        case "Clear":
                        case "CLEAR":
                        case "clear": cart.ClearAll(); break;
                        default:
                            if (choice.StartsWith("r") || choice.StartsWith("R"))
                            {
                                cart.RemoveItem(Convert.ToInt32(choice));
                            }
                            else if (choice.StartsWith("o") || choice.StartsWith("O"))
                            {
                                AllOrders.GetOrder(choice);
                            }
                            break;
                    }
                }
                /*
                void RequestPrevious(string orderId)
                {
                    try
                    {
                        int orderIdInt = Convert.ToInt32(Regex.Match(orderId, @"\d+").Value) - 1;
                        Order result = Order.GetPrevious(orderIdInt);
                        ArrayList orderItems = result.OrderItems;

                        WriteLine($"This is your order number {orderIdInt}");
                        // slow way to do this 
                        int itemIndex = 1;
                        foreach (Drink drinkItem in result.OrderItems)
                        {
                            WriteLine($"{itemIndex} for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
                            itemIndex++;
                        }
                        //Fast way to do this:
                        /
                        for (int i = 0; i < result.OrderItems.Count; i++)
                        {
                            WriteLine($"{i + 1} for {((Drink)orderItems[i]).DrinkName} (${((Drink)orderItems[i]).DrinkPrice})"); // Increments by 1 for readability in UI                
                        }
                        ReadKey();
                    }
                    catch
                    {
                        WriteLine("Invalid input");
                        ReadKey();
                    }
                }
                */
              
            }
              
        }
    }

}
 