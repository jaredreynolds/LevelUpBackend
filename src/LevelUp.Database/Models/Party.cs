namespace LevelUp.Database.Models
{
    public partial class Party
    {
        public int PartyId { get; set; }
        public int QuestId { get; set; }
        public int HeroId { get; set; }
        public virtual Quest Quest { get; set; }
        public virtual Hero Hero { get; set; }
    }
}
