using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TGL_Homework6.Data;
using TGL_Homework6.Models;

namespace TGL_Homework6.Controllers;

public class PuppiesController : Controller
{
	private readonly PuppyEFContext _context;

	public PuppiesController(PuppyEFContext context)
	{
		_context = context;
	}

	// GET: Puppies
	public async Task<IActionResult> Index()
	{
		var puppyEFContext = _context.Puppies.Include(p => p.Breed);
		return View(await _context.Puppies.ToListAsync());
	}

	// GET: Puppies/Details/5
	public async Task<IActionResult> Details(string id)
	{
		if (id == null || _context.Puppies == null) return NotFound();

		var puppy = await _context.Puppies
			.Include(p => p.Breed)
			.FirstOrDefaultAsync(m => m.PuppyId == id);
		if (puppy == null) return NotFound();

		return View(puppy);
	}

	// GET: Puppies/Create
	public IActionResult Create()
	{
		ViewData["Breed_Id"] = new SelectList(_context.Breeds, "Breed_Id", "Name");
		return View();
	}

	// POST: Puppies/Create
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("PuppyId,Name,Breed_Id,Owner")] Puppy puppy)
	{
		if (ModelState.IsValid)
		{
			_context.Add(puppy);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		ViewData["Breed_Id"] = new SelectList(_context.Breeds, "Breed_Id", "Name", puppy.Breed_Id);
		return View(puppy);
	}

	// GET: Puppies/Edit/5
	public async Task<IActionResult> Edit(string id)
	{
		if (id == null || _context.Puppies == null) return NotFound();

		var puppy = await _context.Puppies.FindAsync(id);
		if (puppy == null) return NotFound();
		ViewData["Breed_Id"] = new SelectList(_context.Breeds, "Breed_Id", "Name", puppy.Breed_Id);
		return View(puppy);
	}

	// POST: Puppies/Edit/5
	// To protect from overposting attacks, enable the specific properties you want to bind to.
	// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(string id, [Bind("PuppyId,Name,Breed_Id,Owner")] Puppy puppy)
	{
		if (id != puppy.PuppyId) return NotFound();

		if (ModelState.IsValid)
		{
			try
			{
				_context.Update(puppy);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PuppyExists(puppy.PuppyId))
					return NotFound();
				else
					throw;
			}

			return RedirectToAction(nameof(Index));
		}

		ViewData["Breed_Id"] = new SelectList(_context.Breeds, "Breed_Id", "Name", puppy.Breed_Id);
		return View(puppy);
	}

	// GET: Puppies/Delete/5
	public async Task<IActionResult> Delete(string id)
	{
		if (id == null || _context.Puppies == null) return NotFound();

		var puppy = await _context.Puppies
			.Include(p => p.Breed)
			.FirstOrDefaultAsync(m => m.PuppyId == id);
		if (puppy == null) return NotFound();

		return View(puppy);
	}

	// POST: Puppies/Delete/5
	[HttpPost]
	[ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(string id)
	{
		if (_context.Puppies == null) return Problem("Entity set 'PuppyEFContext.Puppies'  is null.");
		var puppy = await _context.Puppies.FindAsync(id);
		if (puppy != null) _context.Puppies.Remove(puppy);

		await _context.SaveChangesAsync();
		return RedirectToAction(nameof(Index));
	}

	private bool PuppyExists(string id)
	{
		return (_context.Puppies?.Any(e => e.PuppyId == id)).GetValueOrDefault();
	}
}