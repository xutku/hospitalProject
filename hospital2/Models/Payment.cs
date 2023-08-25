using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class Payment
	{
		public int PaymentId { get; set; }

		public int? PurchaseId { get; set; }

		public decimal? Tutar { get; set; }

		public DateTime? OdemeTarihi { get; set; }

		public virtual PurchasedPackage Purchase { get; set; }
	}
}