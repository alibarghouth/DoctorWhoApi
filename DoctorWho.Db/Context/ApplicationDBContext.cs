using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enemy>()
              .Property(e => e.Name)
              .HasColumnType("VARCHAR(20)");
            modelBuilder.Entity<Enemy>()
                .Property(e => e.Description)
                .HasColumnType("VARCHAR(20)");
            modelBuilder.Entity<Episode>()
                .Property(e => e.Episodetype)
                .HasColumnType("VARCHAR(20)");
            modelBuilder.Entity<Episode>()
                .Property(e => e.Title)
                .HasColumnType("VARCHAR(30)");
            modelBuilder.Entity<Episode>()
                .Property(e => e.Title)
                .HasColumnType("VARCHAR(50)");
            modelBuilder.Entity<Companion>()
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(20)");
            modelBuilder.Entity<Companion>()
                .Property(e => e.WhoPlayed)
                .HasColumnType("VARCHAR(20)");
            modelBuilder.Entity<Doctor>()
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(20)");
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Enemy> Enemies { get; set; }
        public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; }
        public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; }
    }
}
