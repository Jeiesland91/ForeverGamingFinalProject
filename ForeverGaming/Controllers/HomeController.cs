using Microsoft.AspNetCore.Mvc;
using System;
using ForeverGaming.Models;

namespace ForeverGaming.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Game> data { get; set; }
        public HomeController(GameContext ctx) => data = new Repository<Game>(ctx);

        public ViewResult Index()
        {
            // Gets a random game to display on the screen
            var random = data.Get(new QueryOptions<Game>
            {
                OrderBy = b => Guid.NewGuid()
            });

            return View(random);
        }
    }
}
