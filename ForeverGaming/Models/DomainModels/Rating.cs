using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ForeverGaming.Models
{
    public class Rating
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a rating id.")]
        [Remote("CheckRating", "Validation", "Admin")]
        public string RatingId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter a rating name.")]
        public string Name { get; set; }

        // navigation property
        public ICollection<Game> Games { get; set; }
    }
}
