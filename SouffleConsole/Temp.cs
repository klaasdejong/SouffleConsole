using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouffleConsole
{
    class Temp
    {
        ArrayList orderedItemArrayList = new ArrayList();
        //public ArrayList OrderedItemArrayList { get { return orderedItemArrayList; } }



        string choice;
        //public string Choice { get { return choice; } set { choice = value; } }

        bool continueOrder = true;
            //public bool ContinueOrder { get { return continueOrder; } set { } }

            while (continueOrder)
            {
                try
                {
                    WriteLine("What would you like to order?");
        WriteLine();
        WriteLine($"{drinkItemArray.Count} items on the menu");
        WriteLine();
                    foreach (Drink drinkItem in drinkItemArray)
                    {
                        WriteLine($"{drinkItemArray.IndexOf(drinkItem) + 1}. for {drinkItem.DrinkName} (${drinkItem.DrinkPrice})"); // Increments by 1 for readability in UI
    }
                    if (orderedItemArrayList.Count > 0)
                    {
                        WriteLine();
    WriteLine($"{orderedItemArrayList.Count} items ordered: ");
    int itemIndex = 1;
    double totalBill = 0;
                        foreach (Drink orderedItem in orderedItemArrayList)
                        {
                            WriteLine($"{itemIndex}, {orderedItem.DrinkName}, ${orderedItem.DrinkPrice}");
    itemIndex++;
                            totalBill += orderedItem.DrinkPrice;

                        }
WriteLine("---------------------------");
WriteLine($"Total bill ${totalBill}");
                    }
                    WriteLine("Enter your order below");
WriteLine("Optionally type 'r' + the ordered item, like so: r1, to remove ordered item 1 ");

choice = Console.ReadLine();

                    try
                    {
                        int choiceInt = Convert.ToInt32(choice) - 1; // Decrements by 1 to correct for + 1 in UI
orderedItemArrayList.Add(drinkItemArray[choiceInt]);
                    }
                    catch
                    {

                        if (choice.StartsWith("r") || choice.StartsWith("R"))
                        {

                            //System.Text.RegularExpressions.Regex https://stackoverflow.com/questions/4734116/find-and-extract-a-number-from-a-string
                            String indexString = Regex.Match(choice, @"\d+").Value;
int index = Convert.ToInt32(indexString) - 1; // Decrements by 1 to correct for + 1 in UI

                            if (index<orderedItemArrayList.Count && index >= 0)
                            {
                                orderedItemArrayList.RemoveAt(index);
                                WriteLine("One item removed");
WriteLine("");
                            }
                        }
                        else
                        {
                            if (choice.Contains("ready"))
                            {
                                int orderId = PutOrder(orderedItemArrayList);
ConfirmOrder(orderId);
                            }

                            WriteLine($"{choice} is an invalid input, try again");
                        }
                    }
                }
                catch
                {
                    WriteLine("Something went wrong. :(");
                }
            }
    }
}
