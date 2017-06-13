using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790Assignment3.Models
{
	public class Review
	{
		public int ReviewID { get; set; }
		public string ReviewedGameName { get; set; }
		public int AuthorID { get; set; }
		public bool DoesRecommend { get; set; }
		public string ReviewContent { get; set; }
		public DateTime SubmissionDate { get; set; }
		public DateTime LastUpdateDate { get; set; }

		//Navigation Props
		public Game Game { get; set; }
	}
}
