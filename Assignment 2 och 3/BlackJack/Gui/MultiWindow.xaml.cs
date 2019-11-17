using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using GameCardLib;

namespace Gui
{
    /// <summary>
    /// Interaction logic for MultiWindow.xaml
    /// Player window
    /// </summary>
    public partial class MultiWindow : Window
    {
        private GameManager gameManager;
        private ImageHandler imageHandler;
        private bool isGameRunning;
        private bool firstHit;
        private int playerIndex;

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public MultiWindow(GameManager _gameManager, int playerID)
        {
            InitializeComponent();
            this.gameManager = _gameManager;
            imageHandler = new ImageHandler();
            SetEventHandlers();
            playerIndex = playerID;
            lblPlayer.Content = gameManager.GetPlayerName(playerID);
            lblPlayerScore.Content = "Score: 0";
            lblPlayerNbrOfWins.Content = "Number of wins: 0";
            EnableGameButtons(isGameRunning = true, playerID);
            firstHit = true;
            SetCardsBack();
        }

        private void SetEventHandlers()
        {
            gameManager.CardDrawn +=
                (s, e) =>
                {
                    if (e.Player.Name.Equals(lblPlayer.Content))
                    {
                        SetCardImage(e.Card.ToString(), e.Player.Name, e.Player.Hand.NbrOfCards);

                        btnHit.IsEnabled = false;
                        btnShuffle.IsEnabled = false;
                        btnStand.IsEnabled = false;

                        if (e.Player.Hand.Score > 21)
                            lblPlayerScore.Content = "Player is thick";
                        else
                            lblPlayerScore.Content = "Score " + e.Player.Hand.Score;
                    }
                };

            gameManager.RoundFinished +=
                (s, e) =>
                {
                    if (e.Player.Name.Equals(lblPlayer.Content))
                    {
                        lblPlayerNbrOfWins.Content = "Number of wins: " + e.Player.NbrOfWins;
                    }
                    lblPlayerScore.Content = "Score: 0";
                    SetCardsBack();
                    btnStand.IsEnabled = false;
                    firstHit = true;
                };

            gameManager.QuarterLeft +=
                (s, e) =>
                {
                    if (MessageBox.Show("25% of deck remaining",
                        "Less than 25% remaining of deck, reshuffle?",
                        MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        gameManager.ShuffleDecks();
                    }
                };

            gameManager.RoundTied +=
                (s, e) =>
                {
                    lblPlayerScore.Content = "Score: 0";
                    SetCardsBack();
                    btnStand.IsEnabled = false;
                    firstHit = true;
                    btnHit.IsEnabled = true;
                };

            gameManager.PlayerTurn +=
                (s, e) =>
                {
                    if (e.Player.Name.Equals(lblPlayer.Content))
                    {
                        if (e.Player.IsStaying || e.Player.IsThick)
                            gameManager.Stay(playerIndex);
                        else
                        {
                            lblPlayerTurn.Content = e.Player.Name + "'s turn";
                            if (firstHit)
                            {
                                firstHit = false;
                                btnHit.IsEnabled = true;
                                btnShuffle.IsEnabled = true;
                            }
                            else
                            {
                                btnHit.IsEnabled = true;
                                btnShuffle.IsEnabled = true;
                                btnStand.IsEnabled = true;
                            }
                        }
                    }
                };
        }

        // Enables game button after a new game has been created
        private void EnableGameButtons(bool isGameRunning, int playerID)
        {
            if (isGameRunning && playerID == 1)
            {
                btnHit.IsEnabled = true;
                btnShuffle.IsEnabled = true;
                lblPlayerTurn.Content = "Player 1's turn";
            }
            else
            {
                btnHit.IsEnabled = false;
                btnShuffle.IsEnabled = false;
                btnStand.IsEnabled = false;
            }
        }

        // draws cards from the deck
        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            if (firstHit)
                firstHit = false;

            if (gameManager.GetNbrOfCards() >= 2)
            {
                Console.WriteLine("player index = " + playerIndex);
                gameManager.HitCard(playerIndex);
                lblPlayerTurn.Content = "";
            }
            else
            {
                MessageBox.Show("Deck is empty, start a new game");
                btnHit.IsEnabled = false;
                btnShuffle.IsEnabled = false;
                btnStand.IsEnabled = false;

            }
        }

        // Player stands
        private void btnStand_Click(object sender, RoutedEventArgs e)
        {
            lblPlayerTurn.Content = "";
            btnHit.IsEnabled = false;
            btnShuffle.IsEnabled = false;
            btnStand.IsEnabled = false;
            gameManager.Stay(playerIndex);
        }

        // Shuffle the deck
        private void btnShuffle_Click(object sender, RoutedEventArgs e)
        {
            gameManager.ShuffleDecks();
        }

        // Set the card images accordingly 
        private void SetCardImage(string cardName, string playerName, int cardNumber)
        {
            if (playerName.Equals(lblPlayer.Content))
            {
                switch (cardNumber)
                {
                    case 1:
                        PlayerCard1.Source = imageHandler.GetCardImage(cardName);
                        break;
                    case 2:
                        PlayerCard2.Source = imageHandler.GetCardImage(cardName);
                        break;
                    case 3:
                        PlayerCard3.Source = imageHandler.GetCardImage(cardName);
                        break;
                    case 4:
                        PlayerCard4.Source = imageHandler.GetCardImage(cardName);
                        break;
                    case 5:
                        PlayerCard5.Source = imageHandler.GetCardImage(cardName);
                        break;
                }
            }
        }

        // Set card images to backside
        private void SetCardsBack()
        {
            BitmapImage card = imageHandler.GetCardImage("back");
            PlayerCard1.Source = card;
            PlayerCard2.Source = card;
            PlayerCard3.Source = card;
            PlayerCard4.Source = card;
            PlayerCard5.Source = card;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}
