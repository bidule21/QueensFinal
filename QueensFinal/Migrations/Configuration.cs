using System.Collections.ObjectModel;
using QueensFinal.Models;

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
			context.Competitions.AddOrUpdate(competition => competition.Name,
				new Competition
				{
					Name = "Imperial 2013",
					StartDateTime = new DateTime(2013, 7, 20, 14, 0, 0),
					Competitors = new Collection<Competitor>
						{
							new Competitor
								{
									Name = "Mr TW Hunter",
									BroughtForwardPoints = 147,
									BroughtForwardVs = 22
								}
						}
				}
			);
		}
	}
}
