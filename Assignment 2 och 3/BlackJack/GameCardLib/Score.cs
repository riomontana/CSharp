using System.ComponentModel.DataAnnotations;

namespace GameCardLib
{
    public class Score
    {
        [Key]
        public int PlayerId { get; set; }
        public int NbrOfWins { get; set; }
    }
}
