﻿// <auto-generated />
using EfCoreTestApp.Respitory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EfCoreTestApp.Migrations
{
    [DbContext(typeof(FolderContext))]
    [Migration("20221115090530_InitialCreate19")]
    partial class InitialCreate19
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EfCoreTestApp.Models.Folder", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("folder");
                });

            modelBuilder.Entity("EfCoreTestApp.Models.Folder", b =>
                {
                    b.HasOne("EfCoreTestApp.Models.Folder", "Parent")
                        .WithMany("SubFolders")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("EfCoreTestApp.Models.Folder", b =>
                {
                    b.Navigation("SubFolders");
                });
#pragma warning restore 612, 618
        }
    }
}
