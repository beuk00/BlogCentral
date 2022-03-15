using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogCentralApp.Data
{
    public class DataContext:IdentityDbContext
    {
       

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Author>Authors { get; set; }
        
        public DbSet<BlogPost> BlogPosts { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


           


            modelBuilder.Entity<BlogPost>()
               .HasKey(a => a.Id);
            modelBuilder.Entity<BlogPost>()
                .Property(a => a.Title).IsRequired();


            modelBuilder.Entity<Author>()
                .Property(a=>a.FirstName).IsRequired();
            modelBuilder.Entity<Author>()
               .Property(a => a.LastName).IsRequired();

            modelBuilder.Entity<Author>()
               .Property(a => a.UserName).IsRequired();


           




            PasswordHasher<Author> hasher = new PasswordHasher<Author>();
            string hashedPassword = hasher.HashPassword(new Author(), "Test");

            var authors = new Author[]
            {
                new Author { Id = new Guid("09f8c9a1-2263-4eb5-8fd9-600ba680b94a").ToString(),FirstName="Ibrahim",LastName="Awad", UserName = "Ibrahim", NormalizedUserName = "IBRAHIM", Email = "ibrahim@intec.be", NormalizedEmail = "IBRAHIM@INTEC.BE", EmailConfirmed = true, PasswordHash = hashedPassword},


                new Author { Id = new Guid("ce8a91ab-41ca-4e08-8cae-40d4cda1a938").ToString(), UserName = "Quinten",FirstName="Quinten",LastName="De Clerck", NormalizedUserName = "QUINTEN", Email = "quinten@intec.be", NormalizedEmail = "QUINTEN@INTEC.BE", EmailConfirmed = true, PasswordHash = hashedPassword}
            };


           

            var blogPosts = new BlogPost[]
            {
                new BlogPost{Id=1, Title="BlogPost1",Content="content1",AuthorId= "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", Date = DateTime.Now.AddDays(-1)},
                new BlogPost{Id=2, Title="BlogPost2",Content="content2",AuthorId= "09f8c9a1-2263-4eb5-8fd9-600ba680b94a",Date = DateTime.Now.AddDays(-2) },
                new BlogPost{Id=3, Title="BlogPost3",Content="content3",AuthorId= "09f8c9a1-2263-4eb5-8fd9-600ba680b94a", Date = DateTime.Now.AddDays(-3)},
            };

            modelBuilder.Entity<Author>().HasData(authors);
            modelBuilder.Entity<BlogPost>().HasData(blogPosts); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
