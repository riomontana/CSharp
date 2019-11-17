using System;

namespace GameCardLib
{
    // Class representing a playing card
    public class Card
    {
        private int _value;
        private Suite _suite;

        // Property for value of card
        public int Value { get => _value; set => _value = value; }

        // Property for suite of card
        public Suite Suite { get => _suite; set => _suite = value; }

        // Override of ToString returns suite and value of a card as a string 
        public override String ToString()
        {
            String toString = _suite.ToString() + " " + _value.ToString();
            return toString;
        }
    }

    // Enum for Suite of card
    public enum Suite
    {
        Hearts = 0,
        Diamonds = 1,
        Clubs = 2,
        Spades = 3,
    }
}
