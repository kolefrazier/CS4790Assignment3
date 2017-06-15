using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790Assignment3.Models
{
	public class PublishedGames
	{
		//Reference IDs
		//public int GameID { get; set; }
		//public int PublisherID { get; set; }
										   //Reference Models
		public Publisher Publisher { get; set; }
		public Game Game { get; set; }
	}
}
