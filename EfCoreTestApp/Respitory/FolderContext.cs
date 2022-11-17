
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Folder>(entity =>
            {
                entity
                    .HasOne(x => x.Parent)
                    .WithMany(x => x.SubFolders)
                    .HasForeignKey(x => x.ParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

    }
}
