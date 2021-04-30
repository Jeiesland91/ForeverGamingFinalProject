using System.Linq;

namespace ForeverGaming.Models
{
    // extends generic QueryOptions<Game> class to add a 
    // SortFilter() method that adds the Sort and Filter
    // code specific to the ForeverGaming application
    public class GameQueryOptions : QueryOptions<Game>
    {
        public void SortFilter(GameGridBuilder builder)
        {
            // filter
            if (builder.IsFilterByGenre)
            {
                Where = g => g.GenreId == builder.CurrentRoute.GenreFilter;
            }
            
            if (builder.IsFilterByType)
            {
                Where = g => g.TypeId == builder.CurrentRoute.TypeFilter;
            }

            if (builder.IsFilterByFormat)
            {
                Where = g => g.FormatId == builder.CurrentRoute.FormatFilter;
            }
            if (builder.IsFilterByRating)
            {
                Where = g => g.RatingId == builder.CurrentRoute.RatingFilter;
            }
            if (builder.IsFilterByPublisher)
            {
                Where = g => g.PublisherId == builder.CurrentRoute.PublisherFilter;
            }

            if (builder.IsSortByGenre)
            {
                OrderBy = g => g.Genre.Name;
            }
            else if (builder.IsSortByType)
            {
                OrderBy = g => g.Type.Name;
            }
            else if (builder.IsSortByFormat)
            {
                OrderBy = g => g.Format.Name;
            }
            else if (builder.IsSortByRating)
            {
                OrderBy = g => g.Rating.Name;
            }
            else if (builder.IsSortByPublisher)
            {
                OrderBy = g => g.Publisher.Name;
            }
            else
            {
                OrderBy = g => g.Name;
            }
        }
    }
}
