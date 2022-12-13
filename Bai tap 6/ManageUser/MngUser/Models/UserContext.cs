using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MngUser.Models;

public partial class UserContext : DbContext
{
    public UserContext()
    {
    }

    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<LstUser> LstUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I6S80K2\\SQLEXPRESS;Database=User; Trust Server Certificate=true;User Id=sa;Password=123456;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group");

            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.GroupName).HasMaxLength(250);
        });

        modelBuilder.Entity<LstUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User");

            entity.ToTable("LstUser");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(250);

            entity.HasOne(d => d.Group).WithMany(p => p.LstUsers)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_LstUser_Group");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Action).HasMaxLength(250);
            entity.Property(e => e.Controller).HasMaxLength(250);
            entity.Property(e => e.RoleName).HasMaxLength(250);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Role1");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_LstUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
