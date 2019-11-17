using System.Collections.Generic;
using System.Linq;

namespace GameCardLib
{
    public class DbManager
    {
        // todo lägg endast till player om den inte redan finns i db
        public void InsertPlayerToDb(Player _player)
        {
            using (var db = new HighScoreContext())
            {
                var player = _player;

                if (!(db.Players.Any(o => o.PlayerID == player.PlayerID)))
                {
                    db.Players.Add(player);
                    db.SaveChanges();
                }
            }
        }

        // om score finns för en player, hämta den score och inkrementera med ett
        public void InsertScoreToDb(Player _player)
        {
            using (var db = new HighScoreContext())
            {
                var player = _player;

                var result = db.Scores.SingleOrDefault(o => o.PlayerId == player.PlayerID);

                if (result != null)
                {
                    result.NbrOfWins = result.NbrOfWins + 1;
                    db.SaveChanges();
                }
                else
                {
                    var score = new Score();
                    score.PlayerId = player.PlayerID;
                    score.NbrOfWins = 1;
                    db.Scores.Add(score);
                    db.SaveChanges();
                }
            }
        }

        public List<Player> GetPlayersFromDb()
        {
            List<Player> playerList = new List<Player>();
            using (var db = new HighScoreContext())
            {
                var query = from p in db.Players orderby p.Name select p;

                foreach (var item in query)
                    playerList.Add(item);
            }
            return playerList;
        }

        public List<Score> GetHighScoresFromDb()
        {
            List<Score> scoreList = new List<Score>();

            using (var db = new HighScoreContext())
            {
                var query = from s in db.Scores orderby s.NbrOfWins select s;

                foreach (var item in query)
                    scoreList.Add(item);
            }       
            return scoreList;
        }

        public void ResetHighScoresFromDb()
        {
            using (var db = new HighScoreContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [players]");
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [scores]");
            }
        }
    }
}
