using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace horsesProj.Model;

public partial class HorsesContext : DbContext
{
    public HorsesContext()
    {
    }

    public HorsesContext(DbContextOptions<HorsesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCompetition> TbCompetitions { get; set; }

    public virtual DbSet<TbCompetitionRide> TbCompetitionRides { get; set; }

    public virtual DbSet<TbHorse> TbHorses { get; set; }

    public virtual DbSet<TbHorseBreed> TbHorseBreeds { get; set; }

    public virtual DbSet<TbHorseBreedType> TbHorseBreedTypes { get; set; }

    public virtual DbSet<TbHorseGender> TbHorseGenders { get; set; }

    public virtual DbSet<TbJokey> TbJokeys { get; set; }

    public virtual DbSet<TbJudge> TbJudges { get; set; }

    public virtual DbSet<TbRestricmentBreed> TbRestricmentBreeds { get; set; }

    public virtual DbSet<TbRestricmentType> TbRestricmentTypes { get; set; }

    public virtual DbSet<TbRide> TbRides { get; set; }

    public virtual DbSet<TbRideCompetitor> TbRideCompetitors { get; set; }

    public virtual DbSet<TbRideType> TbRideTypes { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=horses;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCompetition>(entity =>
        {
            entity.HasKey(e => e.CompetId).HasName("tb_competition_pkey");

            entity.ToTable("tb_competition");

            entity.Property(e => e.CompetId).HasColumnName("compet_id");
            entity.Property(e => e.CompetDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("compet_date");
            entity.Property(e => e.CompetName)
                .HasMaxLength(50)
                .HasColumnName("compet_name");
        });

        modelBuilder.Entity<TbCompetitionRide>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_competition_rides");

            entity.Property(e => e.CompetId).HasColumnName("compet_id");
            entity.Property(e => e.RideId).HasColumnName("ride_id");

            entity.HasOne(d => d.Compet).WithMany()
                .HasForeignKey(d => d.CompetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_competition_rides_compet_id_fkey");

            entity.HasOne(d => d.Ride).WithMany()
                .HasForeignKey(d => d.RideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_competition_rides_ride_id_fkey");
        });

        modelBuilder.Entity<TbHorse>(entity =>
        {
            entity.HasKey(e => e.HorseId).HasName("tb_horse_pkey");

            entity.ToTable("tb_horse");

            entity.Property(e => e.HorseId).HasColumnName("horse_id");
            entity.Property(e => e.HorseBreedId).HasColumnName("horse_breed_id");
            entity.Property(e => e.HorseGenderId).HasColumnName("horse_gender_id");
            entity.Property(e => e.HorseName)
                .HasMaxLength(50)
                .HasColumnName("horse_name");
            entity.Property(e => e.HorseOwnerFio)
                .HasMaxLength(150)
                .HasColumnName("horse_owner_fio");
            entity.Property(e => e.HorseRunFail).HasColumnName("horse_run_fail");
            entity.Property(e => e.HorseSpeed)
                .HasPrecision(5, 1)
                .HasColumnName("horse_speed");
            entity.Property(e => e.HorseTrainerFio)
                .HasMaxLength(150)
                .HasColumnName("horse_trainer_fio");
            entity.Property(e => e.HorseYear).HasColumnName("horse_year");

            entity.HasOne(d => d.HorseBreed).WithMany(p => p.TbHorses)
                .HasForeignKey(d => d.HorseBreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_horse_horse_breed_id_fkey");

            entity.HasOne(d => d.HorseGender).WithMany(p => p.TbHorses)
                .HasForeignKey(d => d.HorseGenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_horse_horse_gender_id_fkey");
        });

        modelBuilder.Entity<TbHorseBreed>(entity =>
        {
            entity.HasKey(e => e.BreedId).HasName("tb_horse_breed_pkey");

            entity.ToTable("tb_horse_breed");

            entity.Property(e => e.BreedId).HasColumnName("breed_id");
            entity.Property(e => e.BreedName)
                .HasMaxLength(50)
                .HasColumnName("breed_name");
            entity.Property(e => e.BreedTypeId).HasColumnName("breed_type_id");

            entity.HasOne(d => d.BreedType).WithMany(p => p.TbHorseBreeds)
                .HasForeignKey(d => d.BreedTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_horse_breed_breed_type_id_fkey");
        });

        modelBuilder.Entity<TbHorseBreedType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("tb_horse_breed_type_pkey");

            entity.ToTable("tb_horse_breed_type");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<TbHorseGender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("tb_horse_gender_pkey");

            entity.ToTable("tb_horse_gender");

            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.GenderName)
                .HasMaxLength(50)
                .HasColumnName("gender_name");
        });

        modelBuilder.Entity<TbJokey>(entity =>
        {
            entity.HasKey(e => e.JokeyId).HasName("tb_jokey_pkey");

            entity.ToTable("tb_jokey");

            entity.Property(e => e.JokeyId).HasColumnName("jokey_id");
            entity.Property(e => e.JokeyBirth)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("jokey_birth");
            entity.Property(e => e.JokeyFio)
                .HasMaxLength(50)
                .HasColumnName("jokey_fio");
            entity.Property(e => e.JokeyUserLogin)
                .HasMaxLength(50)
                .HasColumnName("jokey_user_login");
            entity.Property(e => e.JokeyWeight).HasColumnName("jokey_weight");

            entity.HasOne(d => d.JokeyUserLoginNavigation).WithMany(p => p.TbJokeys)
                .HasForeignKey(d => d.JokeyUserLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_jokey_jokey_user_login_fkey");
        });

        modelBuilder.Entity<TbJudge>(entity =>
        {
            entity.HasKey(e => e.JudgeId).HasName("tb_judge_pkey");

            entity.ToTable("tb_judge");

            entity.Property(e => e.JudgeId).HasColumnName("judge_id");
            entity.Property(e => e.JudgeUserLogin)
                .HasMaxLength(50)
                .HasColumnName("judge_user_login");
            entity.Property(e => e.UserFio)
                .HasMaxLength(50)
                .HasColumnName("user_fio");
            entity.Property(e => e.UserTown)
                .HasMaxLength(50)
                .HasColumnName("user_town");

            entity.HasOne(d => d.JudgeUserLoginNavigation).WithMany(p => p.TbJudges)
                .HasForeignKey(d => d.JudgeUserLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_judge_judge_user_login_fkey");
        });

        modelBuilder.Entity<TbRestricmentBreed>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_restricment_breeds");

            entity.Property(e => e.BreedId).HasColumnName("breed_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Breed).WithMany()
                .HasForeignKey(d => d.BreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_restricment_breeds_breed_id_fkey");

            entity.HasOne(d => d.Type).WithMany()
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_restricment_breeds_type_id_fkey");
        });

        modelBuilder.Entity<TbRestricmentType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("tb_restricment_type_pkey");

            entity.ToTable("tb_restricment_type");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeAgeLower).HasColumnName("type_age_lower");
            entity.Property(e => e.TypeAgeUpper).HasColumnName("type_age_upper");
            entity.Property(e => e.TypeGender)
                .HasMaxLength(50)
                .HasColumnName("type_gender");
            entity.Property(e => e.TypeHorseBirthplace)
                .HasMaxLength(50)
                .HasColumnName("type_horse_birthplace");
        });

        modelBuilder.Entity<TbRide>(entity =>
        {
            entity.HasKey(e => e.RideId).HasName("tb_ride_pkey");

            entity.ToTable("tb_ride");

            entity.Property(e => e.RideId).HasColumnName("ride_id");
            entity.Property(e => e.RideDistance).HasColumnName("ride_distance");
            entity.Property(e => e.RideName)
                .HasMaxLength(50)
                .HasColumnName("ride_name");
            entity.Property(e => e.RideNum).HasColumnName("ride_num");
            entity.Property(e => e.RidePayment).HasColumnName("ride_payment");
            entity.Property(e => e.RideRestricmentType).HasColumnName("ride_restricment_type");
            entity.Property(e => e.RideTime).HasColumnName("ride_time");
            entity.Property(e => e.RideTypeId).HasColumnName("ride_type_id");

            entity.HasOne(d => d.RideRestricmentTypeNavigation).WithMany(p => p.TbRides)
                .HasForeignKey(d => d.RideRestricmentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ride_ride_restricment_type_fkey");

            entity.HasOne(d => d.RideType).WithMany(p => p.TbRides)
                .HasForeignKey(d => d.RideTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ride_ride_type_id_fkey");
        });

        modelBuilder.Entity<TbRideCompetitor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_ride_competitors");

            entity.Property(e => e.HorseId).HasColumnName("horse_id");
            entity.Property(e => e.HorseRow).HasColumnName("horse_row");
            entity.Property(e => e.JokeyColor)
                .HasMaxLength(50)
                .HasColumnName("jokey_color");
            entity.Property(e => e.JokeyId).HasColumnName("jokey_id");
            entity.Property(e => e.RideId).HasColumnName("ride_id");

            entity.HasOne(d => d.Horse).WithMany()
                .HasForeignKey(d => d.HorseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ride_competitors_horse_id_fkey");

            entity.HasOne(d => d.Jokey).WithMany()
                .HasForeignKey(d => d.JokeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ride_competitors_jokey_id_fkey");

            entity.HasOne(d => d.Ride).WithMany()
                .HasForeignKey(d => d.RideId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ride_competitors_ride_id_fkey");
        });

        modelBuilder.Entity<TbRideType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("tb_ride_type_pkey");

            entity.ToTable("tb_ride_type");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("tb_role_pkey");

            entity.ToTable("tb_role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(25)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserLogin).HasName("tb_user_pkey");

            entity.ToTable("tb_user");

            entity.Property(e => e.UserLogin)
                .HasMaxLength(50)
                .HasColumnName("user_login");
            entity.Property(e => e.UserPassword).HasColumnName("user_password");
            entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");

            entity.HasOne(d => d.UserRole).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_user_user_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
