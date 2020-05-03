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
    [Authorize(Roles ="管理员")]  //需要用户登录才能访问
    public class Forum_msgController : Controller
    {
        private readonly NaturalDisasterDatabaseWebsiteContext _context;

        public Forum_msgController(NaturalDisasterDatabaseWebsiteContext context)
        {
            _context = context;
        }

        // GET: Forum_msg
        //[AllowAnonymous]  //取消保护，允许访问
        public async Task<IActionResult> Index(string searchString)
        {
            //添加搜索（论坛管理）
            ViewData["CurrentFilter"] = searchString;
            var query_msg = from m in _context.Forum_msg select m; //LINQ查询

            query_msg = _context.Forum_msg
                        .Include(f => f.essay)
                        .Include(f => f.user);

            if (!String.IsNullOrEmpty(searchString))
            {
                //Lambsa表达式
                query_msg = query_msg.Where(s => s.comment.Contains(searchString)
                                                || s.comment_time.ToString().Contains(searchString)
                                                || s.user.username.Contains(searchString)
                                                || s.essay.title.Contains(searchString));
            }
                return View(await query_msg.ToListAsync());
            
            //用于显示数据库中的所有留言
            //var naturalDisasterDatabaseWebsiteContext = _context.Forum_msg
            //                                            .Include(f => f.essay)
            //                                            .Include(f => f.user);
            //return View(await naturalDisasterDatabaseWebsiteContext.ToListAsync());
        }

        // GET: Forum_msg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum_msgViewModel = await _context.Forum_msg
                .Include(f => f.essay)
                .Include(f => f.user)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (forum_msgViewModel == null)
            {
                return NotFound();
            }

            return View(forum_msgViewModel);
        }

        // GET: Forum_msg/Create
        public IActionResult Create()
        {
            ViewData["essayID"] = new SelectList(_context.Science_essay, "ID", "ID");
            //ViewData["userID"] = new SelectList(_context.users, "ID", "password");
            ViewData["userID"] = new SelectList(_context.users, "ID", "userID");
            //ViewData["userID"] = 1;
            return View();
        }

        // POST: Forum_msg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,comment,comment_time,userID,essayID")] Forum_msgViewModel forum_msgViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forum_msgViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["essayID"] = new SelectList(_context.Science_essay, "ID", "ID", forum_msgViewModel.essayID);
            //ViewData["userID"] = new SelectList(_context.users, "ID", "password", forum_msgViewModel.userID);
            ViewData["userID"] = new SelectList(_context.users, "ID", "userID", forum_msgViewModel.userID);
            return View(forum_msgViewModel);
        }

        // GET: Forum_msg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum_msgViewModel = await _context.Forum_msg.FindAsync(id);
            if (forum_msgViewModel == null)
            {
                return NotFound();
            }
            ViewData["essayID"] = new SelectList(_context.Science_essay, "ID", "ID", forum_msgViewModel.essayID);
            //ViewData["userID"] = new SelectList(_context.users, "ID", "password", forum_msgViewModel.userID);
            ViewData["userID"] = new SelectList(_context.users, "ID", "userID", forum_msgViewModel.userID);
            return View(forum_msgViewModel);
        }

        // POST: Forum_msg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,comment,comment_time,userID,essayID")] Forum_msgViewModel forum_msgViewModel)
        {
            if (id != forum_msgViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forum_msgViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Forum_msgViewModelExists(forum_msgViewModel.ID))
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
            ViewData["essayID"] = new SelectList(_context.Science_essay, "ID", "ID", forum_msgViewModel.essayID);
            //ViewData["userID"] = new SelectList(_context.users, "ID", "password", forum_msgViewModel.userID);
            ViewData["userID"] = new SelectList(_context.users, "ID", "userID", forum_msgViewModel.userID);
            return View(forum_msgViewModel);
        }

        // GET: Forum_msg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum_msgViewModel = await _context.Forum_msg
                .Include(f => f.essay)
                .Include(f => f.user)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (forum_msgViewModel == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条评论吗？');if (r == true){location.href='/Forum_msg/DeleteConfirmed/" + id + "';}else{history.go(-1);}</script>", "text/html");
            //return View(forum_msgViewModel);
        }

        // POST: Forum_msg/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forum_msgViewModel = await _context.Forum_msg.FindAsync(id);
            _context.Forum_msg.Remove(forum_msgViewModel);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条记录！');location.href='/Forum_msg/Index'</script>", "text/html");
        }
        //批量删除
        [HttpPost]
        public IActionResult MulDelete(string[] checkedId)
        {
            if (checkedId != null)
            {
                var counts = checkedId.Length;

                foreach (var i in checkedId)
                {
                    var list = _context.Forum_msg.Where(p => p.ID == Convert.ToInt32(i)).ToList();
                    foreach (var item in list)
                    {
                        _context.Forum_msg.Remove(item);
                        _context.SaveChanges();
                    }
                }
                //    /*全选、全删除：把留言表清空
                //    //var allblogs = _context.Forum_msg.ToArrayAsync();
                //    //_context.Forum_msg.RemoveRange(allblogs.Result);
                //    //await _context.SaveChangesAsync();
                //    */
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('{counts}条留言成功删除啦~~~');location.href='Index'</script>", "text/html");
            }
            return RedirectToAction(nameof(Index));
        }
        private bool Forum_msgViewModelExists(int id)
        {
            return _context.Forum_msg.Any(e => e.ID == id);
        }
    }
}
