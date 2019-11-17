using System;
using System.Collections.Generic;
using System.Linq;

namespace GameCardLib
{
    public class Deck
    {
        private List<Card> cardList;
        private Suite[] _suite = { Suite.Hearts, Suite.Diamonds, Suite.Clubs, Suite.Spades };
        private int _nbrOfCards = 0; // number of cards in the deck
        private int _deckSize = 0;

        // Constructor creating a deck of cards
        public Deck(int nbrOfDecks)
        {
            cardList = new List<Card>();

            for (int k = 0; k < nbrOfDecks; k++)
            {
                // for each suit, create cards from value 1 - 13
                for (int i = 0; i < _suite.Length; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        cardList.Add(new Card()); // create a new card 
                        cardList[NbrOfCards].Suite = _suite[i]; // assign current suite to card
                        cardList[NbrOfCards].Value = j + 1; // assign value to card
                        NbrOfCards++; // increment number of cards in deck
                    }
                }
            }
            DeckSize = NbrOfCards;
            Console.WriteLine("Deck created with " + NbrOfCards + " cards");
        }

        // Properties
        public int NbrOfCards { get => _nbrOfCards; set => _nbrOfCards = value; }
        public int DeckSize { get => _deckSize; set => _deckSize = value; }

        // Shuffles the deck of cards and returns it
        public Deck ShuffleDeck()
        {
            List<Card> shuffledCards = cardList.OrderBy(x => Guid.NewGuid()).Take(NbrOfCards).ToList();
            cardList = shuffledCards;
            Console.WriteLine("Deck shuffled");

            return this;
        }

        public Card HitCard()
        {
            Card card = cardList[NbrOfCards-1];
            cardList.RemoveAt(NbrOfCards-1);
            NbrOfCards--;
            return card;
        }

        // Override of ToString returns a string with every card in the deck
        public override string ToString()
        {
            string cardsToString = "DECK CONTENT: " + NbrOfCards + " cards\n";
            foreach (Card card in cardList)
            {
                cardsToString += card.ToString() + "\n";
            }
            cardsToString += "END OF DECK..\n";
            return cardsToString;
        }
    }
}
