using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ForeverGaming.Models
{
    public class Publisher
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a publisher id.")]
        [Remote("CheckPublisher", "Validation", "Admin")]
        public string PublisherId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter a publisher name.")]
        public string Name { get; set; }

        // navigation property
        public ICollection<Game> Games { get; set; }
    }
}
