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
		public string Name { get; set; }
		public string PublisherName { get; set; }
		public string Genre { get; set; }
		public double Price { get; set; }
		public bool AlreadyOwned { get; set; }
		public List<Review> Reviews { get; set; }
	}
}
