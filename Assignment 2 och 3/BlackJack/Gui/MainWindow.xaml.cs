using System;
using System.Windows;
using System.Windows.Media.Imaging;
using GameCardLib;

namespace Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Main window / dealer window
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager gameManager; // publisher
        private DbManager dbManager;
        private ImageHandler imageHandler;
        private bool isGameRunning;
        private bool firstHit;
        private MultiWindow[] multiWindows;
        private int playerIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            dbManager = new DbManager();
        }

        private void CreateMultiWindows(int nbrOfPlayers)
        {
            multiWindows = new MultiWindow[nbrOfPlayers];

            for (int i = 0; i < nbrOfPlayers; i++)
            {
                multiWindows[i] = new MultiWindow(gameManager, i+1);
                multiWindows[i].Show();
            }
        }

        private void CreateNewGame()
        {
            if (multiWindows != null)
            {
                gameManager = null;
                imageHandler = null;
                foreach (MultiWindow mWindow in multiWindows)
                {
                    mWindow.Close();
                }
                multiWindows = null;
            }
            gameManager = new GameManager(dbManager);
            imageHandler = new ImageHandler();
        
            SetEventHandlers();
        }

        private void SetEventHandlers()
        {
            gameManager.CardDrawn +=
               (s, e) =>
               {
                   lblNbrOfCards.Content = "Cards left: " + gameManager.GetNbrOfCards();
                   if (e.Player.Name.Equals(lblDealer.Content))
                   {
                       SetCardImage(e.Card.ToString(), e.Player.Name, e.Player.Hand.NbrOfCards);

                       if (e.Player.Hand.Score > 21)
                           lblDealerScore.Content = "Dealer is thick";
                       else
                           lblDealerScore.Content = "Score " + e.Player.Hand.Score;
                   }
               };

            gameManager.RoundFinished +=
                (s, e) =>
                {
                    MessageBox.Show(e.Player.Name + " is the winner");
                    dbManager.InsertScoreToDb(e.Player);
                    if (e.Player.Name.Equals(lblDealer.Content))
                    {
                        lblDealerNbrOfWins.Content = "Number of wins: " + e.Player.NbrOfWins;
                    }
                    firstHit = true;
                    lblDealerScore.Content = "Score: 0";
                    SetCardsBack();
                };

            gameManager.RoundTied +=
                (s, e) =>
                {
                    MessageBox.Show("Tie game");
                    lblDealerScore.Content = "Score: 0";
                    SetCardsBack();
                    firstHit = true;
                };

            gameManager.PlayerTurn +=
                (s, e) =>
                {
                    if (e.Player.Name.Equals(lblDealer.Content))
                    {
                        if (gameManager.GetNbrOfCards() >= 2)
                            gameManager.DealerHitOrStay(0);
                        else
                            MessageBox.Show("Deck is empty, start a new game");
                    }
                };
        }

        // New game button handler
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lblWelcome.Content = "";
            CreateNewGame();
            int[] promptValue = null;

            while (promptValue == null)
                promptValue = NewGameDialog.ShowDialog();

            int nbrOfDecks = promptValue[0];
            int nbrOfPlayers = promptValue[1];
            gameManager.CreateDecks(nbrOfDecks);
            gameManager.CreatePlayers(nbrOfPlayers);
            CreateMultiWindows(nbrOfPlayers);
            lblNbrOfPlayers.Content = "Players: " + nbrOfPlayers;
            lblDecks.Content = "Decks: " + nbrOfDecks;
            lblNbrOfCards.Content = "Cards left: " + gameManager.GetNbrOfCards();
            lblDealer.Content = "Dealer";
            lblDealerScore.Content = "Score: 0";
            lblDealerNbrOfWins.Content = "Number of wins: 0";
            firstHit = true;
            SetCardsBack();
        }

        // Set the card images accordingly 
        private void SetCardImage(string cardName, string playerName, int cardNumber)
        {
            if (playerName.Equals("Dealer"))
            {
                switch (cardNumber)
                {
                    case 1:
                        DealerCard1.Source = imageHandler.GetCardImage(cardName);
                        break;
                    case 2:
                        DealerCard2.Source = imageHandler.GetCardImage(cardName);
                        break;
                    case 3:
                        DealerCard3.Source = imageHandler.GetCardImage(cardName);
                        break;
                    case 4:
                        DealerCard4.Source = imageHandler.GetCardImage(cardName);
                        break;
                    case 5:
                        DealerCard5.Source = imageHandler.GetCardImage(cardName);
                        break;
                }
            }
        }

        // Set card images to backside
        private void SetCardsBack()
        {
            BitmapImage card = imageHandler.GetCardImage("back");
            DealerCard1.Source = card;
            DealerCard2.Source = card;
            DealerCard3.Source = card;
            DealerCard4.Source = card;
            DealerCard5.Source = card;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            foreach (MultiWindow mWindow in multiWindows)
                mWindow.Close();
        }

        private void High_Scores_Click(object sender, RoutedEventArgs e)
        {
            HighScoreWindow highScoreWindow = new HighScoreWindow(dbManager);
            highScoreWindow.Show();
        }
    }
}
