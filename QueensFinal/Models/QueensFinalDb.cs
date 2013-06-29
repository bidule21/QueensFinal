using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QueensFinal.Model
{
	public class QueensFinalDb : DbContext
	{
		public QueensFinalDb()
			: base("name=DefaultConnection")
		{
			Configuration.ProxyCreationEnabled = false;
		}
		public DbSet<Competition> Competitions { get; set; }
		public DbSet<Competitor> Competitors { get; set; }
	}
}