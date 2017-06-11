using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790Assignment3.Models
{
	public enum GameGenre
	{
		Action, Adventure, RPG, MMO, Horror, Roguelike, Platformer, Humor
	}

    public class Game
    {
		//ctor

		//prop
		public int GameID { get; set; }
		public string Name { get; set; }
		public GameGenre Genre { get; set; }
		public decimal Price { get; set; }
		public decimal HoursPlayed { get; set; }
		public bool IsCompleted { get; set; }
		public bool CurrentlyPlaying { get; set; }
		public bool IsOnlineMultiplayer { get; set; }
	}
}
