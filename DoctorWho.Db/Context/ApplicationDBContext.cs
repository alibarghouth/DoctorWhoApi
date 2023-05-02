using DoctorWho.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enemy>()
               .HasKey(e => e.Id);
            modelBuilder.Entity<Author>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Companion>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Episode>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Enemy>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<EpisodeEnemy>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<EpisodeCompanion>()
                .HasKey(e => e.Id);
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
