using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using QueensFinal.Model;

namespace QueensFinal.Hubs
{
	public class QueensFinalHub : Hub
	{

		public int CreateCompetition(string competitionName)
		{
			using (var db = new QueensFinalDb())
			{
				var competition = new Competition();
				competition.Name = competitionName;
				competition.StartDateTime = DateTime.Now;

				db.Competitions.Add(competition);
				db.SaveChanges();

				return competition.Id;
			}
		}

		public int AddRegisterCard(
			int competitionId,
			string competitorName,
			int competitorIndexNumber,
			int broughtForwardPoints,
			int broughtForwardVs)
		{
			using (var db = new QueensFinalDb())
			{
				var registerCard = new RegisterCard
				{
					CompetitorName = competitorName,
					CompetitorIndexNumber = competitorIndexNumber,
					BroughtForwardPoints = broughtForwardPoints,
					BroughtForwardVs = broughtForwardVs
				};

				var competition = db.Competitions.Include(c => c.RegisterCards).Single(c => c.Id == competitionId);
				competition.RegisterCards.Add(registerCard);
				db.SaveChanges();

				return registerCard.Id;
			}
		}

		//public Competition GetCompetition(string competitionName)
		//{
		//	using (var db = new QueensFinalDb())
		//	{
		//		var competition = db.Competitions.Include(c => c.RegisterCards).FirstOrDefault(c => c.Name == competitionName);
		//		if (competition == null)
		//		{
		//			throw new Exception(String.Format("Could not find competition named {0}", competitionName));
		//		}

		//		return competition;
		//	}
		//}

		public void AddShot(int competitionId, int registerCardId, string distance, string shotNumber, Score score)
		{
			Debug.WriteLine("Competition: {0}, Competitor: {1}, Distance: {2}, Shot Number: {3}, Score: {4}",
				competitionId, registerCardId, distance, shotNumber, score);

			using (var db = new QueensFinalDb())
			{
				var rc = db.RegisterCards.Find(registerCardId);

				// bit of reflection to avoid huge case statement
				var propName = distance
					+ (shotNumber.StartsWith("S") ? "Sighter" : "Shot")
					+ shotNumber.TrimStart(new[] {'S'});
				var prop = typeof(RegisterCard).GetProperty(propName);
				prop.SetValue(rc,score);

				db.SaveChanges();

				Clients.All.RegisterShot(registerCardId, distance, shotNumber, score.DisplayValue(),
					rc.TotalPointsOff, rc.X900Total, rc.X1000Total, rc.GrandTotal);
				
			}
		}

		public void ConvertBothSighters(int competitionId, int registerCardId, string distance)
		{

		}
	}
}