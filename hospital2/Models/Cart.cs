using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class Cart
	{
		public int CartId { get; set; }

		public int? UserId { get; set; }

		public int? PackageId { get; set; }

		public int? Adet { get; set; }

		public virtual Package Package { get; set; }

		public virtual User User { get; set; }
	}
}