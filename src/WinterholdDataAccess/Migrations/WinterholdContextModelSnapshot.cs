﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WinterholdDataAccess.Models;

#nullable disable

namespace WinterholdDataAccess.Migrations
{
    [DbContext(typeof(WinterholdContext))]
    partial class WinterholdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WinterholdDataAccess.Models.Account", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Username");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("CustomerNumber")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerNumber");

                    b.ToTable("Address", (string)null);
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Author", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeceasedDate")
                        .HasColumnType("date");

                    b.Property<string>("Education")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Summary")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Book", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsBorrowed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Summary")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("TotalPage")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryName");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Category", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Bay")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Isle")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Name");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Customer", b =>
                {
                    b.Property<string>("MembershipNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("MembershipExpireDate")
                        .HasColumnType("date");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("MembershipNumber");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Loan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("BookCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CustomerNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("date");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("BookCode");

                    b.HasIndex("CustomerNumber");

                    b.ToTable("Loan", (string)null);
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Address", b =>
                {
                    b.HasOne("WinterholdDataAccess.Models.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerNumber")
                        .IsRequired()
                        .HasConstraintName("FK_Address_Customer");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Book", b =>
                {
                    b.HasOne("WinterholdDataAccess.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("FK_Book_Author");

                    b.HasOne("WinterholdDataAccess.Models.Category", "CategoryNameNavigation")
                        .WithMany("Books")
                        .HasForeignKey("CategoryName")
                        .IsRequired()
                        .HasConstraintName("FK_Book_Category");

                    b.Navigation("Author");

                    b.Navigation("CategoryNameNavigation");
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Loan", b =>
                {
                    b.HasOne("WinterholdDataAccess.Models.Book", "BookCodeNavigation")
                        .WithMany("Loans")
                        .HasForeignKey("BookCode")
                        .IsRequired()
                        .HasConstraintName("FK_Loan_Book");

                    b.HasOne("WinterholdDataAccess.Models.Customer", "CustomerNumberNavigation")
                        .WithMany("Loans")
                        .HasForeignKey("CustomerNumber")
                        .IsRequired()
                        .HasConstraintName("FK_Loan_Customer");

                    b.Navigation("BookCodeNavigation");

                    b.Navigation("CustomerNumberNavigation");
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Book", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("WinterholdDataAccess.Models.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Loans");
                });
#pragma warning restore 612, 618
        }
    }
}
