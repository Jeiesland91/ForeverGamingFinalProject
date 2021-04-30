using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForeverGaming.Models;
using Microsoft.AspNetCore.Authorization;

namespace ForeverGaming.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PublisherController : Controller
    {
        private Repository<Publisher> data { get; set; }
        public PublisherController(GameContext ctx) => data = new Repository<Publisher>(ctx);

        public ViewResult Index()
        {
            var search = new SearchData(TempData);
            search.Clear();

            var publishers = data.List(new QueryOptions<Publisher>
            {
                OrderBy = f => f.Name
            });
            return View(publishers);
        }

        [HttpGet]
        public ViewResult Add() => View("Publisher", new Publisher());

        [HttpPost]
        public IActionResult Add(Publisher publisher)
        {
            var validate = new Validate(TempData);
            if (!validate.IsPublisherChecked)
            {
                validate.CheckPublisher(publisher.PublisherId, data);
                if (!validate.IsValid)
                {
                    ModelState.AddModelError(nameof(publisher.PublisherId), validate.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                data.Insert(publisher);
                data.Save();
                validate.ClearPublisher();
                TempData["message"] = $"{publisher.Name} added to Publishers.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Publisher", publisher);
            }
        }

        [HttpGet]
        public ViewResult Edit(string id) => View("Publisher", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                data.Update(publisher);
                data.Save();
                TempData["message"] = $"{publisher.Name} updated.";
                return RedirectToAction("Index");
            }
            else
            {
                return View("Publisher", publisher);
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var publisher = data.Get(new QueryOptions<Publisher>
            {
                Includes = "Games",
                Where = g => g.PublisherId == id
            });

            if (publisher.Games.Count > 0)
            {
                TempData["message"] = $"Can't delete publisher {publisher.Name} "
                                    + "because it's associated with these games.";
                return GoToGameSearchResults(id);
            }
            else
            {
                return View("Publisher", publisher);
            }
        }

        [HttpPost]
        public IActionResult Delete(Publisher publisher)
        {
            data.Delete(publisher);
            data.Save();
            TempData["message"] = $"{publisher.Name} removed from Publishers.";
            return RedirectToAction("Index");
        }

        public RedirectToActionResult ViewGames(string id) => GoToGameSearchResults(id);

        private RedirectToActionResult GoToGameSearchResults(string id)
        {
            var search = new SearchData(TempData)
            {
                SearchTerm = id,
                Type = "publisher"
            };
            return RedirectToAction("Search", "Game");
        }
    }
}
