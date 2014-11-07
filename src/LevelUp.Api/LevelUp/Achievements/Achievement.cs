namespace LevelUp.Api.LevelUp.Achievements
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Points { get; set; }
        public byte[] Image { get; set; }
        public string ImageUrl { get; set; }
        public string QRCodeText { get; set; }
    }
}