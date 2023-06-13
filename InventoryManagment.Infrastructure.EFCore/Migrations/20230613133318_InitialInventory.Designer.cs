﻿// <auto-generated />
using System;
using InventoryManagment.Infrastructure.EFCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventoryManagment.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    [Migration("20230613133318_InitialInventory")]
    partial class InitialInventory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InventoryManagment.Domains.Agg.Inventory.Inventory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemove")
                        .HasColumnType("bit");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("InventoryManagment.Domains.Agg.Inventory.Inventory", b =>
                {
                    b.OwnsMany("InventoryManagment.Domains.Agg.Inventory.InventoryOperation", "Operations", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<long>("Count")
                                .HasColumnType("bigint");

                            b1.Property<long>("CurrentCount")
                                .HasColumnType("bigint");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(1000)
                                .HasColumnType("nvarchar(1000)");

                            b1.Property<long>("InventoryId")
                                .HasColumnType("bigint");

                            b1.Property<bool>("Operation")
                                .HasColumnType("bit");

                            b1.Property<DateTime>("OperationDate")
                                .HasColumnType("datetime2");

                            b1.Property<long>("OperatorId")
                                .HasColumnType("bigint");

                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("InventoryId");

                            b1.ToTable("InventoryOperations", (string)null);

                            b1.WithOwner("Inventory")
                                .HasForeignKey("InventoryId");

                            b1.Navigation("Inventory");
                        });

                    b.Navigation("Operations");
                });
#pragma warning restore 612, 618
        }
    }
}