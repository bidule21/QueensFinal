using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueensFinal.Models
{
	public class Competition
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime StartDateTime { get; set; }
		public ICollection<Competitor> Competitors { get; set; }
	}
}