using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace medicEnd.Models
{
	public partial class Medic1Context : DbContext
	{
		public Medic1Context()
		{
		}

		public Medic1Context(DbContextOptions<Medic1Context> options)
			: base(options)
		{
		}

		public virtual DbSet<Appointment> Appointments { get; set; }

		public virtual DbSet<Blog> Blogs { get; set; }

		public virtual DbSet<Cart> Carts { get; set; }

		public virtual DbSet<Department> Departments { get; set; }

		public virtual DbSet<Doctor> Doctors { get; set; }

		public virtual DbSet<Package> Packages { get; set; }

		public virtual DbSet<Payment> Payments { get; set; }

		public virtual DbSet<PurchasedPackage> PurchasedPackages { get; set; }

		public virtual DbSet<Result> Results { get; set; }

		public virtual DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
			=> optionsBuilder.UseSqlServer("Server=DESKTOP-5RECIFK\\SQLEXPRESS;Database=medic1;Trusted_Connection=True;TrustServerCertificate=True");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Appointment>(entity =>
			{
				entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__49B308C6126A06B1");

				entity.Property(e => e.AppointmentId).HasColumnName("APPOINTMENT_ID");
				entity.Property(e => e.DoctorId).HasColumnName("DOCTOR_ID");
				entity.Property(e => e.Saat).HasColumnName("SAAT");
				entity.Property(e => e.Tarİh)
					.HasColumnType("date")
					.HasColumnName("TARİH");
				entity.Property(e => e.UserId).HasColumnName("USER_ID");

				entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
					.HasForeignKey(d => d.DoctorId)
					.HasConstraintName("FK__Appointme__DOCTO__4222D4EF");

				entity.HasOne(d => d.User).WithMany(p => p.Appointments)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK__Appointme__USER___412EB0B6");
			});

			modelBuilder.Entity<Blog>(entity =>
			{
				entity.HasKey(e => e.BlogId).HasName("PK__Blogs__F913A29DB156BCE4");

				entity.Property(e => e.BlogId).HasColumnName("BLOG_ID");
				entity.Property(e => e.Başlik)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasColumnName("BAŞLIK");
				entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
				entity.Property(e => e.DoktorId).HasColumnName("DOKTOR_ID");
				entity.Property(e => e.Tarİh)
					.HasColumnType("date")
					.HasColumnName("TARİH");
				entity.Property(e => e.İçerİk)
					.HasMaxLength(1000)
					.IsUnicode(false)
					.HasColumnName("İÇERİK");

				entity.HasOne(d => d.Department).WithMany(p => p.Blogs)
					.HasForeignKey(d => d.DepartmentId)
					.HasConstraintName("FK__Blogs__DEPARTMEN__5629CD9C");

				entity.HasOne(d => d.Doktor).WithMany(p => p.Blogs)
					.HasForeignKey(d => d.DoktorId)
					.HasConstraintName("FK__Blogs__DOKTOR_ID__5535A963");
			});

			modelBuilder.Entity<Cart>(entity =>
			{
				entity.HasKey(e => e.CartId).HasName("PK__Cart__AB01BF6F4922C760");

				entity.ToTable("Cart");

				entity.Property(e => e.CartId).HasColumnName("CART_ID");
				entity.Property(e => e.Adet).HasColumnName("ADET");
				entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");
				entity.Property(e => e.UserId).HasColumnName("USER_ID");

				entity.HasOne(d => d.Package).WithMany(p => p.Carts)
					.HasForeignKey(d => d.PackageId)
					.HasConstraintName("FK__Cart__PACKAGE_ID__4E88ABD4");

				entity.HasOne(d => d.User).WithMany(p => p.Carts)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK__Cart__USER_ID__4D94879B");
			});

			modelBuilder.Entity<Department>(entity =>
			{
				entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__63E6136264E94C45");

				entity.Property(e => e.DepartmentId).HasColumnName("DEPARTMENT_ID");
				entity.Property(e => e.DepartmentAd)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("DEPARTMENT_AD");
			});

			modelBuilder.Entity<Doctor>(entity =>
			{
				entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__596ABDB0D5A7054A");

				entity.Property(e => e.DoctorId).HasColumnName("DOCTOR_ID");
				entity.Property(e => e.Ad)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("AD");
				entity.Property(e => e.IletisimBilgileri)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasColumnName("ILETISIM_BILGILERI");
				entity.Property(e => e.Soyad)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("SOYAD");
				entity.Property(e => e.UzmanlikAlani)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("UZMANLIK_ALANI");

				entity.HasMany(d => d.Departments).WithMany(p => p.Doctors)
					.UsingEntity<Dictionary<string, object>>(
						"DoctorDepartment",
						r => r.HasOne<Department>().WithMany()
							.HasForeignKey("DepartmentId")
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__Doctor_De__DEPAR__3E52440B"),
						l => l.HasOne<Doctor>().WithMany()
							.HasForeignKey("DoctorId")
							.OnDelete(DeleteBehavior.ClientSetNull)
							.HasConstraintName("FK__Doctor_De__DOCTO__3D5E1FD2"),
						j =>
						{
							j.HasKey("DoctorId", "DepartmentId").HasName("PK__Doctor_D__6F54DC861E7B9FE1");
							j.ToTable("Doctor_Departments");
							j.IndexerProperty<int>("DoctorId")
								.ValueGeneratedOnAdd()
								.HasColumnName("DOCTOR_ID");
							j.IndexerProperty<int>("DepartmentId").HasColumnName("DEPARTMENT_ID");
						});
			});

			modelBuilder.Entity<Package>(entity =>
			{
				entity.HasKey(e => e.PackageId).HasName("PK__Packages__D41E21614412EF40");

				entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");
				entity.Property(e => e.Aciklama)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasColumnName("ACIKLAMA");
				entity.Property(e => e.Fiyat)
					.HasColumnType("decimal(10, 2)")
					.HasColumnName("FIYAT");
				entity.Property(e => e.PaketAdi)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("PAKET_ADI");
			});

			modelBuilder.Entity<Payment>(entity =>
			{
				entity.HasKey(e => e.PaymentId).HasName("PK__Payments__D2C4FF466FAC8DA6");

				entity.Property(e => e.PaymentId).HasColumnName("PAYMENT_ID");
				entity.Property(e => e.OdemeTarihi)
					.HasColumnType("date")
					.HasColumnName("ODEME_TARIHI");
				entity.Property(e => e.PurchaseId).HasColumnName("PURCHASE_ID");
				entity.Property(e => e.Tutar)
					.HasColumnType("decimal(10, 2)")
					.HasColumnName("TUTAR");

				entity.HasOne(d => d.Purchase).WithMany(p => p.Payments)
					.HasForeignKey(d => d.PurchaseId)
					.HasConstraintName("FK__Payments__PURCHA__4AB81AF0");
			});

			modelBuilder.Entity<PurchasedPackage>(entity =>
			{
				entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__AF7B9D5497B26386");

				entity.ToTable("Purchased_Packages");

				entity.Property(e => e.PurchaseId).HasColumnName("PURCHASE_ID");
				entity.Property(e => e.PackageId).HasColumnName("PACKAGE_ID");
				entity.Property(e => e.Tarİh)
					.HasColumnType("date")
					.HasColumnName("TARİH");
				entity.Property(e => e.UserId).HasColumnName("USER_ID");

				entity.HasOne(d => d.Package).WithMany(p => p.PurchasedPackages)
					.HasForeignKey(d => d.PackageId)
					.HasConstraintName("FK__Purchased__PACKA__47DBAE45");

				entity.HasOne(d => d.User).WithMany(p => p.PurchasedPackages)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK__Purchased__USER___46E78A0C");
			});

			modelBuilder.Entity<Result>(entity =>
			{
				entity.HasKey(e => e.ResultId).HasName("PK__Results__A6156038FC9151F2");

				entity.Property(e => e.ResultId).HasColumnName("RESULT_ID");
				entity.Property(e => e.DoctorId).HasColumnName("DOCTOR_ID");
				entity.Property(e => e.Sonuc)
					.HasMaxLength(100)
					.IsUnicode(false)
					.HasColumnName("SONUC");
				entity.Property(e => e.Tarİh)
					.HasColumnType("date")
					.HasColumnName("TARİH");
				entity.Property(e => e.UserId).HasColumnName("USER_ID");

				entity.HasOne(d => d.Doctor).WithMany(p => p.Results)
					.HasForeignKey(d => d.DoctorId)
					.HasConstraintName("FK__Results__DOCTOR___52593CB8");

				entity.HasOne(d => d.User).WithMany(p => p.Results)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK__Results__USER_ID__5165187F");
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.HasKey(e => e.UserId).HasName("PK__Users__F3BEEBFFA65016AE");

				entity.Property(e => e.UserId).HasColumnName("USER_ID");
				entity.Property(e => e.Ad)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("AD");
				entity.Property(e => e.EPosta)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("E_POSTA");
				entity.Property(e => e.Sifre)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("SIFRE");
				entity.Property(e => e.Soyad)
					.HasMaxLength(50)
					.IsUnicode(false)
					.HasColumnName("SOYAD");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}