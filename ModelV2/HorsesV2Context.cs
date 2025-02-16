using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace horsesProj.ModelV2;

public partial class HorsesV2Context : DbContext
{
    public HorsesV2Context()
    {
    }

    public HorsesV2Context(DbContextOptions<HorsesV2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCompetition> TbCompetitions { get; set; }

    public virtual DbSet<TbCompetitor> TbCompetitors { get; set; }

    public virtual DbSet<TbCompetitorOffence> TbCompetitorOffences { get; set; }

    public virtual DbSet<TbHorse> TbHorses { get; set; }

    public virtual DbSet<TbHorseBreed> TbHorseBreeds { get; set; }

    public virtual DbSet<TbHorseBreedType> TbHorseBreedTypes { get; set; }

    public virtual DbSet<TbHorseGender> TbHorseGenders { get; set; }

    public virtual DbSet<TbJockey> TbJockeys { get; set; }

    public virtual DbSet<TbJudge> TbJudges { get; set; }

    public virtual DbSet<TbOffence> TbOffences { get; set; }

    public virtual DbSet<TbRestricment> TbRestricments { get; set; }

    public virtual DbSet<TbRestricmentBreed> TbRestricmentBreeds { get; set; }

    public virtual DbSet<TbRide> TbRides { get; set; }

    public virtual DbSet<TbRideCompetitor> TbRideCompetitors { get; set; }

    public virtual DbSet<TbRideType> TbRideTypes { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=horsesV2;Username=postgres;Password=123");

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
            entity.Property(e => e.CompetJudgeId).HasColumnName("compet_judge_id");
            entity.Property(e => e.CompetName)
                .HasMaxLength(50)
                .HasColumnName("compet_name");

            entity.HasOne(d => d.CompetJudge).WithMany(p => p.TbCompetitions)
                .HasForeignKey(d => d.CompetJudgeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_competition_compet_judge_id_fkey");
        });

        modelBuilder.Entity<TbCompetitor>(entity =>
        {
            entity.HasKey(e => e.CompetitorId).HasName("tb_competitor_pkey");

            entity.ToTable("tb_competitor");

            entity.Property(e => e.CompetitorId).HasColumnName("competitor_id");
            entity.Property(e => e.CompetitorDisqualification).HasColumnName("competitor_disqualification");
            entity.Property(e => e.CompetitorHorseId).HasColumnName("competitor_horse_id");
            entity.Property(e => e.CompetitorJockeyId).HasColumnName("competitor_jockey_id");
            entity.Property(e => e.CompetitorRow).HasColumnName("competitor_row");

            entity.HasOne(d => d.CompetitorHorse).WithMany(p => p.TbCompetitors)
                .HasForeignKey(d => d.CompetitorHorseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_competitor_competitor_horse_id_fkey");

            entity.HasOne(d => d.CompetitorJockey).WithMany(p => p.TbCompetitors)
                .HasForeignKey(d => d.CompetitorJockeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_competitor_competitor_jockey_id_fkey");
        });

        modelBuilder.Entity<TbCompetitorOffence>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_competitor_offences");

            entity.Property(e => e.CompetitorId).HasColumnName("competitor_id");
            entity.Property(e => e.OffenceId).HasColumnName("offence_id");

            entity.HasOne(d => d.Competitor).WithMany()
                .HasForeignKey(d => d.CompetitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_competitor_offences_competitor_id_fkey");

            entity.HasOne(d => d.Offence).WithMany()
                .HasForeignKey(d => d.OffenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_competitor_offences_offence_id_fkey");
        });

        modelBuilder.Entity<TbHorse>(entity =>
        {
            entity.HasKey(e => e.HorseId).HasName("tb_horse_pkey");

            entity.ToTable("tb_horse");

            entity.Property(e => e.HorseId).HasColumnName("horse_id");
            entity.Property(e => e.HorseBirthYear).HasColumnName("horse_birth_year");
            entity.Property(e => e.HorseBreedId).HasColumnName("horse_breed_id");
            entity.Property(e => e.HorseGenderId).HasColumnName("horse_gender_id");
            entity.Property(e => e.HorseName)
                .HasMaxLength(50)
                .HasColumnName("horse_name");
            entity.Property(e => e.HorseOwnerId).HasColumnName("horse_owner_id");
            entity.Property(e => e.HorseTrainerFio)
                .HasMaxLength(150)
                .HasColumnName("horse_trainer_fio");

            entity.HasOne(d => d.HorseBreed).WithMany(p => p.TbHorses)
                .HasForeignKey(d => d.HorseBreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_horse_horse_breed_id_fkey");

            entity.HasOne(d => d.HorseGender).WithMany(p => p.TbHorses)
                .HasForeignKey(d => d.HorseGenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_horse_horse_gender_id_fkey");

            entity.HasOne(d => d.HorseOwner).WithMany(p => p.TbHorses)
                .HasForeignKey(d => d.HorseOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_horse_horse_owner_id_fkey");
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

        modelBuilder.Entity<TbJockey>(entity =>
        {
            entity.HasKey(e => e.JokeyId).HasName("tb_jockey_pkey");

            entity.ToTable("tb_jockey");

            entity.Property(e => e.JokeyId).HasColumnName("jokey_id");
            entity.Property(e => e.JokeyBirth)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("jokey_birth");
            entity.Property(e => e.JokeyFio)
                .HasMaxLength(70)
                .HasColumnName("jokey_fio");
            entity.Property(e => e.JokeyUserLogin)
                .HasMaxLength(50)
                .HasColumnName("jokey_user_login");
            entity.Property(e => e.JokeyWeight).HasColumnName("jokey_weight");

            entity.HasOne(d => d.JokeyUserLoginNavigation).WithMany(p => p.TbJockeys)
                .HasForeignKey(d => d.JokeyUserLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_jockey_jokey_user_login_fkey");
        });

        modelBuilder.Entity<TbJudge>(entity =>
        {
            entity.HasKey(e => e.JudgeId).HasName("tb_judge_pkey");

            entity.ToTable("tb_judge");

            entity.Property(e => e.JudgeId).HasColumnName("judge_id");
            entity.Property(e => e.JudgeFio)
                .HasMaxLength(70)
                .HasColumnName("judge_fio");
            entity.Property(e => e.JudgeTown)
                .HasMaxLength(150)
                .HasColumnName("judge_town");
            entity.Property(e => e.JudgeUserLogin)
                .HasMaxLength(50)
                .HasColumnName("judge_user_login");

            entity.HasOne(d => d.JudgeUserLoginNavigation).WithMany(p => p.TbJudges)
                .HasForeignKey(d => d.JudgeUserLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_judge_judge_user_login_fkey");
        });

        modelBuilder.Entity<TbOffence>(entity =>
        {
            entity.HasKey(e => e.OffenceId).HasName("tb_offence_pkey");

            entity.ToTable("tb_offence");

            entity.Property(e => e.OffenceId).HasColumnName("offence_id");
            entity.Property(e => e.OffenceDescription).HasColumnName("offence_description");
            entity.Property(e => e.OffenceName)
                .HasMaxLength(100)
                .HasColumnName("offence_name");
        });

        modelBuilder.Entity<TbRestricment>(entity =>
        {
            entity.HasKey(e => e.RestricmentId).HasName("tb_restricment_pkey");

            entity.ToTable("tb_restricment");

            entity.Property(e => e.RestricmentId).HasColumnName("restricment_id");
            entity.Property(e => e.RestricmentAgeLower).HasColumnName("restricment_age_lower");
            entity.Property(e => e.RestricmentAgeUpper).HasColumnName("restricment_age_upper");
            entity.Property(e => e.RestricmentGender)
                .HasMaxLength(50)
                .HasColumnName("restricment_gender");
            entity.Property(e => e.RestricmentHorseBirthplace)
                .HasMaxLength(50)
                .HasColumnName("restricment_horse_birthplace");
        });

        modelBuilder.Entity<TbRestricmentBreed>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_restricment_breeds");

            entity.Property(e => e.BreedId).HasColumnName("breed_id");
            entity.Property(e => e.RestricmentId).HasColumnName("restricment_id");

            entity.HasOne(d => d.Breed).WithMany()
                .HasForeignKey(d => d.BreedId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_restricment_breeds_breed_id_fkey");

            entity.HasOne(d => d.Restricment).WithMany()
                .HasForeignKey(d => d.RestricmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_restricment_breeds_restricment_id_fkey");
        });

        modelBuilder.Entity<TbRide>(entity =>
        {
            entity.HasKey(e => e.RideId).HasName("tb_ride_pkey");

            entity.ToTable("tb_ride");

            entity.Property(e => e.RideId).HasColumnName("ride_id");
            entity.Property(e => e.RideCompetition).HasColumnName("ride_competition");
            entity.Property(e => e.RideDistance).HasColumnName("ride_distance");
            entity.Property(e => e.RideName)
                .HasMaxLength(50)
                .HasColumnName("ride_name");
            entity.Property(e => e.RideNum).HasColumnName("ride_num");
            entity.Property(e => e.RidePayment).HasColumnName("ride_payment");
            entity.Property(e => e.RideRestricment).HasColumnName("ride_restricment");
            entity.Property(e => e.RideTime).HasColumnName("ride_time");
            entity.Property(e => e.RideTypeId).HasColumnName("ride_type_id");

            entity.HasOne(d => d.RideCompetitionNavigation).WithMany(p => p.TbRides)
                .HasForeignKey(d => d.RideCompetition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ride_ride_competition_fkey");

            entity.HasOne(d => d.RideRestricmentNavigation).WithMany(p => p.TbRides)
                .HasForeignKey(d => d.RideRestricment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ride_ride_restricment_fkey");

            entity.HasOne(d => d.RideType).WithMany(p => p.TbRides)
                .HasForeignKey(d => d.RideTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ride_ride_type_id_fkey");
        });

        modelBuilder.Entity<TbRideCompetitor>(entity =>
        {
            entity.HasKey(e => new { e.CompetitorId, e.RideId }).HasName("tb_ride_competitors_pkey");

            entity.ToTable("tb_ride_competitors");

            entity.Property(e => e.CompetitorId).HasColumnName("competitor_id");
            entity.Property(e => e.RideId).HasColumnName("ride_id");
            entity.Property(e => e.HorseRunFail).HasColumnName("horse_run_fail");
            entity.Property(e => e.JockeyColor)
                .HasMaxLength(150)
                .HasColumnName("jockey_color");
            entity.Property(e => e.RideResult)
                .HasPrecision(5, 1)
                .HasColumnName("ride_result");

            entity.HasOne(d => d.Competitor).WithMany(p => p.TbRideCompetitors)
                .HasForeignKey(d => d.CompetitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_ride_competitors_competitor_id_fkey");

            entity.HasOne(d => d.Ride).WithMany(p => p.TbRideCompetitors)
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
