using HotelListing.API.Configurations;
using HotelListing.API.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class ApplicationDbContext :IdentityDbContext<ApiUser>
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

            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new CountryConfig());          
            modelBuilder.ApplyConfiguration(new HotelConfig());
            

            
        }
    }
}
