﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230720094410_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ActorUser", b =>
                {
                    b.Property<long>("FavActorsID")
                        .HasColumnType("bigint");

                    b.Property<long>("FavoritesID")
                        .HasColumnType("bigint");

                    b.HasKey("FavActorsID", "FavoritesID");

                    b.HasIndex("FavoritesID");

                    b.ToTable("ActorUser");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<long>("GenresID")
                        .HasColumnType("bigint");

                    b.Property<long>("MoviesID")
                        .HasColumnType("bigint");

                    b.HasKey("GenresID", "MoviesID");

                    b.HasIndex("MoviesID");

                    b.ToTable("GenreMovie");
                });

            modelBuilder.Entity("MovieMovieAward", b =>
                {
                    b.Property<long>("MovieAwardsID")
                        .HasColumnType("bigint");

                    b.Property<long>("MoviesID")
                        .HasColumnType("bigint");

                    b.HasKey("MovieAwardsID", "MoviesID");

                    b.HasIndex("MoviesID");

                    b.ToTable("MovieMovieAward");
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.Property<long>("FavMoviesID")
                        .HasColumnType("bigint");

                    b.Property<long>("FavoritesID")
                        .HasColumnType("bigint");

                    b.HasKey("FavMoviesID", "FavoritesID");

                    b.HasIndex("FavoritesID");

                    b.ToTable("MovieUser");
                });

            modelBuilder.Entity("MovieWatchList", b =>
                {
                    b.Property<long>("MoviesID")
                        .HasColumnType("bigint");

                    b.Property<long>("WatchListsID")
                        .HasColumnType("bigint");

                    b.HasKey("MoviesID", "WatchListsID");

                    b.HasIndex("WatchListsID");

                    b.ToTable("MovieWatchList");
                });

            modelBuilder.Entity("ProducerAwardProducingMovie", b =>
                {
                    b.Property<long>("ProducerAwardsID")
                        .HasColumnType("bigint");

                    b.Property<long>("ProducingsMovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProducingsProducerId")
                        .HasColumnType("bigint");

                    b.HasKey("ProducerAwardsID", "ProducingsMovieId", "ProducingsProducerId");

                    b.HasIndex("ProducingsMovieId", "ProducingsProducerId");

                    b.ToTable("ProducerAwardProducingMovie");
                });

            modelBuilder.Entity("ProducerUser", b =>
                {
                    b.Property<long>("FavProducersID")
                        .HasColumnType("bigint");

                    b.Property<long>("FavoritesID")
                        .HasColumnType("bigint");

                    b.HasKey("FavProducersID", "FavoritesID");

                    b.HasIndex("FavoritesID");

                    b.ToTable("ProducerUser");
                });

            modelBuilder.Entity("RoleRoleAward", b =>
                {
                    b.Property<long>("RoleAwardsID")
                        .HasColumnType("bigint");

                    b.Property<long>("RolesID")
                        .HasColumnType("bigint");

                    b.HasKey("RoleAwardsID", "RolesID");

                    b.HasIndex("RolesID");

                    b.ToTable("RoleRoleAward");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Actor", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("APhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Award", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("AwardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("HoldingId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("HoldingId");

                    b.ToTable("Awards");

                    b.HasDiscriminator<string>("AwardType").HasValue("Award");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Festival", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Festivals");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Genre", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Holding", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FestivalId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FestivalId");

                    b.ToTable("Holdings");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Movie", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<DateTime>("DateOfRelease")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RevCount")
                        .HasColumnType("int");

                    b.Property<float>("RevGrade")
                        .HasColumnType("real");

                    b.Property<long?>("SeriesId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudioId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("SeriesId");

                    b.HasIndex("StudioId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Notification", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<long>("AwardId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateOfNotification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AwardId")
                        .IsUnique();

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Notify", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("NotificationId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Seen")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "NotificationId");

                    b.HasIndex("NotificationId");

                    b.ToTable("Notifies");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Producer", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.ProducingMovie", b =>
                {
                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProducerId")
                        .HasColumnType("bigint");

                    b.HasKey("MovieId", "ProducerId");

                    b.HasIndex("ProducerId");

                    b.ToTable("Producings");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Review", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RevTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("MovieId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Role", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<long>("ActorId")
                        .HasColumnType("bigint");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("MovieId")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("ActorId");

                    b.HasIndex("MovieId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Series", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Studio", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.User", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.WatchList", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("WatchLists");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.MovieAward", b =>
                {
                    b.HasBaseType("WebApplication1.Data.Models.Award");

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.ProducerAward", b =>
                {
                    b.HasBaseType("WebApplication1.Data.Models.Award");

                    b.HasDiscriminator().HasValue("Producer");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.RoleAward", b =>
                {
                    b.HasBaseType("WebApplication1.Data.Models.Award");

                    b.HasDiscriminator().HasValue("Role");
                });

            modelBuilder.Entity("ActorUser", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Actor", null)
                        .WithMany()
                        .HasForeignKey("FavActorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FavoritesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieMovieAward", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.MovieAward", null)
                        .WithMany()
                        .HasForeignKey("MovieAwardsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieUser", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("FavMoviesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FavoritesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieWatchList", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.WatchList", null)
                        .WithMany()
                        .HasForeignKey("WatchListsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProducerAwardProducingMovie", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.ProducerAward", null)
                        .WithMany()
                        .HasForeignKey("ProducerAwardsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.ProducingMovie", null)
                        .WithMany()
                        .HasForeignKey("ProducingsMovieId", "ProducingsProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProducerUser", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Producer", null)
                        .WithMany()
                        .HasForeignKey("FavProducersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("FavoritesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleRoleAward", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.RoleAward", null)
                        .WithMany()
                        .HasForeignKey("RoleAwardsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Award", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Holding", "Holding")
                        .WithMany("Awards")
                        .HasForeignKey("HoldingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Holding");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Holding", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Festival", "Festival")
                        .WithMany("Holdings")
                        .HasForeignKey("FestivalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Festival");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Movie", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Series", "Series")
                        .WithMany("Movies")
                        .HasForeignKey("SeriesId");

                    b.HasOne("WebApplication1.Data.Models.Studio", "Studio")
                        .WithMany("Movies")
                        .HasForeignKey("StudioId");

                    b.Navigation("Series");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Notification", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Award", "Award")
                        .WithOne("Notification")
                        .HasForeignKey("WebApplication1.Data.Models.Notification", "AwardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Award");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Notify", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Notification", "Notification")
                        .WithMany("Notifies")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.User", "User")
                        .WithMany("Notifies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.ProducingMovie", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Movie", "Movie")
                        .WithMany("Producings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.Producer", "Producer")
                        .WithMany("Producings")
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Producer");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Review", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Movie", "Movie")
                        .WithMany("Reviews")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.User", "Reviewer")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Role", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.Actor", "Actor")
                        .WithMany("Roles")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Data.Models.Movie", "Movie")
                        .WithMany("Roles")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.WatchList", b =>
                {
                    b.HasOne("WebApplication1.Data.Models.User", "User")
                        .WithOne("WatchList")
                        .HasForeignKey("WebApplication1.Data.Models.WatchList", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Actor", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Award", b =>
                {
                    b.Navigation("Notification")
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Festival", b =>
                {
                    b.Navigation("Holdings");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Holding", b =>
                {
                    b.Navigation("Awards");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Movie", b =>
                {
                    b.Navigation("Producings");

                    b.Navigation("Reviews");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Notification", b =>
                {
                    b.Navigation("Notifies");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Producer", b =>
                {
                    b.Navigation("Producings");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Series", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.Studio", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("WebApplication1.Data.Models.User", b =>
                {
                    b.Navigation("Notifies");

                    b.Navigation("Reviews");

                    b.Navigation("WatchList")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
