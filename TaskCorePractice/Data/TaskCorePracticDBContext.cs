using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskCorePractice.Models
{
    public partial class TaskCorePracticDBContext : DbContext
    {
        public TaskCorePracticDBContext()
        {
        }

        public TaskCorePracticDBContext(DbContextOptions<TaskCorePracticDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItemTask> ItemTask { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserTask> UserTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<ItemTask>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserTask)
                    .WithMany(p => p.ItemTask)
                    .HasForeignKey(d => d.UserTaskId)
                    .HasConstraintName("FK_ItemTask_UserTask");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.Property(e => e.Begin).HasColumnType("datetime");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTask)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserTask_User");
            });
        }
    }
}
