using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NotesToUniverse.Entities;

namespace NotesToUniverse.DataAccess.Concrete.EfCore
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=NoteToUniverse;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Note>()
            //    .HasMany(n => n.Comments)
            //    .WithOne(c => c.Note).IsRequired()
            //    .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Note>()
            //    .HasMany(n => n.Likes)
            //    .WithOne(c => c.Note).IsRequired()
            //    .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<NoteCategory>()
                .HasKey(n => new {n.CategoryId, n.NoteId});
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Liked> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
