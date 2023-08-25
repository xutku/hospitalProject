using System;
using System.Collections.Generic;

namespace medicEnd.Models
{
	public partial class User
	{
		public int UserId { get; set; }

		public string Ad { get; set; }

		public string Soyad { get; set; }

		public string EPosta { get; set; }

		public string Sifre { get; set; }

		public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

		public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

		public virtual ICollection<PurchasedPackage> PurchasedPackages { get; set; } = new List<PurchasedPackage>();

		public virtual ICollection<Result> Results { get; set; } = new List<Result>();
	}
}