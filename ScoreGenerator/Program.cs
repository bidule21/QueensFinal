using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace ScoreGenerator
{
	class Program
	{
		private const string HubUrl = "http://queensfinal.azurewebsites.net/";
		//private const string HubUrl = "http://localhost:/";
		static private readonly Random Random = new Random();
		static readonly Array Scores = Enum.GetValues(typeof(Score));

		static void Main()
		{
			var hubConnection = new HubConnection(HubUrl) {TraceLevel = TraceLevels.All, TraceWriter = Console.Out};
			var hubProxy = hubConnection.CreateHubProxy("QueensFinalHub");
			ServicePointManager.DefaultConnectionLimit = 100;
			hubConnection.Start().Wait();

			//Thread.Sleep(1000);

			// Create a new Queens Final event
			string competitionName = "QueensFinal - " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
			var competitionId = hubProxy.Invoke<int>("CreateCompetition", competitionName).Result;

			// Create 20 register cards / competitors
			var registerCards = Enumerable.Range(1, 1).Select(i => new RegisterCard
				{
					CompetitorName = "Competitor" + i,
					CompetitorIndexNumber = i,
					BroughtForwardPoints = Random.Next(147, 151),
					BroughtForwardVs = Random.Next(12, 26)
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
					var parallelHubConnection = new HubConnection(HubUrl) {TraceLevel = TraceLevels.All, TraceWriter = Console.Out};
					var parallelHubProxy = parallelHubConnection.CreateHubProxy("QueensFinalHub");
					parallelHubConnection.Start().Wait();

					for (int i = 1; i <= 2; i++)
					{
						//Thread.Sleep(1000*Random.Next(20));

						Console.WriteLine("AddShot - Competitor {0}, Shot {1}", competitor.CompetitorName, "S" + i);

						// RegisterScore(int competitionId, int competitorId, string shotNumber, string score)
						parallelHubProxy.Invoke("AddShot",
						                        competitionId,
						                        competitor.RegisterCardId,
						                        "x900",
						                        "S" + i,
						                        (Score) Scores.GetValue(Random.Next(Scores.Length))).Wait();
					}

					for (int i = 1; i <= 15; i++)
					{
						//Thread.Sleep(1000*Random.Next(20));

						Console.WriteLine("AddShot - Competitor {0}, Shot {1}", competitor.CompetitorName, i);

						// RegisterScore(int competitionId, int competitorId, string shotNumber, string score)
						parallelHubProxy.Invoke("AddShot",
						                        competitionId,
						                        competitor.RegisterCardId,
						                        "x900",
						                        i.ToString(CultureInfo.InvariantCulture),
						                        (Score) Scores.GetValue(Random.Next(Scores.Length))).Wait();
					}

					// x1000
					for (int i = 1; i <= 2; i++)
					{
						Thread.Sleep(1000 * Random.Next(20));

						Console.WriteLine("AddShot - Competitor {0}, Shot {1}", competitor.CompetitorName, "S" + i);

						// RegisterScore(int competitionId, int competitorId, string shotNumber, string score)
						parallelHubProxy.Invoke("AddShot",
												competitionId,
												competitor.RegisterCardId,
												"x1000",
												"S" + i,
												(Score)Scores.GetValue(Random.Next(Scores.Length))).Wait();
					}

					for (int i = 1; i <= 15; i++)
					{
						Thread.Sleep(1000 * Random.Next(20));

						Console.WriteLine("AddShot - Competitor {0}, Shot {1}", competitor.CompetitorName, i);

						// RegisterScore(int competitionId, int competitorId, string shotNumber, string score)
						parallelHubProxy.Invoke("AddShot",
												competitionId,
												competitor.RegisterCardId,
												"x1000",
												i.ToString(CultureInfo.InvariantCulture),
												(Score)Scores.GetValue(Random.Next(Scores.Length))).Wait();
					}

					parallelHubConnection.Stop();
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
