using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790Assignment3.Models
{
    public class Publisher
    {
		public int PublisherID { get; set; }
		public string Name { get; set; }
		public bool IsIndie { get; set; }
		public bool IsTripleA { get; set; }
		public List<Game> PublishedGames { get; set; }
	}
}
