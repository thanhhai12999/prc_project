﻿using Microsoft.EntityFrameworkCore;

namespace PRC_Project.Data.Models
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer("Server=tcp:prc-project-server.database.windows.net,1433;Initial Catalog=DB_PRC_Project;Persist Security Info=False;User ID=thanhhai;Password=Prc123456;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).IsUnicode(false);

                entity.Property(e => e.InsBy).IsUnicode(false);

                entity.Property(e => e.InsDatetime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdBy).IsUnicode(false);

                entity.Property(e => e.UpdDatetime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.OrderId).IsUnicode(false);

                entity.Property(e => e.ProductId).IsUnicode(false);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetail)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Product");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BCF4A1EE2E2");

                entity.Property(e => e.OrderId).IsUnicode(false);

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.InsBy).IsUnicode(false);

                entity.Property(e => e.InsDatetime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Note).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.UpdBy).IsUnicode(false);

                entity.Property(e => e.UpdDatetime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).IsUnicode(false);

                entity.Property(e => e.CategoryId).IsUnicode(false);

                entity.Property(e => e.InsBy).IsUnicode(false);

                entity.Property(e => e.InsDatetime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Photo).IsUnicode(false);

                entity.Property(e => e.PhotoForOrder).IsUnicode(false);

                entity.Property(e => e.UpdBy).IsUnicode(false);

                entity.Property(e => e.UpdDatetime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.Property(e => e.InsBy).IsUnicode(false);

                entity.Property(e => e.InsDatetime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleNm).IsUnicode(false);

                entity.Property(e => e.UpdBy).IsUnicode(false);

                entity.Property(e => e.UpdDatetime).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Users__536C85E57EFBA568");

                entity.Property(e => e.Username).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.InsBy).IsUnicode(false);

                entity.Property(e => e.InsDatetime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.Property(e => e.Photo).IsUnicode(false);

                entity.Property(e => e.RoleId).IsUnicode(false);

                entity.Property(e => e.UpdBy).IsUnicode(false);

                entity.Property(e => e.UpdDatetime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
