using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForeverGaming.Models
{
    internal class SeedRatings : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> entity)
        {
            entity.HasData(
                new Rating { RatingId = "A", Name = "Adults only 18 and older" },
                new Rating { RatingId = "M", Name = "Mature 17 and older" },
                new Rating { RatingId = "T", Name = "Teen" },
                new Rating { RatingId = "E10", Name = "Everyone 10 and older" },
                new Rating { RatingId = "E", Name = "Everyone" }
            );
        }
    }
}
