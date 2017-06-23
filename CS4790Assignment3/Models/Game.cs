using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CS4790Assignment3.Models
{
	public class Game
	{
		//Member Props
		public int GameID { get; set; }

		[Required(ErrorMessage = "Invalid name entered for game.")]
		[Display(Name = "Game Name")]
		public string Name { get; set; }
		[Required]
		public string Genre { get; set; }

		[DataType(DataType.Currency)]
		[Range(0, double.MaxValue, ErrorMessage = "Please a valid price.")]
		[Required]
		public double Price { get; set; }
		[Display(Name = "Online Multiplayer Capable")]
		[Required(ErrorMessage = "Online gameplay status must be set.")]
		public bool IsOnlineMultiplayer { get; set; }
		[Display(Name = "Is Completed")]
		[Required]
		public bool AlreadyOwned { get; set; }

		//Navigation Props
		public int PublisherID { get; set; }
		public virtual Publisher Publisher { get; set; }
		public virtual ICollection<Review> Reviews { get; set; }
	}
}
