using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS4790Assignment3.Models;
using Microsoft.EntityFrameworkCore;

namespace CS4790Assignment3.Data
{
    public class GameContext : DbContext
    {
		public GameContext(DbContextOptions<GameContext> options) : base(options)
		{

		}

		public DbSet<Game> Games { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Screenshot> Screenshots { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Game>().ToTable("Game");
			modelBuilder.Entity<Publisher>().ToTable("Publisher");
			modelBuilder.Entity<Review>().ToTable("Review");
			modelBuilder.Entity<Screenshot>().ToTable("Screenshot");
		}
	}
}
