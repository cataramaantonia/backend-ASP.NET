using Microsoft.EntityFrameworkCore;
using proiect_daw.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiect_daw.Data
{
    public class ProiectContext : DbContext
    {
        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many

            modelBuilder.Entity<Director>()
                .HasMany(d => d.Movies)
                .WithOne(m => m.Director);

            // One to One

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Review)
                .WithOne(r => r.Movie);
            
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Budget)
                .WithOne(b => b.Movie);

            // Many to Many

            modelBuilder.Entity<MovieActor>().HasKey(ma => new { ma.MovieId, ma.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(ma => ma.ActorId);


            base.OnModelCreating(modelBuilder);
        }

    }
}
