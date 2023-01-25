using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGames_MVC.Models
{
    public class VideoGames
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Age Rating")]
        public int AgeRating { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]  
        public decimal Price { get; set; }
        public bool MultiPlayer { get; set; }
    }
}
