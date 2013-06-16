using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueensFinal.Models
{
	public class Competition
	{
		public int Id { get; set; }
		public int Name { get; set; }
		public DateTime StartDateTime { get; set; }
		ICollection<Competitor> Competitors { get; set; }
	}
}