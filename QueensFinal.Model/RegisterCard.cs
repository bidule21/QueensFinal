using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace QueensFinal.Model
{
	public class RegisterCard
	{
		public int Id { get; set; }
		public int CompetitorIndexNumber { get; set; }
		public string CompetitorName { get; set; }
		public int BroughtForwardPoints { get; set; }
		public int BroughtForwardVs { get; set; }

		public Score? x900Sighter1 { get; set; }
		public Score? x900Sighter2 { get; set; }
		public bool? x900Sighter1Converted { get; set; }
		public bool? x900Sighter2Converted { get; set; }
		public Score? x900Shot1 { get; set; }
		public Score? x900Shot2 { get; set; }
		public Score? x900Shot3 { get; set; }
		public Score? x900Shot4 { get; set; }
		public Score? x900Shot5 { get; set; }
		public Score? x900Shot6 { get; set; }
		public Score? x900Shot7 { get; set; }
		public Score? x900Shot8 { get; set; }
		public Score? x900Shot9 { get; set; }
		public Score? x900Shot10 { get; set; }
		public Score? x900Shot11 { get; set; }
		public Score? x900Shot12 { get; set; }
		public Score? x900Shot13 { get; set; }
		public Score? x900Shot14 { get; set; }
		public Score? x900Shot15 { get; set; }

		public Score? x1000Sighter1 { get; set; }
		public Score? x1000Sighter2 { get; set; }
		public bool? x1000Sighter1Converted { get; set; }
		public bool? x1000Sighter2Converted { get; set; }
		public Score? x1000Shot1 { get; set; }
		public Score? x1000Shot2 { get; set; }
		public Score? x1000Shot3 { get; set; }
		public Score? x1000Shot4 { get; set; }
		public Score? x1000Shot5 { get; set; }
		public Score? x1000Shot6 { get; set; }
		public Score? x1000Shot7 { get; set; }
		public Score? x1000Shot8 { get; set; }
		public Score? x1000Shot9 { get; set; }
		public Score? x1000Shot10 { get; set; }
		public Score? x1000Shot11 { get; set; }
		public Score? x1000Shot12 { get; set; }
		public Score? x1000Shot13 { get; set; }
		public Score? x1000Shot14 { get; set; }
		public Score? x1000Shot15 { get; set; }

		//public int CompetitionId { get; set; }

		private IEnumerable<Score?> x900CountingShots
		{
			get
			{
				var countingShotPropertyPattern = "x900Shot\\d+";
				return GetType().GetProperties()
					.Where(p => Regex.IsMatch(p.Name, countingShotPropertyPattern))
					.Select(countingShot => (Score?)countingShot.GetValue(this));
			}
		}

		private IEnumerable<Score?> x1000CountingShots
		{
			get
			{
				var countingShotPropertyPattern = "x1000Shot\\d+";
				return GetType().GetProperties()
					.Where(p => Regex.IsMatch(p.Name, countingShotPropertyPattern))
					.Select(countingShot => (Score?)countingShot.GetValue(this));
			}
		}

		public int TotalPointsOff
		{
			get
			{
				var pointsOff = 150 - BroughtForwardPoints;

				foreach (var score in x900CountingShots.Union(x1000CountingShots))
				{
					if (!score.HasValue)
						continue;
					else if (score.Value == Score.V)
						continue;
					else
						pointsOff += 5 - (int)score.Value;
				}

				return pointsOff;
			}
		}

		public string RangeTotal<T>(T scores) where T : IEnumerable<Score?>
		{
			if (scores.Any(s => !s.HasValue))
				return String.Empty;
			else
			{
				var points = scores.Sum(s => (s == Score.V ? 5 : (int)s));
				var vbulls = scores.Count(s => s == Score.V);
				return points.ToString() + '.' + vbulls.ToString();
			}
		}

		public string x900Total
		{
			get
			{
				return RangeTotal(x900CountingShots);
			}
		}

		public string x1000Total { get { return RangeTotal(x1000CountingShots); } }

		public int SortOrder
		{
			get
			{
				return TotalPointsOff;
			}
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

	public static class Extensions
	{
		public static string DisplayValue(this Score? score)
		{
			if (score.HasValue)
				return score.Value.DisplayValue();
			else
				return String.Empty;
		}

		public static string DisplayValue(this Score score)
		{
			switch (score)
			{
				case Score.Zero:
					return "0";
				case Score.One:
					return "1";
				case Score.Two:
					return "2";
				case Score.Three:
					return "3";
				case Score.Four:
					return "4";
				case Score.Five:
					return "5";
				case Score.V:
					return "V";
				default:
					return String.Empty;
			}
		}

	}
}
