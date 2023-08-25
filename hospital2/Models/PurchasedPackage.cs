using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class PurchasedPackage
	{
		public int PurchaseId { get; set; }

		public int? UserId { get; set; }

		public int? PackageId { get; set; }

		public DateTime? Tarİh { get; set; }

		public virtual Package Package { get; set; }

		public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

		public virtual User User { get; set; }
	}
}