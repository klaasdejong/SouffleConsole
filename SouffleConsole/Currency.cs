using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace SouffleConsole
{
    /* Deze statische klasse is beschikbaar voor de hele applicatie om decimale centen
     * om te zetten in dit formaat: € 123,45.
     * Hiervoor gebruik ik de Globalization en de Threading-bibliotheken.
     * Globalization bevat de klasse CultureInfo, waarmee je kan kiezen tussen verschillende
     * (inter)nationale standaarden om bijv. geld te weergeven.
     * Je zet dit aan in de thread door de Threading-bibliotheek te gebruiken.
     * Omdat de currency in centen opgeslagen wordt door de Product-objecten moet wordt het 
     * eerst door 100 gedeeld om hele euro's te krijgen.
     */
    public static class Currency
    {
        public static string CentsToWhole(decimal input)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");
            return (input / 100).ToString("c");
        }
    }
}