﻿// <auto-generated />
using System;
using BikeStores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BikeStores.Migrations
{
    [DbContext(typeof(BikeStoresContext))]
    [Migration("20200817190724_unicode")]
    partial class unicode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BikeStores.Models.Brands", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("brand_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnName("brand_name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(true);

                    b.HasKey("BrandId")
                        .HasName("PK__brands__5E5A8E2700A37FD4");

                    b.ToTable("brands","production");
                });

            modelBuilder.Entity("BikeStores.Models.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("category_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnName("category_name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(true);

                    b.HasKey("CategoryId")
                        .HasName("PK__categori__D54EE9B42406235C");

                    b.ToTable("categories","production");
                });

            modelBuilder.Entity("BikeStores.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("customer_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(true);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(true);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(true);

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(true);

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(true);

                    b.Property<string>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(true);

                    b.HasKey("CustomerId")
                        .HasName("PK__customer__CD65CB85C1F1441C");

                    b.ToTable("customers","sales");
                });

            modelBuilder.Entity("BikeStores.Models.OrderItems", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("order_id")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnName("item_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnName("discount")
                        .HasColumnType("decimal(4, 2)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnName("list_price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ItemId")
                        .HasName("PK__order_it__837942D4F27EA544");

                    b.HasIndex("ProductId");

                    b.ToTable("order_items","sales");
                });

            modelBuilder.Entity("BikeStores.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("order_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnName("customer_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("order_date")
                        .HasColumnType("date");

                    b.Property<byte>("OrderStatus")
                        .HasColumnName("order_status")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnName("required_date")
                        .HasColumnType("date");

                    b.Property<DateTime?>("ShippedDate")
                        .HasColumnName("shipped_date")
                        .HasColumnType("date");

                    b.Property<int>("StaffId")
                        .HasColumnName("staff_id")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("int");

                    b.HasKey("OrderId")
                        .HasName("PK__orders__4659622989971256");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.HasIndex("StoreId");

                    b.ToTable("orders","sales");
                });

            modelBuilder.Entity("BikeStores.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("product_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnName("brand_id")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("int");

                    b.Property<decimal>("ListPrice")
                        .HasColumnName("list_price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<short>("ModelYear")
                        .HasColumnName("model_year")
                        .HasColumnType("smallint");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("product_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("ProductId")
                        .HasName("PK__products__47027DF5396743D8");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("products","production");
                });

            modelBuilder.Entity("BikeStores.Models.Staffs", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("staff_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Active")
                        .HasColumnName("active")
                        .HasColumnType("tinyint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("ManagerId")
                        .HasColumnName("manager_id")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("int");

                    b.HasKey("StaffId")
                        .HasName("PK__staffs__1963DD9C02C2172F");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UQ__staffs__AB6E6164E8C3079A");

                    b.HasIndex("ManagerId");

                    b.HasIndex("StoreId");

                    b.ToTable("staffs","sales");
                });

            modelBuilder.Entity("BikeStores.Models.Stocks", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnName("store_id")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("int");

                    b.HasKey("StoreId", "ProductId")
                        .HasName("PK__stocks__E68284D3140482EB");

                    b.HasIndex("ProductId");

                    b.ToTable("stocks","production");
                });

            modelBuilder.Entity("BikeStores.Models.Stores", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("store_id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnName("city")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("varchar(25)")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("State")
                        .HasColumnName("state")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnName("store_name")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Street")
                        .HasColumnName("street")
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("ZipCode")
                        .HasColumnName("zip_code")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("StoreId")
                        .HasName("PK__stores__A2F2A30CCE8FDDAE");

                    b.ToTable("stores","sales");
                });

            modelBuilder.Entity("BikeStores.Models.OrderItems", b =>
                {
                    b.HasOne("BikeStores.Models.Orders", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__order_ite__order__3A81B327")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStores.Models.Products", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__order_ite__produ__3B75D760")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeStores.Models.Orders", b =>
                {
                    b.HasOne("BikeStores.Models.Customers", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__orders__customer__34C8D9D1")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BikeStores.Models.Staffs", "Staff")
                        .WithMany("Orders")
                        .HasForeignKey("StaffId")
                        .HasConstraintName("FK__orders__staff_id__36B12243")
                        .IsRequired();

                    b.HasOne("BikeStores.Models.Stores", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__orders__store_id__35BCFE0A")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeStores.Models.Products", b =>
                {
                    b.HasOne("BikeStores.Models.Brands", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK__products__brand___29572725")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStores.Models.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__products__catego__286302EC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeStores.Models.Staffs", b =>
                {
                    b.HasOne("BikeStores.Models.Staffs", "Manager")
                        .WithMany("InverseManager")
                        .HasForeignKey("ManagerId")
                        .HasConstraintName("FK__staffs__manager___31EC6D26");

                    b.HasOne("BikeStores.Models.Stores", "Store")
                        .WithMany("Staffs")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__staffs__store_id__30F848ED")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BikeStores.Models.Stocks", b =>
                {
                    b.HasOne("BikeStores.Models.Products", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__stocks__product___3F466844")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeStores.Models.Stores", "Store")
                        .WithMany("Stocks")
                        .HasForeignKey("StoreId")
                        .HasConstraintName("FK__stocks__store_id__3E52440B")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
