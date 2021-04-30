using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ForeverGaming.Models
{
    public class Type
    {
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a type id.")]
        [Remote("CheckType", "Validation", "Admin")]
        public string TypeId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Please enter a type name.")]
        public string Name { get; set; }

        // navigation property
        public ICollection<Game> Games { get; set; }
    }
}
