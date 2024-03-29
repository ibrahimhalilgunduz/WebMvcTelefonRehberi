﻿//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;
//using System.Threading.Tasks;
//using WebMvcTelefonRehberi.Domain;

//namespace WebMvcTelefonRehberi.Controllers
//{
//    public class KisisController : Controller
//    {
//        private readonly BaseeDbContext _context;

//        public KisisController(BaseeDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Kisis
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Kisiler.ToListAsync());
//        }

//        // GET: Kisis/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var kisi = await _context.Kisiler
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (kisi == null)
//            {
//                return NotFound();
//            }

//            return View(kisi);
//        }

//        // GET: Kisis/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Kisis/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Adi,Soyadi,Email,Gsm,Id,CreateDate")] Kisi kisi)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(kisi);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(kisi);
//        }

//        // GET: Kisis/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var kisi = await _context.Kisiler.FindAsync(id);
//            if (kisi == null)
//            {
//                return NotFound();
//            }
//            return View(kisi);
//        }

//        // POST: Kisis/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Adi,Soyadi,Email,Gsm,Id,CreateDate")] Kisi kisi)
//        {
//            if (id != kisi.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(kisi);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!KisiExists(kisi.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(kisi);
//        }

//        // GET: Kisis/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var kisi = await _context.Kisiler
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (kisi == null)
//            {
//                return NotFound();
//            }

//            return View(kisi);
//        }

//        // POST: Kisis/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var kisi = await _context.Kisiler.FindAsync(id);
//            _context.Kisiler.Remove(kisi);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool KisiExists(int id)
//        {
//            return _context.Kisiler.Any(e => e.Id == id);
//        }
//    }
//}
