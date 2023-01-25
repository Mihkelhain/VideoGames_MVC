using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace VideoGames_MVC.Models
{
    public class VideoGameGenreViewModel
    {
            public List<VideoGames> VideoGames { get; set; }
            public SelectList Genres { get; set; }
            public string VideoGameGenre { get; set; }
            public string SearchString { get; set; }
        
    }
}
