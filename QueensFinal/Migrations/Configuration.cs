using System.Collections.ObjectModel;
using QueensFinal.Model;

namespace QueensFinal.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<QueensFinalDb>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(QueensFinalDb context)
		{
			var random = new Random();

			context.Competitions.AddOrUpdate(competition => competition.Name,
				new Competition
				{
					Name = "Queen's Final 2013",
					StartDateTime = new DateTime(2013, 7, 20, 14, 0, 0),
					Competitors = Enumerable.Range(1, 100).Select(x => 
						new Competitor
							{
								Name = "Competitor" + x,
								BroughtForwardPoints = random.Next(147,151),
								BroughtForwardVs = random.Next(12,26)
							}
					).ToList()
				}
			);
		}
	}
}
