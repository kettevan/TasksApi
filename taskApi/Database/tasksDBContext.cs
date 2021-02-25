using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace taskApi.Database
{
    public partial class tasksDBContext : DbContext
    {
        public tasksDBContext()
        {
        }

        public tasksDBContext(DbContextOptions<tasksDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<StatusFlow> StatusFlows { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Data Source=localhost;Initial Catalog=tasksDB;User ID=root;Password=12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status", "tasksDB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Status1)
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<StatusFlow>(entity =>
            {
                entity.ToTable("statusFlow", "tasksDB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FromStatusId).HasColumnName("fromStatusID");

                entity.Property(e => e.ToStatusId).HasColumnName("toStatusID");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task", "tasksDB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.StatusId).HasColumnName("statusID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.WorkingHours).HasColumnName("workingHours");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "tasksDB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .HasColumnName("firstname");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(30)
                    .HasColumnName("fullname");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .HasColumnName("lastname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
