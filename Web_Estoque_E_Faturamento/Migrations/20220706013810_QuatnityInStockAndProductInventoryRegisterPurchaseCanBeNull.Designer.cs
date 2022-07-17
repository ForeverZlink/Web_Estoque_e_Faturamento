﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Web_Estoque_E_Faturamento.Migrations
{
    [DbContext(typeof(MvcProductContext))]
    [Migration("20220706013810_QuatnityInStockAndProductInventoryRegisterPurchaseCanBeNull")]
    partial class QuatnityInStockAndProductInventoryRegisterPurchaseCanBeNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Web_Estoque_E_Faturamento._Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("DateOfCreation")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Web_Estoque_E_Faturamento._Models.ProductInventory", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<float?>("QuantityInStock")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductInventory");
                });

            modelBuilder.Entity("Web_Estoque_E_Faturamento._Models.ProductInventoryRegisterPurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("DateOfPurchase")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("PriceOfPurchase")
                        .HasColumnType("real");

                    b.Property<float>("PriceProductUnity")
                        .HasColumnType("real");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductInventoryId")
                        .HasColumnType("integer");

                    b.Property<int>("ProviderId")
                        .HasColumnType("integer");

                    b.Property<float>("QuantityBuyed")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductInventoryId");

                    b.HasIndex("ProviderId");

                    b.ToTable("ProductInventoryRegisterPurchase");
                });

            modelBuilder.Entity("Web_Estoque_E_Faturamento._Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Andress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("Web_Estoque_E_Faturamento._Models.ProductInventory", b =>
                {
                    b.HasOne("Web_Estoque_E_Faturamento._Models.Product", "Product")
                        .WithOne("ProductInventory")
                        .HasForeignKey("Web_Estoque_E_Faturamento._Models.ProductInventory", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Web_Estoque_E_Faturamento._Models.ProductInventoryRegisterPurchase", b =>
                {
                    b.HasOne("Web_Estoque_E_Faturamento._Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_Estoque_E_Faturamento._Models.ProductInventory", null)
                        .WithMany("ProductInventoryRegisterPurchase")
                        .HasForeignKey("ProductInventoryId");

                    b.HasOne("Web_Estoque_E_Faturamento._Models.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Web_Estoque_E_Faturamento._Models.Product", b =>
                {
                    b.Navigation("ProductInventory");
                });

            modelBuilder.Entity("Web_Estoque_E_Faturamento._Models.ProductInventory", b =>
                {
                    b.Navigation("ProductInventoryRegisterPurchase");
                });
#pragma warning restore 612, 618
        }
    }
}