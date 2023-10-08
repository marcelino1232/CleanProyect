using CleanProyect.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanProyect.Infrastructure
{
    public class StreamerDbContext : DbContext
    {
        //public StreamerDbContext(DbContextOptions<StreamerDbContext> options)
        //{

        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=MARCELINO-CRM;Initial Catalog=Streamer;Integrated Security=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
               .HasMany(x => x.Videos)
               .WithOne(x => x.Streamer)
               .HasForeignKey(x => x.StreamerId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasMany(p => p.Actors)
                .WithMany(t => t.Videos)
                .UsingEntity<VideoActores>(
                  pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
                );

            modelBuilder.Entity<Video>()
                .HasOne(x => x.Director)
                .WithOne(x => x.Video)
                .HasForeignKey<Director>(x => x.VideoId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }

    }
}
