using BookMarkManager.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookMarkManager.Dal
{
    public class BookmarkManagerDataContext : DbContext, IDBContext
    {
        public BookmarkManagerDataContext(DbContextOptions<BookmarkManagerDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.Entity<Folder>()
                .HasMany(c => c.BookMarks)
                .WithOne(e => e.Folder)
                .OnDelete(DeleteBehavior.Cascade);


            var folder = new Folder()
            {
                Id = 1,
                Name = "OnlineShops",
                Description = "This folder Contains Online Shops",
                Createdat = DateTime.Now,
                Updatedat = DateTime.Now,
            };
            modelBuilder.Entity<Folder>()
                .HasData(folder);
            var folder2 = new Folder()
            {
                Id = 2,
                Name = "NEWS",
                Description = "This folder Contains News",
                Createdat = DateTime.Now,
                Updatedat = DateTime.Now,
            };
            modelBuilder.Entity<Folder>()
                .HasData(folder2);

            modelBuilder.Entity<BookMark>()
                     .HasData(new BookMark()
                     {
                         Id = 1,
                         Name = "IKEA",
                         URL = "https://www.ikea.com/",
                         FolderId = folder.Id,
                         Createdat = DateTime.Now,
                         Updatedat = DateTime.Now,
                     });
            modelBuilder.Entity<BookMark>()
                    .HasData(new BookMark()
                    {
                        Id = 2,
                        Name = "Amazon",
                        URL = "https://www.amazon.de/",
                        FolderId = folder.Id,
                        Createdat = DateTime.Now,
                        Updatedat = DateTime.Now,
                    });

            modelBuilder.Entity<BookMark>()
                     .HasData(new BookMark()
                     {
                         Id = 3,
                         Name = "BBC",
                         URL = "https://www.bbc.co.uk/",
                         FolderId = folder2.Id,
                         Createdat = DateTime.Now,
                         Updatedat = DateTime.Now,
                     });

            modelBuilder.Entity<BookMark>()
                    .HasData(new BookMark()
                    {
                        Id = 4,
                        Name = "Wolt",
                        URL = "https://wolt.com/",
                        Createdat = DateTime.Now,
                        Updatedat = DateTime.Now,
                    });


        }
        public DbSet<BookMark> BookMarks { get; set; }
        public DbSet<Folder> Folders { get; set; }
    }
}
