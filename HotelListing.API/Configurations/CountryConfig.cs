using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Configurations
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new Country
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
        }
    }
}
