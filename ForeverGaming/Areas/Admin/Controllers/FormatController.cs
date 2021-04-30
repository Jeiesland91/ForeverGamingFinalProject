using ForeverGaming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForeverGaming.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class FormatController : Controller
    {
        private Repository<Format> data { get; set; }
        public FormatController(GameContext ctx) => data = new Repository<Format>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();


            var formats = data.List(new QueryOptions<Format>
            {
                OrderBy = f => f.Name
            });
            return View(formats);
        }

        [HttpGet]
        public ViewResult Add() => View("Format", new Format());

        [HttpPost]
        public IActionResult Add(Format format, string action)
        {
            string operation = "add";
            var validate = new Validate(TempData);
            if (!validate.IsFormatChecked)
            {
                validate.CheckFormat(format.FormatId, data);
                if (!validate.IsValid)
                {
                    ModelState.AddModelError(nameof(format.FormatId), validate.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                data.Insert(format);
                data.Save();
                validate.ClearFormat();
                TempData["message"] = $"{format.Name} added to Formats.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Format", format);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("Format", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Format format)
        {
            if (ModelState.IsValid)
            {
                data.Update(format);
                data.Save();
                TempData["message"] = $"{format.Name} updated.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Format", format);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var format = data.Get(new QueryOptions<Format>
            {
                Includes = "Games",
                Where = g => g.FormatId == id
            });

            if (format.Games.Count > 0)
            {
                TempData["message"] = $"Can't delete format {format.Name} "
                                    + "because it's associated with these games.";
                return GoToGameSearchResults(id);
            }
            else
            {
                return View("Format", format);
            }
        }

        [HttpPost]
        public IActionResult Delete(Format format)
        {
            data.Delete(format);
            data.Save();
            TempData["message"] = $"{format.Name} removed from Formats.";
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ViewGames(string id) => GoToGameSearchResults(id);

        private RedirectToActionResult GoToGameSearchResults(string id)
        {
            var search = new SearchData(TempData)
            {
                SearchTerm = id,
                Type = "format"
            };
            return RedirectToAction("Search", "Game");
        }

    }
}
