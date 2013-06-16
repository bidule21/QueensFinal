using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QueensFinal.Models
{
	public class QueensFinalDb : DbContext
	{
		public QueensFinalDb()
			: base("name=DefaultConnection")
		{
			
		}
		public DbSet<Competition> Competitions { get; set; }
		public DbSet<Competitor> Competitors { get; set; }
	}
}