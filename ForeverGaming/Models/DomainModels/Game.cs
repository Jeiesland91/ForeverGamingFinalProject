using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ForeverGaming.Models
{
    public partial class Game
    {
        public int GameId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [StringLength(200)]
        public string Name { get; set; }

        // foreign key property
        [Required(ErrorMessage = "Please select a genre.")]
        public string GenreId { get; set; }
        // navigation properties
        public Genre Genre { get; set; }

        // foreign key property
        [Required(ErrorMessage = "Please select a type.")]
        public string TypeId { get; set; }
        // navigation properties
        public Type Type { get; set; }


        // foreign key property
        [Required(ErrorMessage = "Please select a format.")]
        public string FormatId { get; set; }
        // navigation properties
        public Format Format { get; set; }

        // foreign key property
        [Required(ErrorMessage = "Please select a rating.")]
        public string RatingId { get; set; }
        // navigation properties
        public Rating Rating { get; set; }

        // foreign key property
        [Required(ErrorMessage = "Please select a publisher.")]
        public string PublisherId { get; set; }
        // navigation properties
        public Publisher Publisher { get; set; }

        public string GameImage { get; set; }
    }
}
