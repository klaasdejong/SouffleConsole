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
            /* Zonder het zetten van de encoding naar bijv. UTF8 zullen eurotekens als vraagtekens
             * weergegeven worden
             */
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            /* Creëert een nieuwe Cart. Dit is ook de enige Cart die gebruikt wordt in de applicatie.
             * Zals je in de constructor van de klasse Cart kan zien creëert de Cart op zijn beurt een
             * Menu. Het Menu creëert op zijn beurt weer Drinks en Foods (die erven van Product).
             * Deze producten kunnen uiteindelijk in de cart belanden, en als Order in AllOrders
             * opgeslagen worden, zoals ik daar in de comments ook beschrijf.
             */
            Cart cart = new Cart();

            // While (true) is een infinite loop die de basis vormt voor de applicatie.
            while (true)
            {
                ShowMenu(); // laat menu zien

                cart.ToString(); // laat items in winkelwagentje zien zien
                
                string choice = GetInput(); // haalt de keuze van de gebruiker op

                ProcessInput(choice); // verwerkt keuze van de gebruiker

                Clear(); // leegt de console zodat het scherm weer leeg is
            }

            /* ShowMenu() doet:
             * 1. Laat wat text zien met vragen/instructies
             * 2. Laat het menu van het cart-object zien cart.cartMenu.ToString());
             * 3. Laat zien hoeveel items er op de lijst staan.
             * 4. Laat de items in het winkelwagentje zien via cart.ToString()
             */
            void ShowMenu()
            {
                /* De WriteLine-methode gebruikt @ om aan te geven dat het volgende letterlijk
                 * genomen moet worden (verbatim string literal). Dit zorgt er voor de de newline
                 * gebruikt kan worden. Dat is net wat makkelijker dan iedere keer /n gebruiken,
                 * of meerdere keren WriteLine te gebruiken.
                 */
                WriteLine(@"What would you like to order?

Enter 'ready' to finish your order
Enter 'clear' to clear your order
Enter 'o' + <number of previous order> to retrieve previous order
                ");

                WriteLine(cart.cartMenu.ToString());// Laat het menu zien 
                WriteLine();
                if (cart.Items.Count > 0) {
                    WriteLine($"{cart.Items.Count} ordered");
                    WriteLine();
                    WriteLine(cart.ToString());
                } // Als er items in het winkelwagentje zitten wordt dit ook getoond
            }

            // GetInput() spreekt voor zich. Het haalt een user-inputop via de console command line en returnt het als string
            string GetInput()
            {
                return Console.ReadLine();
            }

            /* ProcessInput() gebruikt try-catch om er voor te zorgen dat de applicatie verder gaat als er geen cijfer ingevoerd
             * wordt.
             * 
             * De code in het try-block zal een error geven als er de input niet omgezet kan worden in een Int. Als het omgezet kan
             * worden in een int zal alleen de code uit het try-block uitgevoerd worden.
             * 
             * Wanneer er een error terugkomt wordt het catch-blok uitegevoerd. Dit zal het geval zijn als er letters in de input-
             * string staan. 
             */
            void ProcessInput(string choice)
            {
                try 
                {
                    if (System.Convert.ToInt32(choice)  < 0 || System.Convert.ToInt32(choice) > (cart.cartMenu.Items.Count - 1))
                    {
                        WriteLine("Choose a number between 0 and {0} ", cart.cartMenu.Items.Count - 1);
                        WriteLine("Hit enter to refresh the screen.");
                        ReadKey();
                    } else { cart.AddItem(System.Convert.ToInt32(choice)); }
                    /* valideert of de input gelijk is aan de range van het menu. Als het buiten de range is krijg je hierover een
                     * Melding. Als hij binnen de range is weten we dat het item aan het winkelwagentje toegevoegd kan worden
                     */
                }
                catch
                {
                    // Switch wordt gebruikt om aantal verwachte inputs te verwerken, zoals ready en clear, in 3 spellings-varianten.
                    switch (choice)
                    {
                        case "Ready":
                        case "READY":
                        case "ready":
                            if (cart.Items.Count > 0)
                            {
                                cart.SubmitOrder();//will trigger OrderOverView to be displayed on the screen
                                cart.ClearAll();
                            }
                            else
                            {
                                WriteLine("Add some items first");
                                ReadKey();
                            } // Als er items in de cart zitten wordt Cart.SubmitOrder(cart) aangeroepen die de cart omzet in een order
                            break; // als er een match is geweest breekt hij hier uit de switch.
                        case "Clear":
                        case "CLEAR":
                        case "clear": cart.ClearAll(); break; // Maakt cart leeg. Als er een match is geweest breekt hij hier uit de switch.
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
                            /* default wordt uitgevoerd als er geen eerdere match is gemaakt is. Eventuele errors worden afgehandeld
                             * in RemoveItem en GetOrder via een try-catch.
                             */
                    }
                }           
            }
        }
    }
}