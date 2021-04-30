using Microsoft.AspNetCore.Mvc;
using ForeverGaming.Models;

namespace ForeverGaming.Controllers
{
    public class GameController : Controller
    {
        private GameUnitOfWork data { get; set; }
        public GameController(GameContext ctx) => data = new GameUnitOfWork(ctx);

        public RedirectToActionResult Index() => RedirectToAction("List");

        // dto has properties for the paging, sorting, and filtering route segments defined in the Startup.cs file
        public ViewResult List(GameGridDTO values)
        {
            // get grid builder, which loads route segment values and stores them in session
            var builder = new GameGridBuilder(HttpContext.Session, values,
                defaultSortField: nameof(Game.Name));

            // create a GameQueryOptions object to build a query expression for a page of data
            var options = new GameQueryOptions
            {
                Includes = "Genre, Type, Format, Rating, Publisher",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };

            // call the SortFilter() method of the GameQueryOptions object and pass it the builder
            // object. It uses the route information and the properties of the builder object to 
            // add sort and filter options to the query expression. 
            options.SortFilter(builder);

            // create view model and add page of game data, data for drop-downs, 
            // the current route, and the total number of pages. 
            var vm = new GameListViewModel
            {
                Games = data.Games.List(options),
                Genres = data.Genres.List(new QueryOptions<Genre>
                {
                    OrderBy = g => g.Name
                }),
                Types = data.Types.List(new QueryOptions<Type>
                {
                    OrderBy = t => t.Name
                }),
                Formats = data.Formats.List(new QueryOptions<Format>
                {
                    OrderBy = f => f.Name
                }),
                Ratings = data.Ratings.List(new QueryOptions<Rating>
                {
                    OrderBy = r => r.Name
                }),
                Publishers = data.Publishers.List(new QueryOptions<Publisher>
                {
                    OrderBy = p => p.Name
                }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Games.Count)
            };

            // pass view model to view
            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var game = data.Games.Get(new QueryOptions<Game>
            {
                Includes = "Genre, Type, Format, Rating, Publisher",
                Where = b => b.GameId == id
            });

            return View(game);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            // get current route segments from session
            var builder = new GameGridBuilder(HttpContext.Session);

            // clear or update filter route segment values. 
            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                builder.LoadFilterSegments(filter);
            }


            // save route data back to session and redirect to Game/List action method,
            // passing dictionary of route segment values to build URL
            builder.SaveRouteSegments();

            return RedirectToAction("List", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult PageSize(int pagesize)
        {
            var builder = new GameGridBuilder(HttpContext.Session);

            builder.CurrentRoute.PageSize = pagesize;
            builder.SaveRouteSegments();

            return RedirectToAction("List", builder.CurrentRoute);
        }
    }
}
