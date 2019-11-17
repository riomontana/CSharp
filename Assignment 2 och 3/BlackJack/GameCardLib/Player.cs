
namespace GameCardLib
{
    // Class representing a black jack player
    public class Player
    {
        private string _name;
        private int _playerID = 0;
        private Hand hand;
        private bool isStaying;
        private bool isThick;
        private bool isFinished;
        private bool isWinner;
        private int nbrOfWins;

        //constructor without parameters
        private Player() { }

        // constructor
        public Player(string name, int playerID)
        {
            this.Name = name;
            this.PlayerID = playerID;
            Hand = new Hand();
        }

        // adds a card to the players hand
        public void AddCard(Card card)
        {
            Hand.AddCard(card);
        }

        // returns the last card from the hand
        public string LastCard()
        {
            return Hand.LastCard();
        }

        // resets the players hand
        public void ResetHand()
        {
            IsWinner = false;
            IsThick = false;
            IsStaying = false;
            hand = null;
            hand = new Hand();
        }

        // properties
        public string Name { get => _name; set => _name = value; }
        public Hand Hand { get => hand; set => hand = value; }
        public bool IsWinner { get => isWinner; set => isWinner = value; }
        public int NbrOfWins { get => nbrOfWins; set => nbrOfWins = value; }
        public int PlayerID { get => _playerID; set => _playerID = value; }
        public bool IsStaying { get => isStaying; set => isStaying = value; }
        public bool IsThick { get => isThick; set => isThick = value; }
        public bool IsFinished { get => isFinished; set => isFinished = value; }
    }
}
