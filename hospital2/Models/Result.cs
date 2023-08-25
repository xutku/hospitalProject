using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class Result
	{
		public int ResultId { get; set; }

		public int? UserId { get; set; }

		public int? DoctorId { get; set; }

		public DateTime? Tarİh { get; set; }

		public string Sonuc { get; set; }

		public virtual Doctor Doctor { get; set; }

		public virtual User User { get; set; }
	}
}