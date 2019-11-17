using System.Collections.Generic;

namespace GameCardLib
{
    public class Hand
    {
        private List<Card> cards = new List<Card>();
        private int score = 0;
        private int nbrOfCards = 0;

        public int Score { get => score; set => score = value; }
        public int NbrOfCards { get => nbrOfCards; set => nbrOfCards = value; }

        public void AddCard(Card card)
        {
            cards.Add(card);
            Score += card.Value;
            NbrOfCards++;
        }

        public string LastCard()
        {
            return cards[NbrOfCards-1].ToString();
        }
    }
}
