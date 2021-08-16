using Microsoft.EntityFrameworkCore;
using Mov.DataModels.Crew;
using Mov.DataModels.Movies;
using Mov.DataModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Mutual
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(m => m.Movies)// bu alan iki tablonun silinme isleminde karmasikliga
                .WithOne(u => u.User)                         //sebep oldugu icin eklendi.  
                .HasForeignKey(t => t.UserId) // User(Admin) silindiginde film tablosuna hicbir sey yapma (User soft delete yapilmali)
                .OnDelete(DeleteBehavior.NoAction); // Update icin gerek yok cunku Id tutuldugu icin update edilemez bir alan.
                                                   // burada iliskiyi dogru vermek lazım yani enttiy kısmı icinde liste tutan kısım olmali.
         
        }
    }
}
