using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WiseThing.Data.Respository
{
    public partial class WisethingPortalContext : DbContext
    {
      
        public WisethingPortalContext(DbContextOptions<WisethingPortalContext> options)
            : base(options)
        {
        }

        internal virtual DbSet<Device> Devices { get; set; }
        internal virtual DbSet<User> Users { get; set; }
        internal virtual DbSet<Userdevice> Userdevices { get; set; }
        internal virtual DbSet<Usertype> Usertypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=localhost;port=3306;database=wisething_portal;user=root;password=admin1234", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.22-mysql"));
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("device");

                entity.HasIndex(e => e.DeviceTagName, "DeviceTagName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DeviceTagName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DeviceUniqueIdentifier)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.InputBy)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.InputDate).HasColumnType("datetime");
                entity.Property(e => e.UpdateBy)
                   .IsRequired()
                   .HasColumnType("varchar(50)")
                   .HasCharSet("utf8mb4")
                   .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserName, "UserName_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserType, "UserToUserType_idx");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
                entity.Property(e => e.InputDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserToUserType");
            });

            modelBuilder.Entity<Userdevice>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DeviceId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("userdevice");

                entity.HasIndex(e => e.DeviceId, "DeviceToUserDevice_idx");
                entity.Property(e => e.InputDate).HasColumnType("datetime");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.Userdevices)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DeviceToUserDevice");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userdevices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserToUserDevice");
            });

            modelBuilder.Entity<Usertype>(entity =>
            {
                entity.ToTable("usertype");

                entity.HasIndex(e => e.UserTypeName, "UserTypeName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
