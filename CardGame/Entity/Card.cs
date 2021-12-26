using System;
using System.Collections.Generic;
using CardGame.Type;

namespace CardGame.Entity
{
    public class Card
    {
        /// <summary>
        /// Contains Card value and weight
        /// </summary>
       public IDictionary<string, int> CardNumber { get; set; }
       public IDictionary<string, int> Suit { get; set; }
    }
}
