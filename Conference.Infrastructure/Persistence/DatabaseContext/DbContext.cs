using System;
using System.Collections.Generic;
using Conference.Infrastructure.Persistence.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Conference.Infrastructure.Persistence.DatabaseContext;

public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendee> Attendees { get; set; }

    public virtual DbSet<DatabaseModels.Conference> Conferences { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<SeatsAvailability> SeatsAvailabilities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=sa@2025*;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendee__3214EC07C2DE7C16");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DatabaseModels.Conference>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Conferen__3214EC0729567E61");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0714DFF511");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Conference).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Orders_Conferences_ConferenceId");

            entity.HasMany(d => d.Attendees).WithMany(p => p.Orders)
                .UsingEntity<Dictionary<string, object>>(
                    "OrderItem",
                    r => r.HasOne<Attendee>().WithMany()
                        .HasForeignKey("AttendeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Fk_OrderItems_Attendees_AttendeeId"),
                    l => l.HasOne<Order>().WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Fk_OrderItems_Orders_OrderId"),
                    j =>
                    {
                        j.HasKey("OrderId", "AttendeeId").HasName("Pk_OrderItems");
                        j.ToTable("OrderItems");
                    });
        });

        modelBuilder.Entity<SeatsAvailability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SeatsAva__3214EC0719E8A284");

            entity.ToTable("SeatsAvailability");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Conference).WithMany(p => p.SeatsAvailabilities)
                .HasForeignKey(d => d.ConferenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_SeatsAvailability_Conferences_ConferenceId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
