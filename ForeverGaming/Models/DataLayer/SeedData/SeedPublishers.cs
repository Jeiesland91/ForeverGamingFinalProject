using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForeverGaming.Models
{
    internal class SeedPublishers : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> entity)
        {
            entity.HasData(
                new Publisher { PublisherId = "343IND", Name = "343 Ind." },
                new Publisher { PublisherId = "A4GAMES", Name = "A4 Games" },
                new Publisher { PublisherId = "ACT ", Name = "Activision" },
                new Publisher { PublisherId = "AFTER", Name = "Afterthought" },
                new Publisher { PublisherId = "ASOBO", Name = "Asobo Studio" },
                new Publisher { PublisherId = "BLIZZ", Name = "Blizzard Entertainment" },
                new Publisher { PublisherId = "BOHEM", Name = "Bohemia Interactive" },
                new Publisher { PublisherId = "BETH", Name = "Bethesda Softwarks" },
                new Publisher { PublisherId = "BSG", Name = "Battle State Games" },
                new Publisher { PublisherId = "CA ", Name = "Creative Assembly" },
                new Publisher { PublisherId = "CAPCOM", Name = "Capcom" },
                new Publisher { PublisherId = "CDPR", Name = "CD Projekt Red" },
                new Publisher { PublisherId = "CREEP", Name = "Creepy Jar" },
                new Publisher { PublisherId = "DG", Name = "Daybreak Games" },
                new Publisher { PublisherId = "DICE", Name = "DICE" },
                new Publisher { PublisherId = "DTG", Name = "Dead Thread Games" },
                new Publisher { PublisherId = "EA", Name = "Electronic Arts" },
                new Publisher { PublisherId = "EATIB", Name = "EA Tiburon" },
                new Publisher { PublisherId = "EAGLE", Name = "Eagle Dynamics" },
                new Publisher { PublisherId = "ES", Name = "Ensemble Studios" },
                new Publisher { PublisherId = "FRICT", Name = "Frictional Games" },
                new Publisher { PublisherId = "FROST", Name = "Frostburn Studios" },
                new Publisher { PublisherId = "GGG", Name = "Grinding Gear Games" },
                new Publisher { PublisherId = "GARRY", Name = "Garry Newman" },
                new Publisher { PublisherId = "GOOGLE", Name = "Google Play" },
                new Publisher { PublisherId = "HIREZ", Name = "Hi-Rez Studios" },
                new Publisher { PublisherId = "INNER", Name = "InnerSloth" },
                new Publisher { PublisherId = "KINETIC", Name = "Kinetic Games" },
                new Publisher { PublisherId = "MEDIA", Name = "Mediatonic" },
                new Publisher { PublisherId = "MOON", Name = "Moonton" },
                new Publisher { PublisherId = "NIN", Name = "Nintendo" },
                new Publisher { PublisherId = "ORIGIN", Name = "Origin Games" },
                new Publisher { PublisherId = "PLAY", Name = "Playground games" },
                new Publisher { PublisherId = "PROLET", Name = "Proletariat Inc." },
                new Publisher { PublisherId = "QSX", Name = "QuickSilverX" },
                new Publisher { PublisherId = "REDBAR", Name = "Red Barrels" },
                new Publisher { PublisherId = "ROGUE", Name = "Rogue Entertainment" },
                new Publisher { PublisherId = "RIOT", Name = "Riot Games" },
                new Publisher { PublisherId = "ROCK", Name = "RockStar Games" },
                new Publisher { PublisherId = "SEM", Name = "Super Evil Megacorp" },
                new Publisher { PublisherId = "SONY", Name = "Sony Interactive Entertainment" },
                new Publisher { PublisherId = "SOURCE", Name = "Source" },
                new Publisher { PublisherId = "STUN", Name = "Stunlock Studios" },
                new Publisher { PublisherId = "STEAM", Name = "Steam" },
                new Publisher { PublisherId = "TMETA", Name = "The Meta" },
                new Publisher { PublisherId = "TETSUYA", Name = "Tetsuya Nomura" },
                new Publisher { PublisherId = "TREY ", Name = "Treyarch" },
                new Publisher { PublisherId = "TRITER", Name = "Triternion " },
                new Publisher { PublisherId = "TIMI", Name = "TiMi Studios" },
                new Publisher { PublisherId = "UBI", Name = "Ubisoft" },
                new Publisher { PublisherId = "UNITY", Name = "Unity" },
                new Publisher { PublisherId = "UNREAL", Name = "Unreal" },
                new Publisher { PublisherId = "VALVE", Name = "Valve" },
                new Publisher { PublisherId = "VERANT", Name = "Verant Interactive" }
            );
        }
    }
}
