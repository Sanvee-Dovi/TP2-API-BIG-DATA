using Microsoft.EntityFrameworkCore;
using TP2_API_BIG_DATA.Models;


namespace TP2_API_BIG_DATA
{
    public class DbContexts : DbContext
    {
        public DbContexts (DbContextOptions<DbContexts> options) : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {
                entity.ToTable("film"); 

                entity.HasKey(e => e.FilmId);

                entity.Property(e => e.FilmId).HasColumnName("film_id");
                entity.Property(e => e.Title).HasColumnName("title");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.ReleaseYear).HasColumnName("release_year");
                entity.Property(e => e.LanguageId).HasColumnName("language_id");
                entity.Property(e => e.RentalDuration).HasColumnName("rental_duration");
                entity.Property(e => e.RentalRate).HasColumnName("rental_rate");
                entity.Property(e => e.Length).HasColumnName("length");
                entity.Property(e => e.ReplacementCost).HasColumnName("replacement_cost");
                entity.Ignore(e => e.Rating);
                entity.Property(e => e.LastUpdate).HasColumnName("last_update");
                entity.Property(e => e.SpecialFeatures).HasColumnName("special_features");
                entity.Property(e => e.Fulltext).HasColumnName("fulltext");
            });
        }
    }
}
