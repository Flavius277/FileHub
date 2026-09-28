namespace FileHub.Database.Classes
{
    public class Folders
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ParentFolderId { get; set; }
        public string OwnerId { get; set; } = "System";
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}