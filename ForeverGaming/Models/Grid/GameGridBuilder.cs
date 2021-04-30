
using Microsoft.AspNetCore.Http;

namespace ForeverGaming.Models
{
    // inherits the general purpose GridBuilder class and adds application-specific 
    // methods for loading and clearing filter route segments in route dictionary.
    // Also adds application-specific Boolean flags for sorting and filtering. 
    public class GameGridBuilder : GridBuilder
    {
        // this constructor gets current route data from session
        public GameGridBuilder(ISession sess) : base(sess) { }

        // this constructor stores filtering route segments, as well as
        // the paging and sorting route segments stored by the base constructor
        public GameGridBuilder(ISession sess, GameGridDTO values,
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            // store filter route segments - add filter prefixes if this is initial load
            // of page with default values rather than route values (route values have prefix)
            bool isInitial = values.Genre.IndexOf(FilterPrefix.Genre) == -1;

            routes.GenreFilter = (isInitial) ? FilterPrefix.Genre + values.Genre : values.Genre; 
            routes.TypeFilter = (isInitial) ? FilterPrefix.Type + values.Type : values.Type;
            routes.FormatFilter = (isInitial) ? FilterPrefix.Format + values.Format : values.Format;
            routes.RatingFilter = (isInitial) ? FilterPrefix.Rating + values.Rating : values.Rating;
            routes.PublisherFilter = (isInitial) ? FilterPrefix.Publisher + values.Publisher : values.Publisher;
        }

        // load new filter route segments contained in a string array - add filter prefix 
        // to each one. 
        public void LoadFilterSegments(string[] filter)
        {
            routes.GenreFilter = FilterPrefix.Genre + filter[0];
            routes.TypeFilter = FilterPrefix.Type + filter[1];
            routes.FormatFilter = FilterPrefix.Format + filter[2];
            routes.RatingFilter = FilterPrefix.Rating + filter[3];
            routes.PublisherFilter = FilterPrefix.Publisher + filter[4];
        }

        public void ClearFilterSegments() => routes.ClearFilters();

        //~~ filter flags ~~//
        string def = GameGridDTO.DefaultFilter;
        public bool IsFilterByGenre => routes.GenreFilter != def;
        public bool IsFilterByType => routes.TypeFilter != def;
        public bool IsFilterByFormat => routes.FormatFilter != def;
        public bool IsFilterByRating => routes.RatingFilter != def;
        public bool IsFilterByPublisher => routes.PublisherFilter != def;

        //~~ sort flags ~~//
        public bool IsSortByGenre =>
            routes.SortField.EqualsNoCase(nameof(Genre));
        public bool IsSortByType =>
            routes.SortField.EqualsNoCase(nameof(Type));
        public bool IsSortByFormat =>
            routes.SortField.EqualsNoCase(nameof(Format));
        public bool IsSortByRating =>
            routes.SortField.EqualsNoCase(nameof(Rating));
        public bool IsSortByPublisher =>
            routes.SortField.EqualsNoCase(nameof(Publisher));

    }
}
