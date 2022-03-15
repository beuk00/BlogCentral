using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogCentralApp.Data
{
    public class BlogDbContext : IdentityDbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API
            modelBuilder.Entity<BlogPost>()
                .HasKey(bp => bp.Id);

            modelBuilder.Entity<BlogPost>()
                .Property(bp => bp.Id)
                .ValueGeneratedOnAdd();

            PasswordHasher<Author> hasher = new PasswordHasher<Author>();
            string hashedpassword = hasher.HashPassword(new Author(), "Test-1234");

            var authors = new Author[]
            {
                new Author { 
                    Id = "b2e4c2ee-7062-490b-ab51-104766dd2ed7",
                    FirstName = "Max",
                    LastName = "Poniatowski",
                    UserName = "Max",
                    NormalizedUserName = "MAX",
                    Email = "max@intec.be",
                    NormalizedEmail = "MAX@INTEC.BE",
                    EmailConfirmed = true,
                    PasswordHash =  hashedpassword,
                },        
            };

            var blogposts = new BlogPost[]
            {
                new BlogPost
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Title = "The Apocalypse",
                    Content = "The End is coming, chapter 999...",
                    AuthorId = "b2e4c2ee-7062-490b-ab51-104766dd2ed7",
                }
            };

            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<BlogPost>().HasData(blogposts);

            base.OnModelCreating(modelBuilder);
        }
    }
}
