using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using QueensFinal.Model;

namespace ScoreGenerator
{
	class Program
	{
		static private readonly Random Random = new Random();
		static readonly Array Scores = Enum.GetValues(typeof(Score));

		static void Main()
		{
			var hubConnection = new HubConnection("http://localhost:59570/");
			hubConnection.TraceLevel = TraceLevels.All;
			hubConnection.TraceWriter = Console.Out;
			var hubProxy = hubConnection.CreateHubProxy("QueensFinalHub");

			hubConnection.Start().Wait();

			var competition = hubProxy.Invoke<Competition>("GetCompetition", "Queen's Final 2013").Result;

			//var targets = Enumerable.Range(1, 50);
			competition.Competitors.AsParallel().WithDegreeOfParallelism(competition.Competitors.Count).ForAll(competitor =>
				{
					for (int i = 1; i <= 2; i++)
					{
						Thread.Sleep(1000 * Random.Next(45));
						
						// RegisterScore(int competitionId, int competitorId, string shotNumber, string score)
						hubProxy.Invoke("RegisterScore",
							competition.Id,
							competitor.Id,
							"S" + i,
							(Score)Scores.GetValue(Random.Next(Scores.Length)));
					}

					for (int i = 1; i <= 15; i++)
					{
						Thread.Sleep(1000 * Random.Next(45));

						// RegisterScore(int competitionId, int competitorId, string shotNumber, string score)
						hubProxy.Invoke("RegisterScore",
							competition.Id,
							competitor.Id,
							i.ToString(CultureInfo.InvariantCulture),
							(Score)Scores.GetValue(Random.Next(Scores.Length)));
					}
				}
			);

			hubConnection.Stop();
		}
	}
}
