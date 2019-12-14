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
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Cart cart = new Cart();

            while (true)
            {
                ShowMenu();

                cart.ToString();
                
                string choice = GetInput();

                ProcessInput(choice);

                Clear();
            }

            void ShowMenu()
            {
                /* De WriteLine-methode gebruikt @ om aan te geven dat het volgende letterlijk
                 * genomen moet worden (verbatim string literal). Dit zorgt er voor de de newline
                 * gebruikt kan worden. Dat is net wat makkelijker dan iedere keer /n gebruiken,
                 * of meerdere keren WriteLine te gebruiken.
                 * Daaronder roep ik de ToString() methode voor cartMenu aan in de Menu klasse.
                 */
                //Menu cartMenu = new Menu();
                WriteLine(@"What would you like to order?

Enter 'ready' to finish your order
Enter 'clear' to clear your order
Enter 'o' + <number of previous order> to retrieve previous order
                ");
                WriteLine(cart.cartMenu.ToString());
                WriteLine();
                if (cart.Items.Count > 0) {
                    WriteLine($"{cart.Items.Count} ordered");
                    WriteLine();
                    WriteLine(cart.ToString());
                }
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
                    if (System.Convert.ToInt32(choice)  < 0 || System.Convert.ToInt32(choice) > (cart.cartMenu.Items.Count - 1)) {
                        WriteLine("Choose a number between 0 and {0} ", cart.cartMenu.Items.Count - 1);
                        WriteLine("Hit enter to refresh the screen.");
                        ReadKey();
                    } else { cart.AddItem(System.Convert.ToInt32(choice)); }
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
                                cart.ClearAll();
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
                                cart.RemoveItem(choice);
                            }
                            else if (choice.StartsWith("o") || choice.StartsWith("O"))
                            {
                                AllOrders.GetOrder(choice);
                            }
                            break;
                    }
                }

              
            }
              
        }
    }

}
 