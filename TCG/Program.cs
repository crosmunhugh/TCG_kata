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

        public int getValue() { return this.value;  }
    }

    public class Player
    {
        private const int MAX_HEALTH = 30;
       


        private int health;
        private int mana;
        private int manaSlots;

        public Player()
        {
            this.health = MAX_HEALTH;
            this.mana = 0;
            this.manaSlots = 0;
        }

        public int getHealth() { return this.health; }

        public void setHealth(int health) { this.health = health; }

        public int getManaSlots() { return this.manaSlots; }

        public void setManaSlots(int manaSlots) { this.manaSlots = manaSlots; }

        public int getMana() { return this.mana; }

        public void setMana(int mana) { this.mana = mana; }


        public static void Main(String[] args) { }
    }
}