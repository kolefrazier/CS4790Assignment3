using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS4790Assignment3.Models
{
	public class Publisher
	{
		public int PublisherID { get; set; }
		public string PublisherName { get; set; }
		public bool IsIndie { get; set; }
		public bool IsTripleA { get; set; }

		//Navigation Props
		public ICollection<Game> PublishedGames { get; set; }
	}
}
