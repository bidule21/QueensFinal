using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

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

			Thread.Sleep(1000);

			// Create a new Queens Final event
			string competitionName = "QueensFinal - " + DateTime.Now.ToString();
			var competitionId = hubProxy.Invoke<int>("CreateCompetition", competitionName).Result;

			// Create 100 register cards / competitors
			var registerCards = Enumerable.Range(1, 100).Select(i =>
			{
				return new RegisterCard
				{
					CompetitorName = "Competitor" + i,
					CompetitorIndexNumber = i,
					BroughtForwardPoints = Random.Next(147, 151),
					BroughtForwardVs = Random.Next(12, 26)
				};
			}).ToList();

			// Add each register card
			registerCards.ForEach(registerCard =>
			{
				registerCard.RegisterCardId = hubProxy.Invoke<int>(
					"AddRegisterCard",
					competitionId,
					registerCard.CompetitorName,
					registerCard.CompetitorIndexNumber,
					registerCard.BroughtForwardPoints,
					registerCard.BroughtForwardVs
				).Result;
			});


			// Simulate competitors
			registerCards.AsParallel().WithDegreeOfParallelism(registerCards.Count).ForAll(competitor =>
			{
				for (int i = 1; i <= 2; i++)
				{
					Thread.Sleep(1000 * Random.Next(90));

					Console.WriteLine("AddShot - Competitor {0}, Shot {1}", competitor.CompetitorName, "S" + i);

					// RegisterScore(int competitionId, int competitorId, string shotNumber, string score)
					hubProxy.Invoke("AddShot",
						competitionId,
						competitor.RegisterCardId,
						"x900",
						"S" + i,
						(Score)Scores.GetValue(Random.Next(Scores.Length))).Wait();
				}

				for (int i = 1; i <= 15; i++)
				{
					Thread.Sleep(1000 * Random.Next(90));

					Console.WriteLine("AddShot - Competitor {0}, Shot {1}", competitor.CompetitorName, i);

					// RegisterScore(int competitionId, int competitorId, string shotNumber, string score)
					hubProxy.Invoke("AddShot",
						competitionId,
						competitor.RegisterCardId,
						"x900",
						i.ToString(CultureInfo.InvariantCulture),
						(Score)Scores.GetValue(Random.Next(Scores.Length))).Wait();
				}
			});


			hubConnection.Stop();
		}
	}

	public enum Score
	{
		Zero,
		One,
		Two,
		Three,
		Four,
		Five,
		V
	}
}
