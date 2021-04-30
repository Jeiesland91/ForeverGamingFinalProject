using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ForeverGaming.Models
{
    public class GameViewModel
    {
        public Game Game { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Format> Formats { get; set; }
        public IEnumerable<Type> Types { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
        public IEnumerable<Publisher> Publishers { get; set; }
        public int[] SelectedTypes { get; set; }
    }
}
