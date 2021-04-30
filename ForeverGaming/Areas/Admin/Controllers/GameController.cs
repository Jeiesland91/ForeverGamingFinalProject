using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ForeverGaming.Models;

namespace ForeverGaming.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class GameController : Controller
    {
        private GameUnitOfWork data { get; set; }
        public GameController(GameContext ctx) => data = new GameUnitOfWork(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var search = new SearchData(TempData)
                {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ViewResult Search()
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm)
            {
                var vm = new SearchViewModel
                {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Game>
                {
                    Includes = "Genre, Type, Format, Rating, Publisher"
                };
                if (search.IsGame)
                {
                    options.Where = g => g.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for game: '{vm.SearchTerm}'";
                }
                if (search.IsGenre)
                {
                    options.Where = g => g.Genre.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for genre: '{vm.SearchTerm}'";
                }
                if (search.IsType)
                {
                    options.Where = g => g.Type.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for type: '{vm.SearchTerm}'";
                }
                if (search.IsFormat)
                {
                    options.Where = g => g.Format.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for format: '{vm.SearchTerm}'";
                }
                if (search.IsRating)
                {
                    options.Where = g => g.Rating.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for rating: '{vm.SearchTerm}'";
                }
                if (search.IsPublisher)
                {
                    options.Where = g => g.Publisher.Name.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for publisher: '{vm.SearchTerm}'";
                }
                vm.Games = data.Games.List(options);
                return View("SearchResults", vm);
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        public ViewResult Add(int id) => GetGame(id, "Add");

        [HttpPost]
        public IActionResult Add(GameViewModel vm)
        {
            if (ModelState.IsValid)
            {
                data.Games.Insert(vm.Game);
                data.Save();
                TempData["message"] = $"{vm.Game.Name} added to Games.";
                return RedirectToAction("Index");
            }
            else
            {
                Load(vm, "Add");
                return View("Game", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetGame(id, "Edit");

        [HttpPost]
        public IActionResult Edit(GameViewModel vm)
        {
            if (ModelState.IsValid)
            {
                data.Games.Update(vm.Game);
                data.Save();

                TempData["message"] = $"{vm.Game.Name} updated.";
                return RedirectToAction("Search");
            }
            else
            {
                Load(vm, "Edit");
                return View("Game", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetGame(id, "Delete");

        [HttpPost]
        public IActionResult Delete(GameViewModel vm)
        {
            data.Games.Delete(vm.Game);
            data.Save();
            TempData["message"] = $"{vm.Game.Name} removed from Games.";
            return RedirectToAction("Search");
        }

        private ViewResult GetGame(int id, string operation)
        {
            var game = new GameViewModel();
            Load(game, operation, id);
            return View("Game", game);
        }
        private void Load(GameViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op))
            {
                vm.Game = new Game();
            }
            else
            {
                vm.Game = data.Games.Get(new QueryOptions<Game>
                {
                    Includes = "Genre, Type, Format, Rating, Publisher",
                    Where = g => g.GameId == (id ?? vm.Game.GameId)
                });
            }

           
            
            vm.Genres = data.Genres.List(new QueryOptions<Genre>
            {
                OrderBy = g => g.Name
            });
            vm.Types = data.Types.List(new QueryOptions<Type>
            {
                OrderBy = g => g.Name
            });
            vm.Formats = data.Formats.List(new QueryOptions<Format>
            {
                OrderBy = f => f.Name
            });
            vm.Ratings = data.Ratings.List(new QueryOptions<Rating>
            {
                OrderBy = r => r.Name
            });
            vm.Publishers = data.Publishers.List(new QueryOptions<Publisher>
            {
                OrderBy = p => p.Name
            });
        }

    }
}
