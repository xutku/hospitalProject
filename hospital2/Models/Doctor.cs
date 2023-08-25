using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class Doctor
	{
		public int DoctorId { get; set; }

		public string Ad { get; set; }

		public string Soyad { get; set; }

		public string UzmanlikAlani { get; set; }

		public string IletisimBilgileri { get; set; }

		public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

		public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

		public virtual ICollection<Result> Results { get; set; } = new List<Result>();

		public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
	}
}