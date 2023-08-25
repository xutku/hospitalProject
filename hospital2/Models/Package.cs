using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class Package
	{
		public int PackageId { get; set; }

		public string PaketAdi { get; set; }

		public string Aciklama { get; set; }

		public decimal? Fiyat { get; set; }

		public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

		public virtual ICollection<PurchasedPackage> PurchasedPackages { get; set; } = new List<PurchasedPackage>();
	}
}