﻿// <auto-generated />
using System;
using Fivesemtest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Fivesemtest.Migrations
{
    [DbContext(typeof(FivesemestercswrkContext))]
    [Migration("20250102162807_IdentityDetailsFix")]
    partial class IdentityDetailsFix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Fivesemtest.Models.DailySchedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("schedule_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScheduleId"));

                    b.Property<DateOnly>("ScheduleData")
                        .HasColumnType("date")
                        .HasColumnName("schedule_data");

                    b.Property<int?>("UserSchedule")
                        .HasColumnType("integer")
                        .HasColumnName("user_schedule");

                    b.HasKey("ScheduleId")
                        .HasName("daily_schedule_pkey");

                    b.HasIndex("UserSchedule");

                    b.ToTable("daily_schedule", (string)null);
                });

            modelBuilder.Entity("Fivesemtest.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("event_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EventId"));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<DateOnly?>("EventDate")
                        .HasColumnType("date")
                        .HasColumnName("event_date");

                    b.Property<int?>("EventSchedule")
                        .HasColumnType("integer")
                        .HasColumnName("event_schedule");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Priority")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("priority")
                        .HasDefaultValueSql("'low'::character varying");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.HasKey("EventId")
                        .HasName("event_pkey");

                    b.HasIndex("EventSchedule");

                    b.ToTable("event", (string)null);
                });

            modelBuilder.Entity("Fivesemtest.Models.Goal", b =>
                {
                    b.Property<int>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("goal_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GoalId"));

                    b.Property<DateOnly>("CreateDate")
                        .HasColumnType("date")
                        .HasColumnName("create_date");

                    b.Property<DateOnly>("Deadline")
                        .HasColumnType("date")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<int?>("GoalSphere")
                        .HasColumnType("integer")
                        .HasColumnName("goal_sphere");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.HasKey("GoalId")
                        .HasName("goal_pkey");

                    b.HasIndex("GoalSphere");

                    b.ToTable("goal", (string)null);
                });

            modelBuilder.Entity("Fivesemtest.Models.Habit", b =>
                {
                    b.Property<int>("HabitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("habit_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HabitId"));

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<TimeSpan>("Frequency")
                        .HasColumnType("interval")
                        .HasColumnName("frequency");

                    b.Property<int?>("GoalHabit")
                        .HasColumnType("integer")
                        .HasColumnName("goal_habit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("Reminder")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("reminder");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.HasKey("HabitId")
                        .HasName("habit_pkey");

                    b.HasIndex("GoalHabit");

                    b.ToTable("habit", (string)null);
                });

            modelBuilder.Entity("Fivesemtest.Models.HabitOfTheDay", b =>
                {
                    b.Property<int>("HabitDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("habit_day_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("HabitDayId"));

                    b.Property<int?>("HabitDay")
                        .HasColumnType("integer")
                        .HasColumnName("habit_day");

                    b.Property<int?>("ScheduleDay")
                        .HasColumnType("integer")
                        .HasColumnName("schedule_day");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.HasKey("HabitDayId")
                        .HasName("habit_of_the_day_pkey");

                    b.HasIndex("HabitDay");

                    b.HasIndex("ScheduleDay");

                    b.ToTable("habit_of_the_day", (string)null);
                });

            modelBuilder.Entity("Fivesemtest.Models.SpheresOfLife", b =>
                {
                    b.Property<int>("SphereId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("sphere_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SphereId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("name");

                    b.HasKey("SphereId")
                        .HasName("spheres_of_life_pkey");

                    b.ToTable("spheres_of_life", (string)null);
                });

            modelBuilder.Entity("Fivesemtest.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("email");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("users_pkey");

                    b.HasIndex(new[] { "Email" }, "users_email_key")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "users_username_key")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Fivesemtest.Models.UserSphereSatisfaction", b =>
                {
                    b.Property<int>("SatisfactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("satisfaction_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SatisfactionId"));

                    b.Property<short?>("SatisfactionLevel")
                        .HasColumnType("smallint")
                        .HasColumnName("satisfaction_level");

                    b.Property<int?>("SphereIds")
                        .HasColumnType("integer")
                        .HasColumnName("sphere_ids");

                    b.Property<int?>("UserSpheres")
                        .HasColumnType("integer")
                        .HasColumnName("user_spheres");

                    b.HasKey("SatisfactionId")
                        .HasName("user_sphere_satisfaction_pkey");

                    b.HasIndex("SphereIds");

                    b.HasIndex("UserSpheres");

                    b.ToTable("user_sphere_satisfaction", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Fivesemtest.Models.DailySchedule", b =>
                {
                    b.HasOne("Fivesemtest.Models.User", "UserScheduleNavigation")
                        .WithMany("DailySchedules")
                        .HasForeignKey("UserSchedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("daily_schedule_user_schedule_fkey");

                    b.Navigation("UserScheduleNavigation");
                });

            modelBuilder.Entity("Fivesemtest.Models.Event", b =>
                {
                    b.HasOne("Fivesemtest.Models.DailySchedule", "EventScheduleNavigation")
                        .WithMany("Events")
                        .HasForeignKey("EventSchedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("event_event_schedule_fkey");

                    b.Navigation("EventScheduleNavigation");
                });

            modelBuilder.Entity("Fivesemtest.Models.Goal", b =>
                {
                    b.HasOne("Fivesemtest.Models.SpheresOfLife", "GoalSphereNavigation")
                        .WithMany("Goals")
                        .HasForeignKey("GoalSphere")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("goal_goal_sphere_fkey");

                    b.Navigation("GoalSphereNavigation");
                });

            modelBuilder.Entity("Fivesemtest.Models.Habit", b =>
                {
                    b.HasOne("Fivesemtest.Models.Goal", "GoalHabitNavigation")
                        .WithMany("Habits")
                        .HasForeignKey("GoalHabit")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("habit_goal_habit_fkey");

                    b.Navigation("GoalHabitNavigation");
                });

            modelBuilder.Entity("Fivesemtest.Models.HabitOfTheDay", b =>
                {
                    b.HasOne("Fivesemtest.Models.Habit", "HabitDayNavigation")
                        .WithMany("HabitOfTheDays")
                        .HasForeignKey("HabitDay")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("habit_of_the_day_habit_day_fkey");

                    b.HasOne("Fivesemtest.Models.DailySchedule", "ScheduleDayNavigation")
                        .WithMany("HabitOfTheDays")
                        .HasForeignKey("ScheduleDay")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("habit_of_the_day_schedule_day_fkey");

                    b.Navigation("HabitDayNavigation");

                    b.Navigation("ScheduleDayNavigation");
                });

            modelBuilder.Entity("Fivesemtest.Models.UserSphereSatisfaction", b =>
                {
                    b.HasOne("Fivesemtest.Models.SpheresOfLife", "SphereIdsNavigation")
                        .WithMany("UserSphereSatisfactions")
                        .HasForeignKey("SphereIds")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("user_sphere_satisfaction_sphere_ids_fkey");

                    b.HasOne("Fivesemtest.Models.User", "UserSpheresNavigation")
                        .WithMany("UserSphereSatisfactions")
                        .HasForeignKey("UserSpheres")
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("user_sphere_satisfaction_user_spheres_fkey");

                    b.Navigation("SphereIdsNavigation");

                    b.Navigation("UserSpheresNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fivesemtest.Models.DailySchedule", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("HabitOfTheDays");
                });

            modelBuilder.Entity("Fivesemtest.Models.Goal", b =>
                {
                    b.Navigation("Habits");
                });

            modelBuilder.Entity("Fivesemtest.Models.Habit", b =>
                {
                    b.Navigation("HabitOfTheDays");
                });

            modelBuilder.Entity("Fivesemtest.Models.SpheresOfLife", b =>
                {
                    b.Navigation("Goals");

                    b.Navigation("UserSphereSatisfactions");
                });

            modelBuilder.Entity("Fivesemtest.Models.User", b =>
                {
                    b.Navigation("DailySchedules");

                    b.Navigation("UserSphereSatisfactions");
                });
#pragma warning restore 612, 618
        }
    }
}
