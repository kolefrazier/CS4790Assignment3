using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CS4790Assignment3.Data;
using CS4790Assignment3.Models;

namespace CS4790Assignment3.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20170615043624_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CS4790Assignment3.Models.Game", b =>
                {
                    b.Property<int>("GameID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CurrentlyPlaying");

                    b.Property<string>("GameName")
                        .IsRequired();

                    b.Property<int>("Genre");

                    b.Property<double>("HoursPlayed");

                    b.Property<bool>("IsCompleted");

                    b.Property<bool>("IsOnlineMultiplayer");

                    b.Property<double>("Price");

                    b.Property<int?>("PublisherID");

                    b.HasKey("GameID");

                    b.HasIndex("PublisherID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("CS4790Assignment3.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameID");

                    b.Property<bool>("IsIndie");

                    b.Property<bool>("IsTripleA");

                    b.Property<string>("PublisherName");

                    b.HasKey("PublisherID");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("CS4790Assignment3.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorID");

                    b.Property<bool>("DoesRecommend");

                    b.Property<int?>("GameID");

                    b.Property<DateTime>("LastUpdateDate");

                    b.Property<string>("ReviewContent");

                    b.Property<DateTime>("SubmissionDate");

                    b.HasKey("ReviewID");

                    b.HasIndex("GameID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("CS4790Assignment3.Models.Screenshot", b =>
                {
                    b.Property<int>("ScreenshotID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CaptureTimestamp");

                    b.Property<int>("Category");

                    b.Property<int?>("GameID");

                    b.Property<string>("LocalPath");

                    b.Property<string>("SourceGame");

                    b.HasKey("ScreenshotID");

                    b.HasIndex("GameID");

                    b.ToTable("Screenshot");
                });

            modelBuilder.Entity("CS4790Assignment3.Models.Game", b =>
                {
                    b.HasOne("CS4790Assignment3.Models.Publisher", "Publisher")
                        .WithMany("PublishedGames")
                        .HasForeignKey("PublisherID");
                });

            modelBuilder.Entity("CS4790Assignment3.Models.Review", b =>
                {
                    b.HasOne("CS4790Assignment3.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameID");
                });

            modelBuilder.Entity("CS4790Assignment3.Models.Screenshot", b =>
                {
                    b.HasOne("CS4790Assignment3.Models.Game", "Game")
                        .WithMany("Screenshots")
                        .HasForeignKey("GameID");
                });
        }
    }
}
