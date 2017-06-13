using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS4790Assignment3.Models.ViewModels
{
	public class GameDetails
	{
		public string GameName { get; set; }
		public string PublisherName { get; set; }
		public GameGenre Genre { get; set; }
		public double HoursPlayed { get; set; }
		public bool IsCompleted { get; set; }
		
	}
}
