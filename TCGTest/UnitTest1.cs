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
        }
    }
}