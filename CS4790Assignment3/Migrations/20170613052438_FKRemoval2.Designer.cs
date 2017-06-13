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
    [Migration("20170613052438_FKRemoval2")]
    partial class FKRemoval2
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

                    b.Property<int>("Genre");

                    b.Property<double?>("HoursPlayed");

                    b.Property<bool>("IsCompleted");

                    b.Property<bool>("IsOnlineMultiplayer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75);

                    b.Property<double>("Price");

                    b.HasKey("GameID");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("CS4790Assignment3.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsIndie");

                    b.Property<bool>("IsTripleA");

                    b.Property<string>("Name");

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

                    b.Property<string>("GameName");

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

            modelBuilder.Entity("CS4790Assignment3.Models.Review", b =>
                {
                    b.HasOne("CS4790Assignment3.Models.Game", "Game")
                        .WithMany("Reviews")
                        .HasForeignKey("GameID");
                });

            modelBuilder.Entity("CS4790Assignment3.Models.Screenshot", b =>
                {
                    b.HasOne("CS4790Assignment3.Models.Game")
                        .WithMany("Screenshots")
                        .HasForeignKey("GameID");
                });
        }
    }
}
