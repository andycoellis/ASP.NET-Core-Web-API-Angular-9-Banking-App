﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WDT2020_a2.Data;

namespace WDT2020_a2.Migrations
{
    [DbContext(typeof(NwabContext))]
    [Migration("20200204005814_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WDT2020_a2.Models.Account", b =>
                {
                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AccountNumber");

                    b.HasIndex("CustomerID");

                    b.ToTable("Accounts");

                    b.HasCheckConstraint("CH_Account_AccountNumber", "len(AccountNumber) = 4");

                    b.HasCheckConstraint("CH_Account_AccountType", "AccountType in ('C', 'S')");
                });

            modelBuilder.Entity("WDT2020_a2.Models.BillPay", b =>
                {
                    b.Property<int>("BillPayID")
                        .HasColumnType("int");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<bool>("BlockedBillPay")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PayeeID")
                        .HasColumnType("int");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("ScheduleDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BillPayID");

                    b.HasIndex("AccountNumber");

                    b.HasIndex("PayeeID");

                    b.ToTable("BillPays");

                    b.HasCheckConstraint("CH_BillPay_BillPayID", "len(BillPayID) = 4");

                    b.HasCheckConstraint("CH_BillPay_Period", "Period in ('M', 'Q', 'A', 'S')");

                    b.HasCheckConstraint("CH_BillPay_Amount", "Amount > 0");
                });

            modelBuilder.Entity("WDT2020_a2.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("TFN")
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");

                    b.HasCheckConstraint("CH_Customer_CustomerID", "len(CustomerID) = 4");

                    b.HasCheckConstraint("CH_Customer_PostCode", "len(PostCode) = 4");
                });

            modelBuilder.Entity("WDT2020_a2.Models.Login", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<bool>("BlockedAccount")
                        .HasColumnType("bit");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PasswordAttempts")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Logins");

                    b.HasCheckConstraint("CH_Login_CustomerID", "len(CustomerID) = 4");

                    b.HasCheckConstraint("CH_Login_Password", "len(Password) = 64");
                });

            modelBuilder.Entity("WDT2020_a2.Models.Payee", b =>
                {
                    b.Property<int>("PayeeID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("PayeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("PayeeID");

                    b.ToTable("Payees");

                    b.HasCheckConstraint("CH_Payee_PayeeID", "len(PayeeID) = 4");
                });

            modelBuilder.Entity("WDT2020_a2.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .HasColumnType("int");

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("DestAccount")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("TransactionID");

                    b.HasIndex("AccountNumber");

                    b.ToTable("Transactions");

                    b.HasCheckConstraint("CH_Transaction_TransactionID", "len(TransactionID) = 4");

                    b.HasCheckConstraint("CH_Transaction_TransactionType", "TransactionType in ('D', 'W', 'T', 'S', 'B')");

                    b.HasCheckConstraint("CH_Transaction_Amount", "Amount > 0");
                });

            modelBuilder.Entity("WDT2020_a2.Models.Account", b =>
                {
                    b.HasOne("WDT2020_a2.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WDT2020_a2.Models.BillPay", b =>
                {
                    b.HasOne("WDT2020_a2.Models.Account", "Account")
                        .WithMany("BillPays")
                        .HasForeignKey("AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WDT2020_a2.Models.Payee", "Payee")
                        .WithMany("BillPays")
                        .HasForeignKey("PayeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WDT2020_a2.Models.Login", b =>
                {
                    b.HasOne("WDT2020_a2.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WDT2020_a2.Models.Transaction", b =>
                {
                    b.HasOne("WDT2020_a2.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
