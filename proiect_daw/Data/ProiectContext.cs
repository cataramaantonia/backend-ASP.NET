using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proiect_daw.Entities;

namespace proiect_daw.Data
{
    public class ProiectContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
                           UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>,
                           IdentityUserToken<int>>
    {
        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }
        public DbSet<SessionToken> SessionTokens { get; set; }
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

            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });
                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);
            });
        }

    }
}
