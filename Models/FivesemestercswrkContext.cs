using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Fivesemtest.Models;

public partial class FivesemestercswrkContext :  IdentityDbContext
{
    public FivesemestercswrkContext()
    {
    }

    public FivesemestercswrkContext(DbContextOptions<FivesemestercswrkContext> options)
        : base(options)
    {
    }

    // public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    // public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<DailySchedule> DailySchedules { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<Habit> Habits { get; set; }

    public virtual DbSet<HabitOfTheDay> HabitOfTheDays { get; set; }

    public virtual DbSet<SpheresOfLife> SpheresOfLives { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSphereSatisfaction> UserSphereSatisfactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=fivesemestercswrk;Username=terroor;Password=5598;Persist Security Info=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
  // Configure the many-to-many relationship between IdentityUser and IdentityRole using IdentityUserRole
    // modelBuilder.Entity<IdentityUserRole<string>>()
    //     .HasKey(r => new { r.UserId, r.RoleId });

    // modelBuilder.Entity<IdentityUserRole<string>>()
    //     .HasOne<IdentityUser>()
    //     .WithMany()  // This is because IdentityUser does not have a direct navigation property for roles.
    //     .HasForeignKey(r => r.UserId)
    //     .IsRequired();

    // modelBuilder.Entity<IdentityUserRole<string>>()
    //     .HasOne<IdentityRole>()
    //     .WithMany()  // IdentityRole does not have a direct navigation property for users.
    //     .HasForeignKey(r => r.RoleId)
    //     .IsRequired();

        // modelBuilder.Entity<AspNetRole>(entity =>
        // {
        //     entity.HasKey(e => e.Id).HasName("AspNetRoles_pkey");

        //     entity.HasIndex(e => e.NormalizedName, "IX_AspNetRoles_NormalizedName").IsUnique();

        //     entity.Property(e => e.ConcurrencyStamp).HasMaxLength(256);
        //     entity.Property(e => e.Name).HasMaxLength(256);
        //     entity.Property(e => e.NormalizedName).HasMaxLength(256);
        // });

        // modelBuilder.Entity<AspNetUser>(entity =>
        // {
        //     entity.HasKey(e => e.Id).HasName("AspNetUsers_pkey");

        //     entity.HasIndex(e => e.NormalizedEmail, "IX_AspNetUsers_NormalizedEmail").IsUnique();

        //     entity.HasIndex(e => e.NormalizedUserName, "IX_AspNetUsers_NormalizedUserName").IsUnique();

        //     entity.Property(e => e.AccessFailedCount).HasDefaultValue(0);
        //     entity.Property(e => e.ConcurrencyStamp).HasMaxLength(256);
        //     entity.Property(e => e.Email).HasMaxLength(256);
        //     entity.Property(e => e.EmailConfirmed).HasDefaultValue(false);
        //     entity.Property(e => e.LockoutEnabled).HasDefaultValue(true);
        //     entity.Property(e => e.LockoutEnd).HasColumnType("timestamp without time zone");
        //     entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
        //     entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
        //     entity.Property(e => e.PasswordHash).HasMaxLength(256);
        //     entity.Property(e => e.PhoneNumber).HasMaxLength(15);
        //     entity.Property(e => e.PhoneNumberConfirmed).HasDefaultValue(false);
        //     entity.Property(e => e.SecurityStamp).HasMaxLength(256);
        //     entity.Property(e => e.TwoFactorEnabled).HasDefaultValue(false);
        //     entity.Property(e => e.UserName).HasMaxLength(256);

        //     entity.HasMany(d => d.Roles).WithMany(p => p.Users)
        //         .UsingEntity<Dictionary<string, object>>(
        //             "AspNetUserRole",
        //             r => r.HasOne<AspNetRole>().WithMany()
        //                 .HasForeignKey("RoleId")
        //                 .HasConstraintName("AspNetUserRoles_RoleId_fkey"),
        //             l => l.HasOne<AspNetUser>().WithMany()
        //                 .HasForeignKey("UserId")
        //                 .HasConstraintName("AspNetUserRoles_UserId_fkey"),
        //             j =>
        //             {
        //                 j.HasKey("UserId", "RoleId").HasName("AspNetUserRoles_pkey");
        //                 j.ToTable("AspNetUserRoles");
        //             });
        // });
//  modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
//         modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");
//         modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles");
        modelBuilder.Entity<DailySchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("daily_schedule_pkey");

            entity.ToTable("daily_schedule");

            entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");
            entity.Property(e => e.ScheduleData).HasColumnName("schedule_data");
            entity.Property(e => e.UserSchedule).HasColumnName("user_schedule");

            // entity.HasOne(d => d.UserScheduleNavigation).WithMany(p => p.DailySchedules)
            //     .HasForeignKey(d => d.UserSchedule)
            //     .OnDelete(DeleteBehavior.Cascade)
            //     .HasConstraintName("daily_schedule_user_schedule_fkey");
            entity.HasOne(d => d.UserScheduleNavigation)
        .WithMany()
        .HasForeignKey(d => d.UserSchedule)
        .OnDelete(DeleteBehavior.Cascade)
        .HasConstraintName("daily_schedule_user_schedule_fkey");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("event_pkey");

            entity.ToTable("event");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.EventSchedule).HasColumnName("event_schedule");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Priority)
                .HasMaxLength(6)
                .HasDefaultValueSql("'low'::character varying")
                .HasColumnName("priority");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.EventScheduleNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventSchedule)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("event_event_schedule_fkey");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("goal_pkey");

            entity.ToTable("goal");

            entity.Property(e => e.GoalId).HasColumnName("goal_id");
            entity.Property(e => e.CreateDate).HasColumnName("create_date");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.GoalSphere).HasColumnName("goal_sphere");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.GoalSphereNavigation).WithMany(p => p.Goals)
                .HasForeignKey(d => d.GoalSphere)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("goal_goal_sphere_fkey");
        });

        modelBuilder.Entity<Habit>(entity =>
        {
            entity.HasKey(e => e.HabitId).HasName("habit_pkey");

            entity.ToTable("habit");

            entity.Property(e => e.HabitId).HasColumnName("habit_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Frequency).HasColumnName("frequency");
            entity.Property(e => e.GoalHabit).HasColumnName("goal_habit");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Reminder)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reminder");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.GoalHabitNavigation).WithMany(p => p.Habits)
                .HasForeignKey(d => d.GoalHabit)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("habit_goal_habit_fkey");
        });

        modelBuilder.Entity<HabitOfTheDay>(entity =>
        {
            entity.HasKey(e => e.HabitDayId).HasName("habit_of_the_day_pkey");

            entity.ToTable("habit_of_the_day");

            entity.Property(e => e.HabitDayId).HasColumnName("habit_day_id");
            entity.Property(e => e.HabitDay).HasColumnName("habit_day");
            entity.Property(e => e.ScheduleDay).HasColumnName("schedule_day");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.HabitDayNavigation).WithMany(p => p.HabitOfTheDays)
                .HasForeignKey(d => d.HabitDay)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("habit_of_the_day_habit_day_fkey");

            entity.HasOne(d => d.ScheduleDayNavigation).WithMany(p => p.HabitOfTheDays)
                .HasForeignKey(d => d.ScheduleDay)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("habit_of_the_day_schedule_day_fkey");
        });

        modelBuilder.Entity<SpheresOfLife>(entity =>
        {
            entity.HasKey(e => e.SphereId).HasName("spheres_of_life_pkey");

            entity.ToTable("spheres_of_life");

            entity.Property(e => e.SphereId).HasColumnName("sphere_id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });


        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            // entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            // entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            // entity.Property(e => e.Birthday).HasColumnName("birthday");
            // entity.Property(e => e.Email)
            //     .HasMaxLength(50)
            //     .HasColumnName("email");
            // entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<UserSphereSatisfaction>(entity =>
        {
            entity.HasKey(e => e.SatisfactionId).HasName("user_sphere_satisfaction_pkey");

            entity.ToTable("user_sphere_satisfaction");

            entity.Property(e => e.SatisfactionId).HasColumnName("satisfaction_id");
            entity.Property(e => e.SatisfactionLevel).HasColumnName("satisfaction_level");
            entity.Property(e => e.SphereIds).HasColumnName("sphere_ids");
            entity.Property(e => e.UserSpheres).HasColumnName("user_spheres");

            entity.HasOne(d => d.SphereIdsNavigation).WithMany(p => p.UserSphereSatisfactions)
                .HasForeignKey(d => d.SphereIds)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("user_sphere_satisfaction_sphere_ids_fkey");

            // entity.HasOne(d => d.UserSpheresNavigation).WithMany(p => p.UserSphereSatisfactions)
            //     .HasForeignKey(d => d.UserSpheres)
            //     .OnDelete(DeleteBehavior.SetNull)
            //     .HasConstraintName("user_sphere_satisfaction_user_spheres_fkey");
             entity.HasOne(d => d.UserSpheresNavigation)
        .WithMany()
        .HasForeignKey(d => d.UserSpheres)
        .OnDelete(DeleteBehavior.SetNull)
        .HasConstraintName("user_sphere_satisfaction_user_spheres_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
