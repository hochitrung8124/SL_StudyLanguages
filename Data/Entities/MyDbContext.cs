using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SpacedRepetitionLog> SpacedRepetitionLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VocabularyItem> VocabularyItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TRUNGHC\\SQLEXPRESS;Initial Catalog=SL_StudyLanguages;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SpacedRepetitionLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpacedRe__3214EC07636782ED");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ReviewDate).HasColumnType("datetime");

            entity.HasOne(d => d.VocabItem).WithMany(p => p.SpacedRepetitionLogs)
                .HasForeignKey(d => d.VocabItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SpacedRep__Vocab__403A8C7D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C5FF501F9");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534914530EC").IsUnique();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        modelBuilder.Entity<VocabularyItem>(entity =>
        {
            entity.HasKey(e => e.VocabItemId).HasName("PK__Vocabula__8E5339E884F2D797");

            entity.Property(e => e.VocabItemId).ValueGeneratedNever();
            entity.Property(e => e.AudioUrl).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Meaning).HasMaxLength(255);
            entity.Property(e => e.Topic).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Word).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.VocabularyItems)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vocabular__UserI__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
