using Microsoft.EntityFrameworkCore;
using WDT2020_a3.Models;

namespace WDT2020_a3.Services.DataManager.DBContexts
{
    public partial class AdminContext : DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        { }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<BillPays> BillPays { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Logins> Logins { get; set; }
        public virtual DbSet<Payees> Payees { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountNumber);

                entity.HasIndex(e => e.CustomerId);

                entity.Property(e => e.AccountNumber).ValueGeneratedNever();

                entity.Property(e => e.AccountType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<BillPays>(entity =>
            {
                entity.HasKey(e => e.BillPayId);

                entity.HasIndex(e => e.AccountNumber);

                entity.HasIndex(e => e.PayeeId);

                entity.Property(e => e.BillPayId)
                    .HasColumnName("BillPayID")
                    .ValueGeneratedNever();

                entity.Property(e => e.PayeeId).HasColumnName("PayeeID");

                entity.Property(e => e.Period)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.BillPays)
                    .HasForeignKey(d => d.AccountNumber);

                entity.HasOne(d => d.Payee)
                    .WithMany(p => p.BillPays)
                    .HasForeignKey(d => d.PayeeId);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.State).HasMaxLength(3);

                entity.Property(e => e.Tfn)
                    .HasColumnName("TFN")
                    .HasMaxLength(9);
            });

            modelBuilder.Entity<Logins>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.CustomerId);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(8);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Password).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<Payees>(entity =>
            {
                entity.HasKey(e => e.PayeeId);

                entity.Property(e => e.PayeeId)
                    .HasColumnName("PayeeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(40);

                entity.Property(e => e.PayeeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.State).HasMaxLength(20);
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.HasIndex(e => e.AccountNumber);

                entity.Property(e => e.TransactionId)
                    .HasColumnName("TransactionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(255);

                entity.Property(e => e.TransactionType)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.HasOne(d => d.AccountNumberNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountNumber);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
