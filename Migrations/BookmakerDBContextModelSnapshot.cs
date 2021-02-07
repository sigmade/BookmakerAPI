﻿// <auto-generated />
using System;
using BookmakerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BookmakerAPI.Migrations
{
    [DbContext(typeof(BookmakerDBContext))]
    partial class BookmakerDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BookmakerAPI.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FirstTeamId")
                        .HasColumnType("integer");

                    b.Property<int>("FirstTeamScore")
                        .HasColumnType("integer");

                    b.Property<DateTime>("MatchDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("SecondTeamId")
                        .HasColumnType("integer");

                    b.Property<int>("SecondTeamScore")
                        .HasColumnType("integer");

                    b.HasKey("MatchId");

                    b.HasIndex("SecondTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("BookmakerAPI.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<int>("TeamId")
                        .HasColumnType("integer");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BookmakerAPI.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("TeamName")
                        .HasColumnType("text");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("BookmakerAPI.Models.Match", b =>
                {
                    b.HasOne("BookmakerAPI.Models.Team", "Team")
                        .WithMany("Matches")
                        .HasForeignKey("SecondTeamId")
                        .HasConstraintName("FK_SecondTeam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookmakerAPI.Models.Player", b =>
                {
                    b.HasOne("BookmakerAPI.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
