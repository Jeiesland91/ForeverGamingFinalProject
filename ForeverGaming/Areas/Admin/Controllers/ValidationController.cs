using ForeverGaming.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForeverGaming.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ValidationController : Controller
    {
        private Repository<Genre> genreData { get; set; }
        private Repository<Type> typeData { get; set; }
        private Repository<Format> formatData { get; set; }
        private Repository<Rating> ratingData { get; set; }
        private Repository<Publisher> publisherData { get; set; }

        public ValidationController(GameContext ctx)
        {
            genreData = new Repository<Genre>(ctx);
            typeData = new Repository<Type>(ctx);
            formatData = new Repository<Format>(ctx);
            ratingData = new Repository<Rating>(ctx);
            publisherData = new Repository<Publisher>(ctx);
        }

        public JsonResult CheckGenre(string genreId)
        {
            var validate = new Validate(TempData);
            validate.CheckGenre(genreId, genreData);
            if (validate.IsValid)
            {
                validate.MarkGenreChecked();
                return Json(true);
            }
            else
            {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckType(string typeId)
        {
            var validate = new Validate(TempData);
            validate.CheckType(typeId, typeData);
            if (validate.IsValid)
            {
                validate.MarkTypeChecked();
                return Json(true);
            }
            else
            {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckFormat(string formatId)
        {
            var validate = new Validate(TempData);
            validate.CheckFormat(formatId, formatData);
            if (validate.IsValid)
            {
                validate.MarkFormatChecked();
                return Json(true);
            }
            else
            {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckRating(string ratingId)
        {
            var validate = new Validate(TempData);
            validate.CheckRating(ratingId, ratingData);
            if (validate.IsValid)
            {
                validate.MarkRatingChecked();
                return Json(true);
            }
            else
            {
                return Json(validate.ErrorMessage);
            }
        }

        public JsonResult CheckPublisher(string publisherId)
        {
            var validate = new Validate(TempData);
            validate.CheckPublisher(publisherId, publisherData);
            if (validate.IsValid)
            {
                validate.MarkPublisherChecked();
                return Json(true);
            }
            else
            {
                return Json(validate.ErrorMessage);
            }
        }
    }
}
