using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class Appointment
	{
		public int AppointmentId { get; set; }

		public int? UserId { get; set; }

		public int? DoctorId { get; set; }

		public DateTime? Tarİh { get; set; }

		public TimeSpan? Saat { get; set; }

		public virtual Doctor Doctor { get; set; }

		public virtual User User { get; set; }
	}
}