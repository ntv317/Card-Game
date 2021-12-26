using System.Collections.Generic;
using CardGame;
using CardGame.Entity;
using CardGame.Type;
using NUnit.Framework;

namespace CardGameTest
{
    public class Tests
    {
        private IEnumerable<Card> _cardDeck;
        private string _orginalDeck;
        [SetUp]
        public void Setup()
        {
            _cardDeck = PlayCard.FillCardDeck();
            _orginalDeck = _cardDeck.ShowDeck();
        }

        [Test]
        public void SortDescByCardTest()
        {
            var sorted = _cardDeck.Sort(SortType.ByCard, true).ShowDeck();
            Assert.IsFalse(_orginalDeck.CompareTo(sorted) == 0);
        }
        [Test]
        public void SortAscBySuiteTest()
        {
            var sorted = _cardDeck.Sort(SortType.BySuit, false).ShowDeck();
            Assert.IsFalse(_orginalDeck.CompareTo(sorted) == 0);
        }
        [TestCase(1)]
        [TestCase(3)]
        public void ShuffleTest(int time)
        {
            var shuffle = _cardDeck.Shuffle(time).ShowDeck();
            Assert.IsFalse(_orginalDeck.CompareTo(shuffle) == 0);
        }
        [TestCase(2)]
        public void SortShuffleThenSortTest(int time)
        {
            var sorte = _cardDeck.Sort(SortType.BySuit, false);
            var beforeShuffle = sorte.ShowDeck();
            var shuffle = sorte.Shuffle(time);
            var sortAfterShuffele = shuffle.Sort(SortType.BySuit, false).ShowDeck();
            Assert.IsTrue(beforeShuffle.CompareTo(sortAfterShuffele) == 0);
        }
        [TestCase(4)]
        public void ShuffleThenSortByCardAscTest(int time)
        {
            var shuffle = _cardDeck.Shuffle(time);
            var sort = shuffle.Sort(SortType.ByCard, false).ShowDeck();
            Assert.IsTrue(_orginalDeck.CompareTo(sort) == 0);
        }

    }
}
