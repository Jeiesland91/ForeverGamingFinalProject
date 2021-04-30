using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ForeverGaming.Migrations
{
    public partial class InitialDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    FormatId = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.FormatId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    GenreId = table.Column<string>(nullable: false),
                    TypeId = table.Column<string>(nullable: false),
                    FormatId = table.Column<string>(nullable: false),
                    RatingId = table.Column<string>(nullable: false),
                    PublisherId = table.Column<string>(nullable: false),
                    GameImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Games_Formats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Formats",
                        principalColumn: "FormatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Ratings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Ratings",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Formats",
                columns: new[] { "FormatId", "Name" },
                values: new object[,]
                {
                    { "ARCADE", "Arcade Game" },
                    { "CONSOLE", "Gaming console" },
                    { "MOBILE", "Mobile Device" },
                    { "PC", "Personal Computer" },
                    { "STREAMING", "Streaming" },
                    { "TV", "Television" },
                    { "VIRTUAL", "Virtual Reality" },
                    { "WEB", "Web Browser" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "TFPS", "Tactical First-Person Shooter" },
                    { "SURVH", "Survival Horror" },
                    { "SURV", "Survival " },
                    { "STRG", "Strategy" },
                    { "SIMUL", "Simulation" },
                    { "SPORT", "Sports" },
                    { "RPG", "Role-Playing Game" },
                    { "PUZZLE", "Puzzle" },
                    { "MOBAs", "Mobile Online Battle Area" },
                    { "MMORPG", "Massively Multiplayer Online Role-Playing Game" },
                    { "FPS", "First-Person Shooter" },
                    { "RTS", "Real-Time Strategy" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Name" },
                values: new object[,]
                {
                    { "SEM", "Super Evil Megacorp" },
                    { "ROCK", "RockStar Games" },
                    { "RIOT", "Riot Games" },
                    { "ROGUE", "Rogue Entertainment" },
                    { "REDBAR", "Red Barrels" },
                    { "ORIGIN", "Origin Games" },
                    { "PLAY", "Playground games" },
                    { "NIN", "Nintendo" },
                    { "MOON", "Moonton" },
                    { "SONY", "Sony Interactive Entertainment" },
                    { "PROLET", "Proletariat Inc." },
                    { "SOURCE", "Source" },
                    { "UNREAL", "Unreal" },
                    { "STEAM", "Steam" },
                    { "TMETA", "The Meta" },
                    { "TETSUYA", "Tetsuya Nomura" },
                    { "TREY ", "Treyarch" },
                    { "TRITER", "Triternion " },
                    { "TIMI", "TiMi Studios" },
                    { "UBI", "Ubisoft" },
                    { "UNITY", "Unity" },
                    { "MEDIA", "Mediatonic" },
                    { "VALVE", "Valve" },
                    { "VERANT", "Verant Interactive" },
                    { "STUN", "Stunlock Studios" },
                    { "KINETIC", "Kinetic Games" },
                    { "QSX", "QuickSilverX" },
                    { "HIREZ", "Hi-Rez Studios" },
                    { "343IND", "343 Ind." },
                    { "A4GAMES", "A4 Games" },
                    { "ACT ", "Activision" },
                    { "AFTER", "Afterthought" },
                    { "ASOBO", "Asobo Studio" },
                    { "BLIZZ", "Blizzard Entertainment" },
                    { "BOHEM", "Bohemia Interactive" },
                    { "BETH", "Bethesda Softwarks" },
                    { "BSG", "Battle State Games" },
                    { "CA ", "Creative Assembly" },
                    { "CAPCOM", "Capcom" },
                    { "CDPR", "CD Projekt Red" },
                    { "CREEP", "Creepy Jar" },
                    { "DICE", "DICE" },
                    { "DTG", "Dead Thread Games" },
                    { "EA", "Electronic Arts" },
                    { "EATIB", "EA Tiburon" },
                    { "EAGLE", "Eagle Dynamics" },
                    { "INNER", "InnerSloth" },
                    { "ES", "Ensemble Studios" },
                    { "FRICT", "Frictional Games" },
                    { "FROST", "Frostburn Studios" },
                    { "GGG", "Grinding Gear Games" },
                    { "GARRY", "Garry Newman" },
                    { "GOOGLE", "Google Play" },
                    { "DG", "Daybreak Games" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "Name" },
                values: new object[,]
                {
                    { "E10", "Everyone 10 and older" },
                    { "T", "Teen" },
                    { "E", "Everyone" },
                    { "A", "Adults only 18 and older" },
                    { "M", "Mature 17 and older" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Name" },
                values: new object[,]
                {
                    { "TEXT", "Text" },
                    { "TS", "Team Sports" },
                    { "TRP", "Tactical Role-Play" },
                    { "TFPS", "Tactical FPS" },
                    { "SH", "Survival Horror" },
                    { "SURVIVAL", "Survival" },
                    { "STRATEGY", "Strategy" },
                    { "STEALTH", "Stealth" },
                    { "SPORT", "Sport Games" },
                    { "SIM", "Simulation" },
                    { "SRPG", "Sandbox RPGs" },
                    { "RPG", "Role-Play" },
                    { "RHYTHM", "Rhythm" },
                    { "RTS", "Real Time Strategy" },
                    { "RACING", "Racing" },
                    { "PF", "Platformer" },
                    { "PG", "Party Games" },
                    { "MOBA", "Mobile Online Battle Area" },
                    { "MMORPG", "Massively Multiplayer Online Role-Playing Game" },
                    { "LS", "Life Sim" },
                    { "IM", "Interactive Movie" },
                    { "GS", "Grand Strategy" },
                    { "FPS", "First Person Shooter" },
                    { "FIGHTING", "Fighting" },
                    { "EX", "Exercise" },
                    { "ED", "Educational" },
                    { "CS", "Combat Sports" },
                    { "CB", "City-Building" },
                    { "TD", "Tower Defense" },
                    { "PUZZLE", "Puzzle" },
                    { "TRIVIA", "Trivia" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "FormatId", "GameImage", "GenreId", "Name", "PublisherId", "RatingId", "TypeId" },
                values: new object[,]
                {
                    { 3, "CONSOLE", "mma.png", "SPORT", "EA Sports MMA", "EA", "T", "CS" },
                    { 51, "CONSOLE", "elder.png", "RPG", "The Elder Scrolls", "BETH", "T", "RTS" },
                    { 7, "PC", "F3.png", "RPG", "FarCry 3", "UBI", "M", "RPG" },
                    { 8, "PC", "F4.png", "RPG", "FarCry 4", "UBI", "M", "RPG" },
                    { 16, "PC", "GTA3.png", "RPG", "Grand Theft Auto 3", "ROCK", "A", "RPG" },
                    { 17, "PC", "GTA4.png", "RPG", "Grand Theft Auto 4", "ROCK", "A", "RPG" },
                    { 18, "PC", "GTA5.png", "RPG", "Grand Theft Auto 5", "ROCK", "A", "RPG" },
                    { 40, "PC", "RDR2.png", "RPG", "Red Dead Redemption 2", "ROCK", "M", "RPG" },
                    { 57, "PC", "Valheim.png", "RPG", "Valheim", "UNITY", "E", "RPG" },
                    { 5, "CONSOLE", "everquest.png", "MMORPG", "EverQuest", "VERANT", "T", "SRPG" },
                    { 32, "PC", "Mord.png", "MMORPG", "MORDHAU", "TRITER", "A", "SRPG" },
                    { 53, "PC", "witcher3.png", "RPG", "The Witcher 3: Wild Hunt", "CDPR", "M", "SRPG" },
                    { 62, "PC", "wow.png", "MMORPG", "World of Warcraft", "BLIZZ", "T", "SRPG" },
                    { 30, "PC", "MFS.png", "SIMUL", "Microsoft Flight Simulator", "ASOBO", "E", "SIM" },
                    { 9, "CONSOLE", "fifa20.png", "SPORT", "FIFA 20", "EATIB", "E", "SPORT" },
                    { 28, "CONSOLE", "maddennfl.png", "SPORT", "Madden NFL", "EATIB", "E", "SPORT" },
                    { 33, "CONSOLE", "nbajam.png", "SPORT", "NBA Jam", "EATIB", "E", "SPORT" },
                    { 60, "CONSOLE", "wiisports.png", "SPORT", "Wii Sports", "NIN", "E", "SPORT" },
                    { 6, "PC", "Fguys.png", "STRG", "Fall Guys: Ultimate Knockout", "MEDIA", "T", "STRATEGY" },
                    { 23, "PC", "HD.png", "STRG", "HD Poker", "GOOGLE", "A", "STRATEGY" },
                    { 4, "PC", "EFT.png", "SURVH", "Escape From Tarkov", "BSG", "A", "SH" },
                    { 19, "PC", "GreenH.png", "SURVH", "Green Hell", "CREEP", "M", "SH" },
                    { 34, "PC", "Outlast.png", "SURVH", "Outlast", "REDBAR", "A", "SH" },
                    { 35, "PC", "Outlast2.png", "SURVH", "Outlast 2", "REDBAR", "A", "SH" },
                    { 38, "PC", "Phas.png", "SURVH", "Phasmophobia", "KINETIC", "M", "SH" },
                    { 41, "PC", "RE2.png", "SURVH", "Resident Evil 2", "CAPCOM", "M", "SH" },
                    { 42, "PC", "RE3.png", "SURVH", "Resident Evil 3 Raccoon City", "CAPCOM", "M", "SH" },
                    { 46, "PC", "SOMA.png", "SURVH", "SOMA", "FRICT", "A", "SH" },
                    { 44, "PC", "SOT.png", "RTS", "Sea of Thieves ", "UNREAL", "T", "RTS" },
                    { 29, "PC", "Metro.png", "RTS", "Metro Exodus", "A4GAMES", "M", "RTS" },
                    { 15, "CONSOLE", "granturismo.png", "SPORT", "Gran Turismo Sport", "SONY", "E", "RACING" },
                    { 13, "CONSOLE", "forza.png", "SPORT", "Forza Horizon 4", "PLAY", "E", "RACING" },
                    { 10, "CONSOLE", "fightnightchampion.png", "SPORT", "Fight Night Champion", "EA", "M", "CS" },
                    { 11, "CONSOLE", "fightnight.png", "SPORT", "Fight Night Round 4", "EA", "T", "CS" },
                    { 55, "CONSOLE", "upc.png", "SPORT", "UPC 2009 Undisputed", "EA", "T", "CS" },
                    { 12, "PC", "FF.png", "RPG", "Final Fantasy XV", "TETSUYA", "T", "FIGHTING" },
                    { 1, "PC", "doom.png", "FPS", "Doom", "BETH", "M", "FPS" },
                    { 20, "PC", "H3.png", "FPS", "HALO 3", "343IND", "T", "FPS" },
                    { 21, "PC", "H4.png", "FPS", "HALO 4", "343IND", "T", "FPS" },
                    { 22, "PC", "Hreach.png", "FPS", "HALO Reach", "343IND", "T", "FPS" },
                    { 36, "PC", "overwatch.png", "FPS", "Overwatch", "BLIZZ", "T", "FPS" },
                    { 39, "PC", "PUBG.png", "FPS", "PUBG PlayersUnknown BattleGround", "DG", "A", "FPS" },
                    { 43, "PC", "ROE.png", "FPS", "Ring of Elysium", "QSX", "A", "FPS" },
                    { 48, "PC", "starcraft.png", "RTS", "StarCraft", "BLIZZ", "T", "FPS" },
                    { 54, "PC", "R6S.png", "FPS", "TOM CLANCY'S Rainbow Six Siege", "UBI", "M", "FPS" },
                    { 52, "PC", "Isle.png", "SURVH", "The ISLE", "AFTER", "M", "SH" },
                    { 58, "PC", "Val.png", "FPS", "Valorant", "RIOT", "M", "FPS" },
                    { 2, "PC", "dota2.png", "MOBAs", "DOTA 2", "VALVE", "E10", "MOBA" },
                    { 24, "PC", "heroesofnewerth.png", "MOBAs", "Heroes of Newerth", "FROST", "T", "MOBA" },
                    { 25, "PC", "heroes.png", "MOBAs", "Heroes of the Storm", "BOHEM", "T", "MOBA" },
                    { 27, "PC", "league.png", "MOBAs", "League of Legends", "RIOT", "E10", "MOBA" },
                    { 31, "MOBILE", "mobile.png", "MOBAs", "Mobile Legends", "MOON", "T", "MOBA" },
                    { 37, "PC", "POE.png", "MOBAs", "Path Of Exile", "GGG", "T", "MOBA" },
                    { 45, "CONSOLE", "smite.png", "MOBAs", "Smite", "HIREZ", "T", "MOBA" },
                    { 47, "PC", "Spellbreak.png", "MOBAs", "Spellbreak", "PROLET", "E", "MOBA" },
                    { 49, "PC", "starcraftlegacy.png", "MOBAs", "StarCraft: Legacy of the Void", "BLIZZ", "T", "MOBA" },
                    { 50, "PC", "strife.png", "MOBAs", "Strife", "ROGUE", "M", "MOBA" },
                    { 56, "MOBILE", "vain.png", "MOBAs", "Vainglory", "SEM", "T", "MOBA" },
                    { 14, "PC", "Gmod.png", "PUZZLE", "Garry's Mod", "GARRY", "E", "PUZZLE" },
                    { 59, "PC", "WWB.png", "PUZZLE", "We Went Back", "DTG", "A", "PUZZLE" },
                    { 61, "CONSOLE", "wolfenstein.png", "FPS", "Wolfenstein: The New Order", "BETH", "A", "FPS" },
                    { 26, "PC", "Kovaak.png", "TFPS", "Kovaak 2.0", "TMETA", "T", "TFPS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Games_FormatId",
                table: "Games",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_RatingId",
                table: "Games",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TypeId",
                table: "Games",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
