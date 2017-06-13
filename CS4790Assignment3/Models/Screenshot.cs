using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS4790Assignment3.Models
{
	public enum ScreenshotCategory
	{
		Humor, CoolMoment, Glitch, Achievement, Deathcam
	}

	public class Screenshot
	{
		public int ScreenshotID { get; set; }
		public DateTime CaptureTimestamp { get; set; }
		public string LocalPath { get; set; }
		public ScreenshotCategory Category { get; set; }
		public string SourceGame { get; set; }
	}
}
