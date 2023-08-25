using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class Blog
	{
		public int BlogId { get; set; }

		public string Başlik { get; set; }

		public string İçerİk { get; set; }

		public DateTime Tarİh { get; set; }

		public int? DoktorId { get; set; }

		public int? DepartmentId { get; set; }

		public virtual Department Department { get; set; }

		public virtual Doctor Doktor { get; set; }
	}
}