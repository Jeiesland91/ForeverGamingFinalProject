using System.Collections.Generic;

namespace ForeverGaming.Models
{
    public class GameListViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Type> Types { get; set; }
        public IEnumerable<Format> Formats { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }

        // data for pagesize drop-down - hardcoded
        public int[] PageSizes => new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}
