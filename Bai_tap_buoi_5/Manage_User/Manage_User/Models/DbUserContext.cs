using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Manage_User.Models;

public partial class DbUserContext : DbContext
{
    public DbUserContext()
    {
    }

    public DbUserContext(DbContextOptions<DbUserContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DbUser> DbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-I6S80K2\\SQLEXPRESS;Database=Db_User ; Trust Server Certificate=true;User Id=sa;Password=123456;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DB_USER__3214EC073F1A80DD");

            entity.ToTable("DB_USER");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
