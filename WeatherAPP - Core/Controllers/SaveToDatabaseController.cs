using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherAPP___Core.Data;
using WeatherAPP___Core.Models;

namespace WeatherAPP___Core.Controllers
{
    public class SaveToDatabaseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaveToDatabaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaveToDatabase
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.mains.Include(m => m.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SaveToDatabase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.mains
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // GET: SaveToDatabase/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: SaveToDatabase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temperature,Pressure,Humidity,TempMin,TempMax,Percepita,UserId")] Main main)
        {
            if (ModelState.IsValid)
            {
                _context.Add(main);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", main.UserId);
            return View(main);
        }

        // GET: SaveToDatabase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.mains.FindAsync(id);
            if (main == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", main.UserId);
            return View(main);
        }

        // POST: SaveToDatabase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temperature,Pressure,Humidity,TempMin,TempMax,Percepita,UserId")] Main main)
        {
            if (id != main.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(main);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainExists(main.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", main.UserId);
            return View(main);
        }

        // GET: SaveToDatabase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.mains
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // POST: SaveToDatabase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var main = await _context.mains.FindAsync(id);
            _context.mains.Remove(main);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainExists(int id)
        {
            return _context.mains.Any(e => e.Id == id);
        }
    }
}
