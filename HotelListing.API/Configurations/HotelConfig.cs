using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Configurations
{
    public class HotelConfig : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(new Hotel
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
