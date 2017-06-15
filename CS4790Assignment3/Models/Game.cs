using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS4790Assignment3.Models
{
	public enum GameGenre
	{
		Action, Adventure, RPG, MMO, Horror, Roguelike, Platformer, Humor, FirstPersonShooter
	}

	public class Game
	{
		//ctor

		//prop
		public int GameID { get; set; }

		[Required(ErrorMessage = "Please enter a valid game name.")]
		[Display(Name = "Game Name")]
		public string GameName { get; set; }

		public GameGenre Genre { get; set; }

		[DataType(DataType.Currency)]
		public double Price { get; set; }

		[Range(0, double.MaxValue, ErrorMessage = "Please enter a valid number.")]
		[Display(Name = "Hours Played")]
		public double HoursPlayed { get; set; }

		[Required]
		[Display(Name = "Is Completed")]
		public bool IsCompleted { get; set; }

		[Required]
		[Display(Name = "Currently Playing")]
		public bool CurrentlyPlaying { get; set; }

		[Required]
		[Display(Name = "Online Multiplayer Capable")]
		public bool IsOnlineMultiplayer { get; set; }

		//Navigation Props
		public Publisher Publisher { get; set; }
		public ICollection<Review> Reviews { get; set; }
		public ICollection<Screenshot> Screenshots { get; set; }
	}
}
