using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ForeverGaming.Models
{
    public class Genre
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a genre id.")]
        [Remote("CheckGenre", "Validation", "Admin")]
        public string GenreId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter a genre name.")]
        public string Name { get; set; }

        // navigation property
        public ICollection<Game> Games { get; set; }
    }
}
