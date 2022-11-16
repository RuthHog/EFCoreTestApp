
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EfCoreTestApp.Models;
using System.Reflection.Metadata;

namespace EfCoreTestApp.Respitory
{
    public class FolderContext : DbContext
    {



        public FolderContext(DbContextOptions<FolderContext> options) : base(options)
        {
        }
        public DbSet<Folder> folder { get; set; }

        public DbSet<Item> items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Folder>(entity =>
            {
                entity
                    .HasMany(x => x.SubFolders)
                    .WithOne()
                    .HasForeignKey(x => x.ParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Item>()
                .HasKey(x => x.ItemNo);

            modelBuilder.Entity<Item>()
                .HasMany(x => x.Children);



        }

    }
}
