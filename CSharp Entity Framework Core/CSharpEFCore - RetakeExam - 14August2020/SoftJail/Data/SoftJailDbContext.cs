﻿namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<Cell> Cells { get; set; }

		public DbSet<Department> Departments { get; set; }

		public DbSet<Mail> Mails { get; set; }

		public DbSet<Officer> Officers { get; set; }

		public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

		public DbSet<Prisoner> Prisoners { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString)
					.UseLazyLoadingProxies();
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<OfficerPrisoner>().HasKey(op => new { op.PrisonerId, op.OfficerId });

			builder.Entity<OfficerPrisoner>()
				.HasOne(x => x.Prisoner)
				.WithMany(x => x.PrisonerOfficers)
				.HasForeignKey(x => x.PrisonerId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}