
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardGame.Entity;
using CardGame.Type;

namespace CardGame
{
    public static class PlayCard
    {
        public static readonly string[] Numbers = { "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", "2" };

        /// <summary>
        /// generate a deck with 52 cards
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Card> FillCardDeck()
        {

            int cardWeight = 0;
            var suits = SuitGenarate();
            foreach (var number in Numbers)
            {
                foreach (var suit in suits)
                {
                    yield return new Card
                    {
                        CardNumber = new Dictionary<string, int> { { number, cardWeight } },
                        Suit = new Dictionary<string, int> { { suit.Key, suit.Value } }
                    };
                }
                cardWeight++;
            }
        }
        /// <summary>
        /// Sort card deck
        /// </summary>
        /// <param name="cardDeck">list of cards</param>
        /// <param name="sortBy"> Sort by card number or by suit</param>
        /// <param name="desc">order by desc or asc </param>
        /// <returns></returns>
        public static IEnumerable<Card> Sort(this IEnumerable<Card> cardDeck, SortType sortBy, bool desc)
        {
            return cardDeck.
                IfThenElse(
                () => sortBy == SortType.ByCard,
                x => x.IfThenElse(
                    () => desc,
                    e => e.OrderByDescending(y => y.CardNumber.Values.FirstOrDefault())
                    .ThenBy(y => y.CardNumber.Values.FirstOrDefault()),
                    e => e.OrderBy(y => y.CardNumber.Values.FirstOrDefault())
                    .ThenBy(y => y.CardNumber.Values.FirstOrDefault())),
                x => x.IfThenElse(
                    () => desc,
                    e => e.OrderByDescending(y => y.Suit.Values.FirstOrDefault())
                    .ThenByDescending(y => y.CardNumber.Values.FirstOrDefault()),
                    e => e.OrderBy(y => y.Suit.Values.FirstOrDefault())
                    .ThenByDescending(y => y.CardNumber.Values.FirstOrDefault()))
                );

        }
        public static string ShowDeck(this IEnumerable<Card> deck)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var a in deck)
            {
                sb.Append($"{a.CardNumber.Keys.FirstOrDefault()}-{a.Suit}; ");
            }
            return sb.ToString();

        }

        private static IDictionary<string, int> SuitGenarate()
        {
            return new Dictionary<string, int>
            {
                {"Spade", 1 },
                {"Club",2 },
                {"Diamond",3 },
                {"Heart" ,4}
            };
        }
    }
}
