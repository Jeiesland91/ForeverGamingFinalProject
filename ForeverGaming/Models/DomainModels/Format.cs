using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ForeverGaming.Models
{
    public class Format
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a format id.")]
        [Remote("CheckFormat", "Validation", "Admin")]
        public string FormatId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter a format name.")]
        public string Name { get; set; }

        // navigation property
        public ICollection<Game> Games { get; set; }
    }
}
