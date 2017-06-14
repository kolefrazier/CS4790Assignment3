using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS4790Assignment3.Models.ViewModels
{
	public class GameDetails
	{
		public int GameID { get; set; }
		public string GameName { get; set; }
		public string PublisherName { get; set; }
		public bool PublisherIsIndie { get; set; }
		public bool PublisherIsTripleA { get; set; }
		public GameGenre Genre { get; set; }
		public double HoursPlayed { get; set; }
		public bool IsCompleted { get; set; }
		public List<Review> Reviews { get; set; }
	}
}
