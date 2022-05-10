using System;
using System.Collections.Generic;
using System.Text;

namespace GenericHostApp.Models
{
	public sealed class CountSheepSettingsModel
	{
		public int HowManySheepToCount { get; set; }
		public int HowFastToCountThemSheep { get; set; }
		public int HowLongUntilEviction { get; set; }
	}
}
