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

		public Competition GetCompetition(string competitionName)
		{
			using (var db = new QueensFinalDb())
			{
				var competition = db.Competitions.Include(c => c.Competitors).FirstOrDefault(c => c.Name == competitionName);
				if (competition == null)
				{
					throw new Exception(String.Format("Could not find competition named {0}", competitionName));
				}

				return competition;
			}
		}

		public void RegisterScore(int competitionId, int competitorId, string shotNumber, Score score)
		{
			Debug.WriteLine("Competition: {0}, Competitor: {1}, Shot Number: {2}, Score: {3}",
				competitionId, competitorId, shotNumber, score);
			Clients.All.RegisterShot(competitorId.ToString(CultureInfo.InvariantCulture), shotNumber, score.ToString());
		}
	}
}