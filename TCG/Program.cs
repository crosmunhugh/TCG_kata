using System;
using System.Numerics;
using TCGNamespace;

namespace TCGNamespace {

    public class Card : IComparable<Card>
    {
        int value;

        public Card(int value) { this.value = value;  }

        public static List<Card> mapValuesToCardList(params int[] values) {
            return values.Select(value => new Card(value)).ToList();
        }

        public int CompareTo(Card? other)
        {
            return value - other.getValue();
        }

        public override bool Equals(object? obj)
        {
            if (this == obj) return true;
            if (obj == null) return false;

            Card card = (Card)obj;

            if (value != card.value) return false;

            return true;
        }

        public override int GetHashCode() { return this.value; }

        public override string ToString()
        {
            return "" + this.value;
        }

        public int getValue() { return this.value;  }
    }

    public class Player
    {
        private const int MAX_HEALTH = 30;
        private const int MAX_HAND_SIZE = 5;

        private static Random rng = new();

        private int health;
        private int mana;
        private int manaSlots;

        private List<Card> deck;
        private List<Card> hand;

        public Player()
        {
            this.health = MAX_HEALTH;
            this.mana = 0;
            this.manaSlots = 0;
            this.deck = Card.mapValuesToCardList(0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8).OrderBy(card => rng.Next()).ToList();
            this.hand = new List<Card>();
        }

        public Player(int health, int manaSlots, int mana,  List<Card> deck, List<Card> hand)
        {
            this.health=health;
            this.manaSlots=manaSlots;
            this.mana = mana;
            this.deck=deck;
            this.hand=hand;
        }

        public List<Card> getDeck() { return this.deck; }

        public List<Card> getHand() { return this.hand; } 

        public int getHealth() { return this.health; }

        public void setHealth(int health) { this.health = health; }

        public int getManaSlots() { return this.manaSlots; }

        public void setManaSlots(int manaSlots) { this.manaSlots = manaSlots; }

        public int getMana() { return this.mana; }

        public void setMana(int mana) { this.mana = mana; }

        public int getNumberOfCardsInHand() { return this.hand.Count; }

        public void drawCard()
        {
            if (this.deck.Count == 0)
            {
                this.health--;
            } else
            {
                Card card = this.deck.First();
                this.deck.Remove(card);
                if (this.getNumberOfCardsInHand() < MAX_HAND_SIZE)
                {
                    this.hand.Add(card);
                }

            }
        }

        public static void Main(String[] args) { }

       
    }
}