using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideoGames_MVC.Data;
using VideoGames_MVC.Models;

namespace VideoGames_MVC.Controllers
{
    public class VideoGamesScaffoldedController : Controller
    {
        private readonly VideoGames_MVCContext _context;

        public VideoGamesScaffoldedController(VideoGames_MVCContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(string VideoGameGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.VideoGames
                                            orderby m.Genre
                                            select m.Genre;

            var videoGames = from m in _context.VideoGames
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                videoGames = videoGames.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(VideoGameGenre))
            {
                videoGames = videoGames.Where(x => x.Genre == VideoGameGenre);
            }

            var VideoGameGenreVM = new VideoGameGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                VideoGames = await videoGames.ToListAsync()
            };

            return View(VideoGameGenreVM);
        }

       
        // GET: VideoGamesScaffolded/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGames = await _context.VideoGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoGames == null)
            {
                return NotFound();
            }

            return View(videoGames);
        }

        // GET: VideoGamesScaffolded/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoGamesScaffolded/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AgeRating,ReleaseDate,Genre,Price")] VideoGames videoGames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoGames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoGames);
        }

        // GET: VideoGamesScaffolded/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGames = await _context.VideoGames.FindAsync(id);
            if (videoGames == null)
            {
                return NotFound();
            }
            return View(videoGames);
        }

        // POST: VideoGamesScaffolded/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AgeRating,ReleaseDate,Genre,Price")] VideoGames videoGames)
        {
            if (id != videoGames.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoGames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoGamesExists(videoGames.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(videoGames);
        }

        // GET: VideoGamesScaffolded/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGames = await _context.VideoGames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoGames == null)
            {
                return NotFound();
            }

            return View(videoGames);
        }

        // POST: VideoGamesScaffolded/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videoGames = await _context.VideoGames.FindAsync(id);
            _context.VideoGames.Remove(videoGames);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoGamesExists(int id)
        {
            return _context.VideoGames.Any(e => e.Id == id);
        }
    }
}
