using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueensFinal.Model
{
	public class RegisterCard
	{
		public int Id { get; set; }
		public int CompetitorIndexNumber { get; set; }
		public string CompetitorName { get; set; }
		public int BroughtForwardPoints { get; set; }
		public int BroughtForwardVs { get; set; }
		
		public Score x900Sighter1 { get; set; }
		public Score x900Sighter2 { get; set; }
		public bool x900Sighter1Converted { get; set; }
		public bool x900Sighter2Converted { get; set; }
		public Score x900Shot1 { get; set; }
		public Score x900Shot2 { get; set; }
		public Score x900Shot3 { get; set; }
		public Score x900Shot4 { get; set; }
		public Score x900Shot5 { get; set; }
		public Score x900Shot6 { get; set; }
		public Score x900Shot7 { get; set; }
		public Score x900Shot8 { get; set; }
		public Score x900Shot9 { get; set; }
		public Score x900Shot10 { get; set; }
		public Score x900Shot11 { get; set; }
		public Score x900Shot12 { get; set; }
		public Score x900Shot13 { get; set; }
		public Score x900Shot14 { get; set; }
		public Score x900Shot15 { get; set; }

		public Score x1000Sighter1 { get; set; }
		public Score x1000Sighter2 { get; set; }
		public bool x1000Sighter1Converted { get; set; }
		public bool x1000Sighter2Converted { get; set; }
		public Score x1000Shot1 { get; set; }
		public Score x1000Shot2 { get; set; }
		public Score x1000Shot3 { get; set; }
		public Score x1000Shot4 { get; set; }
		public Score x1000Shot5 { get; set; }
		public Score x1000Shot6 { get; set; }
		public Score x1000Shot7 { get; set; }
		public Score x1000Shot8 { get; set; }
		public Score x1000Shot9 { get; set; }
		public Score x1000Shot10 { get; set; }
		public Score x1000Shot11 { get; set; }
		public Score x1000Shot12 { get; set; }
		public Score x1000Shot13 { get; set; }
		public Score x1000Shot14 { get; set; }
		public Score x1000Shot15 { get; set; }

		//public int CompetitionId { get; set; }

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
