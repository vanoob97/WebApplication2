using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication2
{
    public partial class testdbContext : DbContext
    {
        public testdbContext()
        {
        }

        public testdbContext(DbContextOptions<testdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConcsessionsHour> ConcsessionsHours { get; set; }
        public virtual DbSet<ConcsessionsMultDevice> ConcsessionsMultDevices { get; set; }
        public virtual DbSet<LoginUserCountry> LoginUserCountries { get; set; }
        public virtual DbSet<RegdynamicsDevice> RegdynamicsDevices { get; set; }
        public virtual DbSet<RegdynamicsUser> RegdynamicsUsers { get; set; }
        public virtual DbSet<TotalSessionsHour> TotalSessionsHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConcsessionsHour>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("concsessions_hour");

                entity.Property(e => e.HourTs).HasColumnName("hour_ts");

                entity.Property(e => e.MaxConcsessions).HasColumnName("max_concsessions");
            });

            modelBuilder.Entity<ConcsessionsMultDevice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("concsessions_mult_devices");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(30)
                    .HasColumnName("device_name");

                entity.Property(e => e.LoginTs).HasColumnName("login_ts");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<LoginUserCountry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("login_user_countries");

                entity.Property(e => e.Country)
                    .HasMaxLength(20)
                    .HasColumnName("country");

                entity.Property(e => e.LoginTs).HasColumnName("login_ts");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<RegdynamicsDevice>(entity =>
            {
                entity.HasKey(nameof(RegdynamicsDevice.RegYear), nameof(RegdynamicsDevice.RegMonth), nameof(RegdynamicsDevice.DeviceType));

                entity.ToTable("regdynamics_device");

                entity.Property(e => e.DeviceType)
                    .HasMaxLength(20)
                    .HasColumnName("device_type");

                entity.Property(e => e.NumberOfUsers).HasColumnName("number_of_users");

                entity.Property(e => e.RegMonth).HasColumnName("reg_month");

                entity.Property(e => e.RegYear).HasColumnName("reg_year");
            });

            modelBuilder.Entity<RegdynamicsUser>(entity =>
            {
                entity.HasKey(nameof(RegdynamicsUser.RegYear), nameof(RegdynamicsUser.RegMonth));

                entity.ToTable("regdynamics_user");

                entity.Property(e => e.NumberOfUsers).HasColumnName("number_of_users");

                entity.Property(e => e.RegMonth).HasColumnName("reg_month");

                entity.Property(e => e.RegYear).HasColumnName("reg_year");
            });

            modelBuilder.Entity<TotalSessionsHour>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("total_sessions_hour");

                entity.Property(e => e.DateTs)
                    .HasColumnType("date")
                    .HasColumnName("date_ts");

                entity.Property(e => e.HourTs).HasColumnName("hour_ts");

                entity.Property(e => e.TotalSDurationAcc).HasColumnName("total_s_duration_acc");

                entity.Property(e => e.TotalSDurationMinutes).HasColumnName("total_s_duration_minutes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
