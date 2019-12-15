using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouffleConsole
{
    // Food erft de attributen en methoden van Product
    class Food : Product
    {
        bool extraSpoon;
        public bool ExtraSpoon { get { return extraSpoon; } }

        /* De constructor hierbeneden zal eerst de base constructor aanroepen met de argumenten "aName" en "aPrice"
         * vervolgens zal deze constructor zelf uitgevoerd worden.
         * Uitleg waarom er gebruikt gemaakt wordt van een constructor in de abstracte klasse Product is ook te vinden
         * in de comment boven de constructor van die klasse.
         */
        public Food(string aName, decimal aPrice, bool aExtraSpoon) : base(aName, aPrice)
        {
            this.extraSpoon = aExtraSpoon;
        }

        public override string ToString()
        {
            /* Omdat ik de klasse Product private attributen gebruik in combinatie met publieke getters 
             * roep ik hier het publieke attribuut (met hoofdletter) aan. Dit is nodig omdat de klasse 
             * Food geen toegang heeft tot private attributen van Product. Voor this.extraSpoon is dit niet nodig
             * omdat we in de context van Food zitten.
             */
            return string.Format(@"{0} - {1}, Price: {2}, Extra spoon: {3}", this.Id, this.Name, Currency.CentsToWhole(this.Price), this.extraSpoon);
            // Currency.CentsToWhole zet een decimal-waarde om in het €12,34-format.
        }
    }
}