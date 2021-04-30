using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForeverGaming.Models
{
    internal class SeedFormats : IEntityTypeConfiguration<Format>
    {
        public void Configure(EntityTypeBuilder<Format> entity)
        {
            entity.HasData(
                new Format { FormatId = "ARCADE", Name = "Arcade Game" },
                new Format { FormatId = "CONSOLE", Name = "Gaming console" },
                new Format { FormatId = "MOBILE", Name = "Mobile Device" },
                new Format { FormatId = "PC", Name = "Personal Computer" },
                new Format { FormatId = "STREAMING", Name = "Streaming" },
                new Format { FormatId = "TV", Name = "Television" },
                new Format { FormatId = "VIRTUAL", Name = "Virtual Reality" },
                new Format { FormatId = "WEB", Name = "Web Browser" }
            );
        }
    }
}
