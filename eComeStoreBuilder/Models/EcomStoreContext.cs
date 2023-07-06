using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eComeStoreBuilder.Models;

public partial class EcomStoreContext : DbContext
{
    public EcomStoreContext()
    {
    }

    public EcomStoreContext(DbContextOptions<EcomStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StoreRequestQue> StoreRequestQues { get; set; }

    public virtual DbSet<WebsiteType> WebsiteTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-44PH3BF\\SQLEXPRESS;Initial Catalog=EcomStore;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StoreRequestQue>(entity =>
        {
            entity.ToTable("StoreRequestQue");

            entity.Property(e => e.Business).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.StoreTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<WebsiteType>(entity =>
        {
            entity.ToTable("WebsiteType");

            entity.Property(e => e.StoreType).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
