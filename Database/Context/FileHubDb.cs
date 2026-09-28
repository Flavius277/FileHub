using Microsoft.EntityFrameworkCore;
using FileHub.Database.Classes;
namespace FileHub.Database.Context
{
    public class FileHubDb : DbContext
    {
        public FileHubDb(DbContextOptions<FileHubDb> options) : base(options)
        {
        }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<ActivityLogs> ActivityLogs { get; set; }
        public DbSet<DocumentShares> DocumentShares { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Folders> Folders { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorites>().HasOne<Users>().WithMany().HasForeignKey(f => f.UserId);
            modelBuilder.Entity<Favorites>().HasOne<Documents>().WithMany().HasForeignKey(f => f.DocumentId);

            modelBuilder.Entity<DocumentShares>().HasOne<Users>().WithMany().HasForeignKey(f => f.UserId);
            modelBuilder.Entity<DocumentShares>().HasOne<Documents>().WithMany().HasForeignKey(f => f.DocumentId);

            modelBuilder.Entity<ActivityLogs>().HasOne<Users>().WithMany().HasForeignKey(f => f.UserId);
            modelBuilder.Entity<ActivityLogs>().HasOne<Documents>().WithMany().HasForeignKey(f => f.DocumentId);

            modelBuilder.Entity<Folders>().HasOne<Folders>().WithMany().HasForeignKey(f => f.ParentFolderId);
        }
    }
}