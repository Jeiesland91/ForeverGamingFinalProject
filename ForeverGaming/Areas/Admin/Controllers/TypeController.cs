using ForeverGaming.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForeverGaming.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TypeController : Controller
    {
        private Repository<Type> data { get; set; }
        public TypeController(GameContext ctx) => data = new Repository<Type>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var types = data.List(new QueryOptions<Type>
            {
                OrderBy = t => t.Name
            });
            return View(types);
        }

        [HttpGet]
        public ViewResult Add() => View("Type", new Type());

        [HttpPost]
        public IActionResult Add(Type type)
        {
            var validate = new Validate(TempData);
            if (!validate.IsTypeChecked)
            {
                validate.CheckType(type.TypeId, data);
                if (!validate.IsValid)
                {
                    ModelState.AddModelError(nameof(type.TypeId), validate.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                data.Insert(type);
                data.Save();
                validate.ClearType();
                TempData["message"] = $"{type.Name} added to Types.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Type", type);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("Type", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Type type)
        {
            if (ModelState.IsValid)
            {
                data.Update(type);
                data.Save();
                TempData["message"] = $"{type.Name} updated.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Type", type);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var type = data.Get(new QueryOptions<Type>
            {
                Includes = "Games",
                Where = g => g.TypeId == id
            });

            if (type.Games.Count > 0)
            {
                TempData["message"] = $"Can't delete type {type.Name} "
                                    + "because it's associated with these games.";
                return GoToGameSearchResults(id);
            }
            else
            {
                return View("Type", type);
            }
        }

        [HttpPost]
        public IActionResult Delete(Type type)
        {
            data.Delete(type);
            data.Save();
            TempData["message"] = $"{type.Name} removed from Types.";
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ViewGames(string id) => GoToGameSearchResults(id);

        private RedirectToActionResult GoToGameSearchResults(string id)
        {
            var search = new SearchData(TempData)
            {
                SearchTerm = id,
                Type = "type"
            };
            return RedirectToAction("Search", "Game");
        }

    }
}
