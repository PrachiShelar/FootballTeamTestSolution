
namespace FootballTeam.models
{
     public class FTeam
    {
        public string Team { get; set; }
        public int P { get; set; }
        public int W { get; set; }
        public int L { get; set; }
        public int D { get; set; }
        public int F { get; set; }
        public int A { get; set; }
        public int Pts { get; set; }
        public int? ScoreDiff { get; set; } 
    }
}
