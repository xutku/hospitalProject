using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class Department
	{
		public int DepartmentId { get; set; }

		public string DepartmentAd { get; set; }

		public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

		public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
	}
}