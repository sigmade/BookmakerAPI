using Microsoft.EntityFrameworkCore;
namespace BookmakerAPI.Models
{
    public class BookmakerDBContext : DbContext
    {
        public BookmakerDBContext(DbContextOptions<BookmakerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.FirstTeamId)
                    .HasConstraintName("FK_FirstTeam");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.SecondTeamId)
                    .HasConstraintName("FK_SecondTeam");
            });
        }

        }
}
