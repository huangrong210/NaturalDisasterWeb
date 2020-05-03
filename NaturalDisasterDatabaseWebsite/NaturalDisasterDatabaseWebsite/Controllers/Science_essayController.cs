using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaturalDisasterDatabaseWebsite.Models;

namespace NaturalDisasterDatabaseWebsite.Controllers
{
    [Authorize(Roles = "管理员")]
    public class Science_essayController : Controller
    {
        private readonly NaturalDisasterDatabaseWebsiteContext _context;

        public Science_essayController(NaturalDisasterDatabaseWebsiteContext context)
        {
            _context = context;
        }

        // GET: Science_essay
        public async Task<IActionResult> Index(string searchString)
        {
            //添加搜索（文章管理）
            ViewData["CurrentFilter"] = searchString;
            var query_essay = from e in _context.Science_essay select e; //LINQ查询
            query_essay = _context.Science_essay.Include(s => s.user);
            if (!String.IsNullOrEmpty(searchString))
            {
                //Lambsa表达式
                query_essay = query_essay.Where(s => s.user.username.Contains(searchString)
                                                || s.title.Contains(searchString)
                                                || s.author.Contains(searchString)
                                                || s.source.Contains(searchString)
                                                || s.fb_time.ToString().Contains(searchString)
                                                || s.wz_content.Contains(searchString)
                                                //|| s.wz_img.Contains(searchString)
                                                || s.wz_style.Contains(searchString)
                                                || s.state.Contains(searchString));
            }
            return View(await query_essay.ToListAsync());

            //用于显示数据库中的所有文章
            //var naturalDisasterDatabaseWebsiteContext = _context.Science_essay.Include(s => s.user);
            //return View(await naturalDisasterDatabaseWebsiteContext.ToListAsync());
        }

        // GET: Science_essay/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            var science_essayViewModel = await _context.Science_essay
                .Include(s => s.user)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (science_essayViewModel == null)
            {
                return NotFound();
            }

            return View(science_essayViewModel);
        }

        // GET: Science_essay/Create
        public IActionResult Create()
        {
            ViewData["userID"] = new SelectList(_context.users, "ID", "username");
            return View();
        }

        // POST: Science_essay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("title,author,source,fb_time,wz_content,wz_style,state,userID")] Science_essayViewModel science_essayViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(science_essayViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["userID"] = new SelectList(_context.users, "ID", "username", science_essayViewModel.userID);
            return View(science_essayViewModel);
        }

        // GET: Science_essay/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var science_essayViewModel = await _context.Science_essay.FindAsync(id);
            if (science_essayViewModel == null)
            {
                return NotFound();
            }
            ViewData["userID"] = new SelectList(_context.users, "ID", "username", science_essayViewModel.userID);
            ViewData["wz_style"] = new SelectList(_context.Science_essay, "ID", "wz_style", science_essayViewModel.wz_style);
            return View(science_essayViewModel);
        }

        // POST: Science_essay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,title,author,source,fb_time,wz_content,wz_style,state,userID")] Science_essayViewModel science_essayViewModel)
        {
            if (id != science_essayViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(science_essayViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Science_essayViewModelExists(science_essayViewModel.ID))
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
            ViewData["userID"] = new SelectList(_context.users, "ID", "username", science_essayViewModel.userID);
            ViewData["wz_style"] = new SelectList(_context.Science_essay, "ID", "wz_style", science_essayViewModel.wz_style);
            return View(science_essayViewModel);
        }

        // GET: Science_essay/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var science_essayViewModel = await _context.Science_essay
                .Include(s => s.user)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (science_essayViewModel == null)
            {
                return NotFound();
            }

            return View(science_essayViewModel);
        }

        // POST: Science_essay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var science_essayViewModel = await _context.Science_essay.FindAsync(id);
            _context.Science_essay.Remove(science_essayViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Science_essayViewModelExists(int id)
        {
            return _context.Science_essay.Any(e => e.ID == id);
        }
    }
}
