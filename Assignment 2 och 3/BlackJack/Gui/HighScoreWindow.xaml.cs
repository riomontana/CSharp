using System.Collections.Generic;
using System.Linq;
using System.Windows;
using GameCardLib;

namespace Gui
{
    /// <summary>
    /// Interaction logic for HighScoreWindow.xaml
    /// Shows the current number of wins per player
    /// </summary>
    public partial class HighScoreWindow : Window
    {
        private DbManager _dbManager;

        // Constructor
        public HighScoreWindow(DbManager dbManager)
        {
            this._dbManager = dbManager;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AddHighScores();
        }

        // Get highscores from db and add them to window
        public void AddHighScores()
        {
            List<Player> playerList = _dbManager.GetPlayersFromDb();
            List<Score> scoreList = _dbManager.GetHighScoresFromDb();

            List<Score> sortedList = scoreList.OrderByDescending(s => s.NbrOfWins).ToList();
            int topCounter = 1;

            foreach (Score score in sortedList)
            {
                highScoreGrid.Items.Add(topCounter++ + ": " +
                    playerList[score.PlayerId - 1].Name + " : " +
                    score.NbrOfWins + " wins");
            }
        }

        // Delete highscores from db and remove them from window 
        private void btnResetHighScore_Click(object sender, RoutedEventArgs e)
        {
            _dbManager.ResetHighScoresFromDb();
            highScoreGrid.Items.Clear();
        }
    }
}
