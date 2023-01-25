using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System;

namespace VideoGames_MVC.Models
{
    public class VideoGames
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public int AgeRating { get; set; }
            [DataType(DataType.Date)]
            public DateTime ReleaseDate { get; set; }
            public string Genre { get; set; }
            public decimal Price { get; set; }
    }
}
