using Microsoft.AspNetCore.Mvc;
using ForeverGaming.Models;
using Microsoft.AspNetCore.Authorization;

namespace ForeverGaming.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RatingController : Controller
    {
        private Repository<Rating> data { get; set; }
        public RatingController(GameContext ctx) => data = new Repository<Rating>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var ratings = data.List(new QueryOptions<Rating>
            {
                OrderBy = r => r.Name
            });
            return View(ratings);
        }

        [HttpGet]
        public ViewResult Add() => View("Rating", new Rating());

        [HttpPost]
        public IActionResult Add(Rating rating)
        {
            var validate = new Validate(TempData);
            if (!validate.IsRatingChecked)
            {
                validate.CheckRating(rating.RatingId, data);
                if (!validate.IsValid)
                {
                    ModelState.AddModelError(nameof(rating.RatingId), validate.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                data.Insert(rating);
                data.Save();
                validate.ClearRating();
                TempData["message"] = $"{rating.Name} added to Ratings.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Rating", rating);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("Rating", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Rating rating)
        {
            if (ModelState.IsValid)
            {
                data.Update(rating);
                data.Save();
                TempData["message"] = $"{rating.Name} updated.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Rating", rating);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var rating = data.Get(new QueryOptions<Rating>
            {
                Includes = "Games",
                Where = g => g.RatingId == id
            });

            if (rating.Games.Count > 0)
            {
                TempData["message"] = $"Can't delete rating {rating.Name} "
                                    + "because it's associated with these games.";
                return GoToGameSearchResults(id);
            }
            else
            {
                return View("Rating", rating);
            }
        }

        [HttpPost]
        public IActionResult Delete(Rating rating)
        {
            data.Delete(rating);
            data.Save();
            TempData["message"] = $"{rating.Name} removed from Ratings.";
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ViewGames(string id) => GoToGameSearchResults(id);

        private RedirectToActionResult GoToGameSearchResults(string id)
        {
            var search = new SearchData(TempData)
            {
                SearchTerm = id,
                Type = "rating"
            };
            return RedirectToAction("Search", "Game");
        }
    }
}
