using HotelListing.API.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HotelListing.API.Data
{
	public class HotelListingDbContext : IdentityDbContext<ApiUser>
	{
		public HotelListingDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Country> Countries { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new RoleConfiguration());
			modelBuilder.ApplyConfiguration(new CountryConfiguration());
			modelBuilder.ApplyConfiguration(new HotelConfiguration());
		}
	}

	public class HotelListingDbContextFactory : IDesignTimeDbContextFactory<HotelListingDbContext>
	{
		public HotelListingDbContext CreateDbContext(string[] args)
		{
			var configuration = new ConfigurationBuilder()
			 .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			 .AddJsonFile("appsettings.json")
			 .Build();

			var optionsBuilder = new DbContextOptionsBuilder<HotelListingDbContext>();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("HotelListingDbConnectionString"));

			return new HotelListingDbContext(optionsBuilder.Options);
		}
	}
}