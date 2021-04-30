using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForeverGaming.Models
{
    internal class SeedTypes : IEntityTypeConfiguration<Type>
    {
        public void Configure(EntityTypeBuilder<Type> entity)
        {
            entity.HasData(
                new Type { TypeId = "CB", Name = "City-Building" },
                new Type { TypeId = "CS", Name = "Combat Sports" },
                new Type { TypeId = "ED", Name = "Educational" },
                new Type { TypeId = "EX", Name = "Exercise" },
                new Type { TypeId = "FIGHTING", Name = "Fighting" },
                new Type { TypeId = "FPS", Name = "First Person Shooter" },
                new Type { TypeId = "GS", Name = "Grand Strategy" },
                new Type { TypeId = "IM", Name = "Interactive Movie" },
                new Type { TypeId = "LS", Name = "Life Sim" },
                new Type { TypeId = "MMORPG", Name = "Massively Multiplayer Online Role-Playing Game" },
                new Type { TypeId = "MOBA", Name = "Mobile Online Battle Area" },
                new Type { TypeId = "PG", Name = "Party Games" },
                new Type { TypeId = "PF", Name = "Platformer" },
                new Type { TypeId = "PUZZLE", Name = "Puzzle" },
                new Type { TypeId = "RACING", Name = "Racing" },
                new Type { TypeId = "RTS", Name = "Real Time Strategy" },
                new Type { TypeId = "RHYTHM", Name = "Rhythm" },
                new Type { TypeId = "RPG", Name = "Role-Play" },
                new Type { TypeId = "SRPG", Name = "Sandbox RPGs" },
                new Type { TypeId = "SIM", Name = "Simulation" },
                new Type { TypeId = "SPORT", Name = "Sport Games" },
                new Type { TypeId = "STEALTH", Name = "Stealth" },
                new Type { TypeId = "STRATEGY", Name = "Strategy" },
                new Type { TypeId = "SURVIVAL", Name = "Survival" },
                new Type { TypeId = "SH", Name = "Survival Horror" },
                new Type { TypeId = "TFPS", Name = "Tactical FPS" },
                new Type { TypeId = "TRP", Name = "Tactical Role-Play" },
                new Type { TypeId = "TS", Name = "Team Sports" },
                new Type { TypeId = "TEXT", Name = "Text" },
                new Type { TypeId = "TD", Name = "Tower Defense" },
                new Type { TypeId = "TRIVIA", Name = "Trivia" }
            );
        }
    }
}
