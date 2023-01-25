using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VideoGames_MVC.Models;

namespace VideoGames_MVC.Data
{
    public class VideoGames_MVCContext : DbContext
    {
        public VideoGames_MVCContext (DbContextOptions<VideoGames_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGames_MVC.Models.VideoGames> VideoGames { get; set; }
    }
}
