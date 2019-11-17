using System;

namespace GameCardLib
{
    // Class handling the game logic, creating decks, players etc
    public class GameManager
    {
        private Deck deck;
        private Player[] players;
        private int _nbrOfPlayers;
        private bool checkIfShuffle;
        private int topScore = 0;
        private DbManager _dbManager;

        public GameManager(DbManager dbManager)
        {
            this._dbManager = dbManager;
        }

        public int NbrOfPlayers { get => _nbrOfPlayers; set => _nbrOfPlayers = value; }

        public void CreateDecks(int nbrOfDecks)
        {
            checkIfShuffle = false;
            deck = new Deck(nbrOfDecks);
            ShuffleDecks();
        }

        public void ShuffleDecks()
        {
            Deck shuffledDeck;
            shuffledDeck = deck.ShuffleDeck();
            deck = shuffledDeck;
            Console.Write(deck.ToString());
        }

        public void CreatePlayers(int nbrOfPlayers)
        {
            NbrOfPlayers = nbrOfPlayers;
            players = new Player[NbrOfPlayers+1]; // nbr of players + dealer
            players[0] = new Player("Dealer", 1);
            _dbManager.InsertPlayerToDb(players[0]);

            for (int i = 1; i <= nbrOfPlayers; i++)
            {
                players[i] = new Player("Player " + (i), (i+1));
                _dbManager.InsertPlayerToDb(players[i]);
            }
        }

        public int GetNbrOfCards()
        {
            return deck.NbrOfCards;
        }

        public string GetPlayerName(int playerID)
        {
            return players[playerID].Name;
        }

        public void NextTurn(int playerIndex)
        {
            // if last player in array, dealers turn
            if (playerIndex == players.Length - 1)
                OnPlayerTurn(players[0]);
            // else next players turn
            else
                OnPlayerTurn(players[playerIndex + 1]);
        }

        public void DealerHitOrStay(int playerIndex)
        {
            Player dealer = players[playerIndex];
            if ((dealer.Hand.Score <= 17) && (dealer.Hand.Score < 21))
                HitCard(playerIndex);
            else
                Stay(playerIndex);
        }

        public void HitCard(int playerIndex)
        {
            Player player = players[playerIndex];
            Card card = deck.HitCard();
            player.AddCard(card);
            OnCardDrawn(card, player);
            CheckDeckSize();

            UpdateScore(playerIndex);

            if ((playerIndex == 0) && (IsRoundFinished()))
                CheckWinnerOrTie();
            else
                NextTurn(playerIndex);
        }

        public void Stay(int playerIndex)
        {
            Player player = players[playerIndex];
            player.IsStaying = true;

            if ((playerIndex == 0) && (IsRoundFinished()))
                CheckWinnerOrTie();
            else
                NextTurn(playerIndex);
        }

        public bool IsRoundFinished()
        {
            bool roundIsFinished = false;
            int stayingCounter = 0;
            int thickCounter = 0;

            foreach (Player player in players)
            {
                if (player.IsStaying)
                    stayingCounter++;
                else if (player.IsThick)
                    thickCounter++;
            }

            if ((stayingCounter == players.Length) || (thickCounter == players.Length-1))
            {
                roundIsFinished = true;
                UpdateTopScore();
            }

            return roundIsFinished;
        }

        public void CheckWinnerOrTie()
        {
            int topScoreCounter = 0;
            int thickCounter = 0;
            foreach (Player player in players)
            {
                if (player.Hand.Score == topScore)
                {
                    player.IsWinner = true;
                    topScoreCounter++;
                }
                else if (player.IsThick)
                {
                    thickCounter++;
                }
            }

            if ((topScoreCounter > 1) || (thickCounter == players.Length))
            {
                OnRoundTied();
            }
            else
            {
                foreach (Player player in players)
                {
                    if (player.IsWinner)
                    {
                        player.NbrOfWins++;
                        OnRoundFinished(player);
                    }
                }
            }
            ResetScores();
        }

        public void UpdateScore(int playerIndex)
        {
            Player player = players[playerIndex];
            int score = player.Hand.Score;
            Console.WriteLine(player.Name + " Score: " + score );

            if (score > 21)
                player.IsThick = true;
            else if ((score <= 21) && (score > topScore))
                topScore = score;
            if (score == 21)
                player.IsStaying = true;

        }

        public void UpdateTopScore()
        {
            topScore = 0;
            foreach (Player player in players)
            {
                if (player.Hand.Score < 22)
                {
                    if (player.Hand.Score > topScore)
                    {
                        topScore = player.Hand.Score;
                    }
                }
            }
        }


        public void ResetScores()
        {
            foreach (Player player in players)
            {
                player.ResetHand();
            }
            OnPlayerTurn(players[1]);
        }

        // Checks how many percent of the deck is left
        public void CheckDeckSize()
        {
            if (!checkIfShuffle)
            {
                int percentageLeft = (int)Math.Round((double)(100 * deck.NbrOfCards) / deck.DeckSize);
                if (percentageLeft <= 25)
                {
                    OnQuarterLeft();
                    checkIfShuffle = true;
                }
            }
        }

        public delegate void CardDrawnEventHandler(object source, CardEventArgs args);
        public event CardDrawnEventHandler CardDrawn;

        public delegate void RoundFinishedEventHandler(object source, RoundFinishedEventArgs args);
        public event RoundFinishedEventHandler RoundFinished;

        public delegate void QuarterLeftEventHandler(object source, EventArgs args);
        public event QuarterLeftEventHandler QuarterLeft;

        public delegate void RoundTiedEventHandler(object source, EventArgs args);
        public event RoundTiedEventHandler RoundTied;

        public delegate void PlayerTurnEventHandler(object source, PlayerTurnEventArgs args);
        public event PlayerTurnEventHandler PlayerTurn;

        protected virtual void OnPlayerTurn(Player player)
        {
            if (PlayerTurn != null)
            {
                PlayerTurn(this, new PlayerTurnEventArgs() { Player = player });
            }
        }

        protected virtual void OnRoundTied()
        {
            if (RoundTied != null)
                RoundTied(this, EventArgs.Empty);
        }

        protected virtual void OnQuarterLeft()
        {
            if (QuarterLeft != null)
                QuarterLeft(this, EventArgs.Empty);
        }

        protected virtual void OnRoundFinished(Player player)
        {
            if (RoundFinished != null)
                RoundFinished(this, new RoundFinishedEventArgs() { Player = player });

        }

        protected virtual void OnCardDrawn(Card card, Player player)
        {
            if (CardDrawn != null)
                CardDrawn(this, new CardEventArgs() { Card = card, Player = player });
        }
    }
}
