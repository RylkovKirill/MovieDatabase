using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Core;
using MovieDatabase.Core.Entities.Catalog;
using MovieDatabase.Infrastructure;
using MovieDatabase.Web.Services;

namespace MovieDatabase.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]")]
    public class MovieController : BaseAdminController
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IFileService _fileService;

        public MovieController(IUnitOfWork unit,
                               IWebHostEnvironment environment,
                               IFileService fileService) : base(unit)
        {
            _environment = environment;
            _fileService = fileService;
        }

        [Route("")]
        [Route("[controller]")]
        public IActionResult List()
        {
            return View(Unit.MovieRepository.All());
        }

        //// GET: Admin/Movies/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movies
        //        .Include(m => m.Director)
        //        .Include(m => m.Distributor)
        //        .Include(m => m.Rating)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movie);
        //}

        [HttpGet("[controller]/[action]")]
        public IActionResult Create()
        {
            ViewData["Ratings"] = new SelectList(Unit.RatingRepository.All(), "Id", "Name");
            ViewData["Directors"] = new SelectList(Unit.DirectorRepository.All(), "Id", "FirstName");
            ViewData["Distributors"] = new SelectList(Unit.DistributorRepository.All(), "Id", "Name");

            return View();
        }

        [HttpPost("[controller]/[action]")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                movie.Id = Guid.NewGuid();

                if (file != null)
                {
                    var fileName = movie.Id.ToString() + Path.GetExtension(file.FileName);

                    var path = Path.Combine(_environment.WebRootPath, "Files/Images/Movies", fileName);
                    _fileService.Save(file, path);

                    movie.ImagePath = fileName;
                }

                Unit.MovieRepository.Add(movie);
                Unit.Commit();

                return RedirectToAction(nameof(List));
            }

            ViewData["Ratings"] = new SelectList(Unit.RatingRepository.All(), "Id", "Name");
            ViewData["Directors"] = new SelectList(Unit.DirectorRepository.All(), "Id", "FirstName");
            ViewData["Distributors"] = new SelectList(Unit.DistributorRepository.All(), "Id", "Name");
            return View(movie);
        }

        //// GET: Admin/Movies/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movies.FindAsync(id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "FirstName", movie.DirectorId);
        //    ViewData["DistributorId"] = new SelectList(_context.Distributors, "Id", "Name", movie.DistributorId);
        //    ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Name", movie.RatingId);
        //    return View(movie);
        //}

        //// POST: Admin/Movies/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("Name,Country,Language,Description,ImagePath,Budget,BoxOffice,Runtime,DateOfRelease,RatingId,DirectorId,DistributorId,Id")] Movie movie)
        //{
        //    if (id != movie.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(movie);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MovieExists(movie.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(List));
        //    }
        //    ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "FirstName", movie.DirectorId);
        //    ViewData["DistributorId"] = new SelectList(_context.Distributors, "Id", "Name", movie.DistributorId);
        //    ViewData["RatingId"] = new SelectList(_context.Ratings, "Id", "Name", movie.RatingId);
        //    return View(movie);
        //}

        //// GET: Admin/Movies/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _context.Movies
        //        .Include(m => m.Director)
        //        .Include(m => m.Distributor)
        //        .Include(m => m.Rating)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(movie);
        //}

        //// POST: Admin/Movies/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var movie = await _context.Movies.FindAsync(id);
        //    _context.Movies.Remove(movie);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(List));
        //}

        //private bool MovieExists(Guid id)
        //{
        //    return _context.Movies.Any(e => e.Id == id);
        //}
    }
}
