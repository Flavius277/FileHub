namespace FileHub.Database.Classes;

public class DocumentShares
{
    public int Id { get; set; }
    public int DocumentId { get; set; }
    public int UserId { get; set; }
    public string Permission { get; set; } = string.Empty;
    public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
}
