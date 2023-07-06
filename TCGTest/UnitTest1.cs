using System.Runtime.InteropServices;
using TCGNamespace;
namespace TCGTest
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void CardComparisonTest()
        {
            Card card = new Card(1);
            Card card2 = new Card(3);
            Card card3 = new Card(5);
            Card card4 = new Card(6);

            Assert.IsTrue(card.CompareTo(card2) < 0,"The Lower Card is not comparing correctly");
            Assert.IsTrue(card.CompareTo(card3) < 0, "The Lower Card is not comparing correctly");
            Assert.IsTrue(card.CompareTo(card4) < 0, "The Lower Card is not comparing correctly");
            Assert.IsTrue(card2.CompareTo(card3) < 0, "The Lower Card is not comparing correctly");
            Assert.IsTrue(card2.CompareTo(card4) < 0, "The Lower Card is not comparing correctly");
            Assert.IsTrue(card3.CompareTo(card4) < 0, "The Lower Card is not comparing correctly");
            Assert.IsTrue(card2.CompareTo(card) > 0, "The Higher Card is not comparing correctly");
            Assert.IsTrue(card3.CompareTo(card) > 0, "The Higher Card is not comparing correctly");
            Assert.IsTrue(card4.CompareTo(card) > 0, "The Higher Card is not comparing correctly");
            Assert.IsTrue(card3.CompareTo(card2) > 0, "The Higher Card is not comparing correctly");
            Assert.IsTrue(card4.CompareTo(card2) > 0, "The Higher Card is not comparing correctly");
            Assert.IsTrue(card4.CompareTo(card3) > 0, "The Higher Card is not comparing correctly");
            Assert.IsTrue(card.CompareTo(card) == 0, "Equal cards are not comparing correctly");
            Assert.IsTrue(card2.CompareTo(card2) == 0, "Equal cards are not comparing correctly");
            Assert.IsTrue(card3.CompareTo(card3) == 0, "Equal cards are not comparing correctly");
            Assert.IsTrue(card4.CompareTo(card4) == 0, "Equal cards are not comparing correctly");
        }

        [TestMethod]
        public void mapValuesToCardsWorks()
        {
            int[] values = { 1, 2, 3, };

            List<Card> cards = Card.mapValuesToCardList(values);

            foreach (var card in cards)
            {
                Assert.IsTrue(values.Contains(card.getValue()),"Card mapping failed for " + card.getValue());   
            }
        }
    }

    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayerCreatesAsExpected() {
            Player player = new Player();
            Assert.AreEqual(30, player.getHealth(), "Initial Health is not 30.");
            Assert.AreEqual(0, player.getManaSlots(), "Inital Mana Slots is not 0.");
            Assert.AreEqual(0, player.getMana(), "Initial Mana is not 0.");
            Assert.AreEqual(20, player.getDeck().Count, "Deck does not match expected size.");
            CollectionAssert.AreNotEqual(Card.mapValuesToCardList(0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8), player.getDeck(), "Deck has not been shuffled.");
            Assert.IsTrue(player.getHand().Count == 0, "Hand is not initially empty");
        }

        [TestMethod]
        public void DrawingCausesBleedDamageWhenDeckIsEmpty()
        {
            Player anneNemic = new Player(30, 0, 0, new List<Card>(), new List<Card>());
            anneNemic.drawCard();
            Assert.AreEqual(29, anneNemic.getHealth(), "Player did not take bleed damage on an empty deck.");
        }

        [TestMethod]
        public void DrawingCausesOverloadDiscardWhenHandSizeAboveMaximum()
        {
            Player fullHandLuke = new Player(30, 0, 0, Card.mapValuesToCardList(6), Card.mapValuesToCardList(1, 2, 3, 4, 5));
            fullHandLuke.drawCard();
            Assert.AreEqual(5, fullHandLuke.getHand().Count);
            for (int i = 0; i<fullHandLuke.getHand().Count;i++)
            {
                Assert.AreNotEqual(6, fullHandLuke.getHand()[i].getValue());
            }
            Assert.AreEqual(0, fullHandLuke.getDeck().Count);
        }

        [TestMethod]
        public void DrawingAddsTheNextCardFromTheDeckToHandInNormalScenarios()
        {
            Player normalNorman = new Player(30, 0, 0, Card.mapValuesToCardList(1, 2), new List<Card>());
            normalNorman.drawCard();
            Assert.AreEqual(1, normalNorman.getHand()[0].getValue(),"Did not draw card valued 1");
            for (int i = 0; i<normalNorman.getDeck().Count;i++)
            {
                Assert.AreNotEqual(1, normalNorman.getDeck()[i].getValue(),"Deck still contains card valued 1");
            }
            Assert.AreEqual(1,normalNorman.getHand().Count,"Hand size did not increase");
            Assert.AreEqual(1, normalNorman.getDeck().Count,"Deck size did not decrease");
        }
    }
}