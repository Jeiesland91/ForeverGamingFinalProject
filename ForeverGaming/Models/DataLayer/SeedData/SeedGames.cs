using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForeverGaming.Models
{
    internal class SeedGames : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> entity)
        {
            entity.HasData(
            new Game { GameId = 1, Name = "Doom", GenreId = "FPS", TypeId = "FPS", FormatId = "PC", RatingId = "M", PublisherId = "BETH", GameImage = "doom.png" },
            new Game { GameId = 2, Name = "DOTA 2", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "PC", RatingId = "E10", PublisherId = "VALVE", GameImage = "dota2.png" },
            new Game { GameId = 3, Name = "EA Sports MMA", GenreId = "SPORT", TypeId = "CS", FormatId = "CONSOLE", RatingId = "T", PublisherId = "EA", GameImage = "mma.png" },
            new Game { GameId = 4, Name = "Escape From Tarkov", GenreId = "SURVH", TypeId = "SH", FormatId = "PC", RatingId = "A", PublisherId = "BSG", GameImage = "EFT.png" },
            new Game { GameId = 5, Name = "EverQuest", GenreId = "MMORPG", TypeId = "SRPG", FormatId = "CONSOLE", RatingId = "T", PublisherId = "VERANT", GameImage = "everquest.png" },
            new Game { GameId = 6, Name = "Fall Guys: Ultimate Knockout", GenreId = "STRG", TypeId = "STRATEGY", FormatId = "PC", RatingId = "T", PublisherId = "MEDIA", GameImage = "Fguys.png" },
            new Game { GameId = 7, Name = "FarCry 3", GenreId = "RPG", TypeId = "RPG", FormatId = "PC", RatingId = "M", PublisherId = "UBI", GameImage = "F3.png" },
            new Game { GameId = 8, Name = "FarCry 4", GenreId = "RPG", TypeId = "RPG", FormatId = "PC", RatingId = "M", PublisherId = "UBI", GameImage = "F4.png" },
            new Game { GameId = 9, Name = "FIFA 20", GenreId = "SPORT", TypeId = "SPORT", FormatId = "CONSOLE", RatingId = "E", PublisherId = "EATIB", GameImage = "fifa20.png" },
            new Game { GameId = 10, Name = "Fight Night Champion", GenreId = "SPORT", TypeId = "CS", FormatId = "CONSOLE", RatingId = "M", PublisherId = "EA", GameImage = "fightnightchampion.png" },
            new Game { GameId = 11, Name = "Fight Night Round 4", GenreId = "SPORT", TypeId = "CS", FormatId = "CONSOLE", RatingId = "T", PublisherId = "EA", GameImage = "fightnight.png" },
            new Game { GameId = 12, Name = "Final Fantasy XV", GenreId = "RPG", TypeId = "FIGHTING", FormatId = "PC", RatingId = "T", PublisherId = "TETSUYA", GameImage = "FF.png" },
            new Game { GameId = 13, Name = "Forza Horizon 4", GenreId = "SPORT", TypeId = "RACING", FormatId = "CONSOLE", RatingId = "E", PublisherId = "PLAY", GameImage = "forza.png" },
            new Game { GameId = 14, Name = "Garry's Mod", GenreId = "PUZZLE", TypeId = "PUZZLE", FormatId = "PC", RatingId = "E", PublisherId = "GARRY", GameImage = "Gmod.png" },
            new Game { GameId = 15, Name = "Gran Turismo Sport", GenreId = "SPORT", TypeId = "RACING", FormatId = "CONSOLE", RatingId = "E", PublisherId = "SONY", GameImage = "granturismo.png" },
            new Game { GameId = 16, Name = "Grand Theft Auto 3", GenreId = "RPG", TypeId = "RPG", FormatId = "PC", RatingId = "A", PublisherId = "ROCK", GameImage = "GTA3.png" },
            new Game { GameId = 17, Name = "Grand Theft Auto 4", GenreId = "RPG", TypeId = "RPG", FormatId = "PC", RatingId = "A", PublisherId = "ROCK", GameImage = "GTA4.png" },
            new Game { GameId = 18, Name = "Grand Theft Auto 5", GenreId = "RPG", TypeId = "RPG", FormatId = "PC", RatingId = "A", PublisherId = "ROCK", GameImage = "GTA5.png" },
            new Game { GameId = 19, Name = "Green Hell", GenreId = "SURVH", TypeId = "SH", FormatId = "PC", RatingId = "M", PublisherId = "CREEP", GameImage = "GreenH.png" },
            new Game { GameId = 20, Name = "HALO 3", GenreId = "FPS", TypeId = "FPS", FormatId = "PC", RatingId = "T", PublisherId = "343IND", GameImage = "H3.png" },
            new Game { GameId = 21, Name = "HALO 4", GenreId = "FPS", TypeId = "FPS", FormatId = "PC", RatingId = "T", PublisherId = "343IND", GameImage = "H4.png" },
            new Game { GameId = 22, Name = "HALO Reach", GenreId = "FPS", TypeId = "FPS", FormatId = "PC", RatingId = "T", PublisherId = "343IND", GameImage = "Hreach.png" },
            new Game { GameId = 23, Name = "HD Poker", GenreId = "STRG", TypeId = "STRATEGY", FormatId = "PC", RatingId = "A", PublisherId = "GOOGLE", GameImage = "HD.png" },
            new Game { GameId = 24, Name = "Heroes of Newerth", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "PC", RatingId = "T", PublisherId = "FROST", GameImage = "heroesofnewerth.png" },
            new Game { GameId = 25, Name = "Heroes of the Storm", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "PC", RatingId = "T", PublisherId = "BOHEM", GameImage = "heroes.png" },
            new Game { GameId = 26, Name = "Kovaak 2.0", GenreId = "TFPS", TypeId = "TFPS", FormatId = "PC", RatingId = "T", PublisherId = "TMETA", GameImage = "Kovaak.png" },
            new Game { GameId = 27, Name = "League of Legends", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "PC", RatingId = "E10", PublisherId = "RIOT", GameImage = "league.png" },
            new Game { GameId = 28, Name = "Madden NFL", GenreId = "SPORT", TypeId = "SPORT", FormatId = "CONSOLE", RatingId = "E", PublisherId = "EATIB", GameImage = "maddennfl.png" },
            new Game { GameId = 29, Name = "Metro Exodus", GenreId = "RTS", TypeId = "RTS", FormatId = "PC", RatingId = "M", PublisherId = "A4GAMES", GameImage = "Metro.png" },
            new Game { GameId = 30, Name = "Microsoft Flight Simulator", GenreId = "SIMUL", TypeId = "SIM", FormatId = "PC", RatingId = "E", PublisherId = "ASOBO", GameImage = "MFS.png" },
            new Game { GameId = 31, Name = "Mobile Legends", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "MOBILE", RatingId = "T", PublisherId = "MOON", GameImage = "mobile.png" },
            new Game { GameId = 32, Name = "MORDHAU", GenreId = "MMORPG", TypeId = "SRPG", FormatId = "PC", RatingId = "A", PublisherId = "TRITER", GameImage = "Mord.png" },
            new Game { GameId = 33, Name = "NBA Jam", GenreId = "SPORT", TypeId = "SPORT", FormatId = "CONSOLE", RatingId = "E", PublisherId = "EATIB", GameImage = "nbajam.png" },
            new Game { GameId = 34, Name = "Outlast", GenreId = "SURVH", TypeId = "SH", FormatId = "PC", RatingId = "A", PublisherId = "REDBAR", GameImage = "Outlast.png" },
            new Game { GameId = 35, Name = "Outlast 2", GenreId = "SURVH", TypeId = "SH", FormatId = "PC", RatingId = "A", PublisherId = "REDBAR", GameImage = "Outlast2.png" },
            new Game { GameId = 36, Name = "Overwatch", GenreId = "FPS", TypeId = "FPS", FormatId = "PC", RatingId = "T", PublisherId = "BLIZZ", GameImage = "overwatch.png" },
            new Game { GameId = 37, Name = "Path Of Exile", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "PC", RatingId = "T", PublisherId = "GGG", GameImage = "POE.png" },
            new Game { GameId = 38, Name = "Phasmophobia", GenreId = "SURVH", TypeId = "SH", FormatId = "PC", RatingId = "M", PublisherId = "KINETIC", GameImage = "Phas.png" },
            new Game { GameId = 39, Name = "PUBG PlayersUnknown BattleGround", GenreId = "FPS", TypeId = "FPS", FormatId = "PC", RatingId = "A", PublisherId = "DG", GameImage = "PUBG.png" },
            new Game { GameId = 40, Name = "Red Dead Redemption 2", GenreId = "RPG", TypeId = "RPG", FormatId = "PC", RatingId = "M", PublisherId = "ROCK", GameImage = "RDR2.png" },
            new Game { GameId = 41, Name = "Resident Evil 2", GenreId = "SURVH", TypeId = "SH", FormatId = "PC", RatingId = "M", PublisherId = "CAPCOM", GameImage = "RE2.png" },
            new Game { GameId = 42, Name = "Resident Evil 3 Raccoon City", GenreId = "SURVH", TypeId = "SH", FormatId = "PC", RatingId = "M", PublisherId = "CAPCOM", GameImage = "RE3.png" },
            new Game { GameId = 43, Name = "Ring of Elysium", GenreId = "FPS", TypeId = "FPS", FormatId = "PC", RatingId = "A", PublisherId = "QSX", GameImage = "ROE.png" },
            new Game { GameId = 44, Name = "Sea of Thieves ", GenreId = "RTS", TypeId = "RTS", FormatId = "PC", RatingId = "T", PublisherId = "UNREAL", GameImage = "SOT.png" },
            new Game { GameId = 45, Name = "Smite", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "CONSOLE", RatingId = "T", PublisherId = "HIREZ", GameImage = "smite.png" },
            new Game { GameId = 46, Name = "SOMA", GenreId = "SURVH", TypeId = "SH", FormatId = "PC", RatingId = "A", PublisherId = "FRICT", GameImage = "SOMA.png" },
            new Game { GameId = 47, Name = "Spellbreak", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "PC", RatingId = "E", PublisherId = "PROLET", GameImage = "Spellbreak.png" },
            new Game { GameId = 48, Name = "StarCraft", GenreId = "RTS", TypeId = "FPS", FormatId = "PC", RatingId = "T", PublisherId = "BLIZZ", GameImage = "starcraft.png" },
            new Game { GameId = 49, Name = "StarCraft: Legacy of the Void", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "PC", RatingId = "T", PublisherId = "BLIZZ", GameImage = "starcraftlegacy.png" },
            new Game { GameId = 50, Name = "Strife", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "PC", RatingId = "M", PublisherId = "ROGUE", GameImage = "strife.png" },
            new Game { GameId = 51, Name = "The Elder Scrolls", GenreId = "RPG", TypeId = "RTS", FormatId = "CONSOLE", RatingId = "T", PublisherId = "BETH", GameImage = "elder.png" },
            new Game { GameId = 52, Name = "The ISLE", GenreId = "SURVH", TypeId = "SH", FormatId = "PC", RatingId = "M", PublisherId = "AFTER", GameImage = "Isle.png" },
            new Game { GameId = 53, Name = "The Witcher 3: Wild Hunt", GenreId = "RPG", TypeId = "SRPG", FormatId = "PC", RatingId = "M", PublisherId = "CDPR", GameImage = "witcher3.png" },
            new Game { GameId = 54, Name = "TOM CLANCY'S Rainbow Six Siege", GenreId = "FPS", TypeId = "FPS", FormatId = "PC", RatingId = "M", PublisherId = "UBI", GameImage = "R6S.png" },
            new Game { GameId = 55, Name = "UPC 2009 Undisputed", GenreId = "SPORT", TypeId = "CS", FormatId = "CONSOLE", RatingId = "T", PublisherId = "EA", GameImage = "upc.png" },
            new Game { GameId = 56, Name = "Vainglory", GenreId = "MOBAs", TypeId = "MOBA", FormatId = "MOBILE", RatingId = "T", PublisherId = "SEM", GameImage = "vain.png" },
            new Game { GameId = 57, Name = "Valheim", GenreId = "RPG", TypeId = "RPG", FormatId = "PC", RatingId = "E", PublisherId = "UNITY", GameImage = "Valheim.png" },
            new Game { GameId = 58, Name = "Valorant", GenreId = "FPS", TypeId = "FPS", FormatId = "PC", RatingId = "M", PublisherId = "RIOT", GameImage = "Val.png" },
            new Game { GameId = 59, Name = "We Went Back", GenreId = "PUZZLE", TypeId = "PUZZLE", FormatId = "PC", RatingId = "A", PublisherId = "DTG", GameImage = "WWB.png" },
            new Game { GameId = 60, Name = "Wii Sports", GenreId = "SPORT", TypeId = "SPORT", FormatId = "CONSOLE", RatingId = "E", PublisherId = "NIN", GameImage = "wiisports.png" },
            new Game { GameId = 61, Name = "Wolfenstein: The New Order", GenreId = "FPS", TypeId = "FPS", FormatId = "CONSOLE", RatingId = "A", PublisherId = "BETH", GameImage = "wolfenstein.png" },
            new Game { GameId = 62, Name = "World of Warcraft", GenreId = "MMORPG", TypeId = "SRPG", FormatId = "PC", RatingId = "T", PublisherId = "BLIZZ", GameImage = "wow.png" }
            );
        }
    }
}
