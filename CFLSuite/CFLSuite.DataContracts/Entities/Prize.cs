namespace CFLSuite.DataContracts.Entities
{
    public class Prize
    {
        public int PrizeID { get; set; }
        public int WinningPlayerID { get; set; }
        public int LosingPlayerID { get; set; }
        public int BetID { get; set; }
        public string PrizeDescription { get; set; }

        public virtual Player WinningPlayer { get; set; }
        public virtual Player LosingPlayer { get; set; }
        public virtual Bet Bet { get; set; }
    }
}