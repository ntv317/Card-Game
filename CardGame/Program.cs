using System;
using System.Collections.Generic;
using CardGame.Entity;
using CardGame.Type;
using System.Linq;
namespace CardGame
{
    public class Program
    {
        public static readonly string[] Numbers = { "1","2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        /// <summary>
        /// generate a deck with 52 cards
        /// </summary>
        /// <returns></returns>
        static IEnumerable<Card> FillCardDeck()
        {
            var suits = Enum.GetValues(typeof(SuitType));
            foreach (var number in Numbers)
            {
                foreach(var suit in suits)
                {
                    yield return new Card { CardNumber = number, Suit = Enum.Parse<SuitType>(suit.ToString())};
                }
            }
        }
        /// <summary>
        /// Sort card deck
        /// </summary>
        /// <param name="cardDeck">list of cards</param>
        /// <param name="sortBy"> Sort by card number or by suit</param>
        /// <param name="desc">order by desc or asc </param>
        /// <returns></returns>
        static IEnumerable<Card> Sort(IEnumerable<Card> cardDeck, SortType sortBy ,bool desc)
        {

            return cardDeck.
                IfThenElse(
                ()=>sortBy == SortType.ByCard,
                x=>x.IfThenElse(
                    ()=>desc,
                    e=>e.OrderByDescending(y=>y.CardNumber),
                    e => e.OrderBy(y => y.CardNumber)),
                x => x.IfThenElse(
                    () => desc,
                    e => e.OrderByDescending(y => y.Suit),
                    e => e.OrderBy(y => y.Suit))
                );
        }
        static  void Main(string[] args)
        {
            var deckCard = FillCardDeck();
            Console.WriteLine("----[New deck of card]----");
            ShowDeck(deckCard);

            deckCard = Sort(deckCard, SortType.BySuit,true);
            Console.WriteLine("----[Sorted deck of card]----\n");
            ShowDeck(deckCard);
            deckCard = deckCard.Shuffle();
         
            Console.Write("----[Shuffled deck of card]---- \n");
            ShowDeck(deckCard);

        }

        static void ShowDeck(IEnumerable<Card> deck)
        {
            foreach (var a in deck)
            {
                Console.Write($"{a.CardNumber}-{a.Suit}; ");
            }
            Console.WriteLine();
         
        }
    }
}
