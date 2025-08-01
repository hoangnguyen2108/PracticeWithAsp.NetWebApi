using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>()
                .HasOne(c => c.Country)
                .WithMany(c => c.HotelList)
                .HasPrincipalKey(c => c.Id);
            modelBuilder.Entity<Country>().HasData(new Country
            {
                Id = 1,
                Name = "Country1",
                ShortName = "ShortName1"

            }, new Country
            {
                Id = 2,
                Name = "Country2",
                ShortName = "ShortName2"
            });
            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                Id = 1,
                Name = "Hotel1",
                Address = "Address1",
                Rating = 3.1,
                CountryId = 2

            }, new Hotel
            {
                Id = 2,
                Name = "Hotel2",
                Address = "Address2",
                Rating = 4.2,
                CountryId = 1
            });

            
        }
    }
}
