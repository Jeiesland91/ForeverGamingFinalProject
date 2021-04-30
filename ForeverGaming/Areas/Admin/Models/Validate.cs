using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ForeverGaming.Models
{
    public class Validate
    {
        private const string GenreKey = "validGenre";
        private const string FormatKey = "validFormat";
        private const string TypeKey = "validType";
        private const string RatingKey = "validRating";
        private const string PublisherKey = "validPublisher";

        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }
        
        public void CheckGenre(string genreId, Repository<Genre> data)
        {
            Genre entity = null; // only check database on add
            entity = data.Get(new QueryOptions<Genre>
            {
                Where = g => g.GenreId == genreId
            });
       
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"Genre {entity.Name} is already in the database.";
        }

        public void MarkGenreChecked() => tempData[GenreKey] = true;
        public void ClearGenre() => tempData.Remove(GenreKey);
        public bool IsGenreChecked => tempData.Keys.Contains(GenreKey);

        public void CheckType(string typeId, Repository<Type> data)
        {
            Type entity = null; // only check database on add
            entity = data.Get(new QueryOptions<Type>
            {
                Where = t => t.TypeId == typeId
            });

            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : $"Type {entity.Name} is already in the database.";
        }

        public void MarkTypeChecked() => tempData[TypeKey] = true;
        public void ClearType() => tempData.Remove(TypeKey);
        public bool IsTypeChecked => tempData.Keys.Contains(TypeKey);

        public void CheckFormat(string formatId, Repository<Format> data)
        {
            Format entity = null; // only check database on add
            entity = data.Get(new QueryOptions<Format>
            {
                Where = f => f.FormatId == formatId
            });

            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : $"Format {entity.Name} is already in the database.";
        }

        public void MarkFormatChecked() => tempData[FormatKey] = true;
        public void ClearFormat() => tempData.Remove(FormatKey);
        public bool IsFormatChecked => tempData.Keys.Contains(FormatKey);

        public void CheckRating(string ratingId, Repository<Rating> data)
        {
            Rating entity = null; // only check database on add
            entity = data.Get(new QueryOptions<Rating>
            {
                Where = r => r.RatingId == ratingId
            });

            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : $"Rating {entity.Name} is already in the database.";
        }

        public void MarkRatingChecked() => tempData[RatingKey] = true;
        public void ClearRating() => tempData.Remove(RatingKey);
        public bool IsRatingChecked => tempData.Keys.Contains(RatingKey);

        public void CheckPublisher(string publisherId, Repository<Publisher> data)
        {
            Publisher entity = null; // only check database on add
            entity = data.Get(new QueryOptions<Publisher>
            {
                Where = p => p.PublisherId == publisherId
            });
            
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"Publisher {entity.Name} is already in the database.";
        }
        public void MarkPublisherChecked() => tempData[PublisherKey] = true;
        public void ClearPublisher() => tempData.Remove(PublisherKey);
        public bool IsPublisherChecked => tempData.Keys.Contains(PublisherKey);
    }
}
