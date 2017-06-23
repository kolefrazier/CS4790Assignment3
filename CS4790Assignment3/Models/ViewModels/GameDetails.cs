using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CS4790Assignment3.Models.ViewModels
{
	/// <summary>
	/// Connects all game-detail models together to allow access to full details in a single ViewModel.
	/// </summary>
	public class GameDetails
	{
		public Game Game { get; set; }
		public Publisher Publisher { get; set; }
		public List<Review> Reviews { get; set; }
	}
}
