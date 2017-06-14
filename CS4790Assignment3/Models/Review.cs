using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS4790Assignment3.Models
{
	public class Review
	{
		public int ReviewID { get; set; }
		public int AuthorID { get; set; }
		public bool DoesRecommend { get; set; }
		public string ReviewContent { get; set; }
		
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime SubmissionDate { get; set; }
		public DateTime LastUpdateDate { get; set; }

		//Navigation Props
		public Game Game { get; set; }
	}
}
