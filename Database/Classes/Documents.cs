namespace FileHub.Database.Classes
{
    public class Documents
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string OwnerId { get; set; } = "System";
        public DateOnly CreateAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
