using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NaturalDisasterDatabaseWebsite.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Dynamic;

namespace NaturalDisasterDatabaseWebsite.Controllers
{
    [Authorize]
    public class PersonCenterController : Controller
    {
        private readonly NaturalDisasterDatabaseWebsiteContext _context;
        //private SignInManager<ModifyViewModel> _signInManager;
        //private UserManager<ModifyViewModel> _userManager;
        //public PersonCenterController(NaturalDisasterDatabaseWebsiteContext context,UserManager<ModifyViewModel> userManager, SignInManager<ModifyViewModel> signManager)
        public PersonCenterController(NaturalDisasterDatabaseWebsiteContext context)
        {
            _context = context;
            //_userManager = userManager;
            //_signInManager = signManager;
        }
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue("ID");
            var imgsrc = _context.users.Where(u=>u.ID.ToString()==userId);
            ViewBag.imgsrc = imgsrc;
            var imgsrc1 = _context.users.Where(u => u.ID.ToString() == userId);
            ViewBag.imgsrc1 = imgsrc1;

            //我的文章：个人发表的全部文章
            var essay =  _context.Science_essay.Where(u=>u.userID.ToString() == userId).ToList();
            ViewBag.essay = essay;
            //我的文章：个人发表的全部文章ID
            var essayID = from e in _context.Science_essay.Where(u => u.userID.ToString() == userId) select e.ID;
            //ViewBag.Eid = essayID;
            List<int> pingluns = new List<int>();
            foreach(var sid in essayID)
            {
                //个人发表的全部文章的评论数量
                var nums= (from u in _context.Forum_msg.Where(u => u.essayID == sid) select u.essayID).Count();
                pingluns.Add(nums);
            }
            ViewBag.essaynums = pingluns;

            //我的文章：个人发表的已发布文章
            var essay2 = _context.Science_essay.Where(u => u.userID.ToString() == userId && u.state.Contains("已发布")).OrderByDescending(s => s.fb_time).ToList();
            ViewBag.essay2 = essay2;
            var essayID2 = from e in _context.Science_essay.Where(u => u.userID.ToString() == userId && u.state.Contains("已发布")) orderby e.fb_time descending select e.ID;
            //ViewBag.Eid2 = essayID2;
            List<int> pingluns2 = new List<int>();
            foreach (var sid2 in essayID2)
            {
                var nums2 = (from u in _context.Forum_msg.Where(u => u.essayID == sid2) select u.essayID).Count();
                pingluns2.Add(nums2);
            }
            ViewBag.essaynums2 = pingluns2;

            //我的文章：个人发表的待审核文章
            var essay3 = _context.Science_essay.Where(u => u.userID.ToString() == userId && u.state.Contains("待审核")).OrderByDescending(s => s.fb_time).ToList();
            ViewBag.essay3 = essay3;
            var essayID3 = from e in _context.Science_essay.Where(u => u.userID.ToString() == userId && u.state.Contains("待审核")) orderby e.fb_time descending select e.ID;
            List<int> pingluns3 = new List<int>();
            foreach (var sid3 in essayID3)
            {
                var nums3 = (from u in _context.Forum_msg.Where(u => u.essayID == sid3) select u.essayID).Count();
                pingluns3.Add(nums3);
            }
            ViewBag.essaynums3 = pingluns3;

            //我的文章：个人发表的不通过文章
            var essay4 = _context.Science_essay.Where(u => u.userID.ToString() == userId && u.state.Contains("不通过")).OrderByDescending(s => s.fb_time).ToList();
            ViewBag.essay4 = essay4;
            var essayID4 = from e in _context.Science_essay.Where(u => u.userID.ToString() == userId && u.state.Contains("不通过")) orderby e.fb_time descending select e.ID;
            List<int> pingluns4 = new List<int>();
            foreach (var sid4 in essayID4)
            {
                var nums4 = (from u in _context.Forum_msg.Where(u => u.essayID == sid4) select u.essayID).Count();
                pingluns4.Add(nums4);
            }
            ViewBag.essaynums4 = pingluns4;

            //我的评论：我的文章评论
            var Otherall= (from se in _context.Science_essay.Where(se => se.userID.ToString() == userId)
                        join fm in _context.Forum_msg on se.ID equals fm.essayID
                        join uu in _context.users on fm.userID equals uu.ID
                        select new { uu.img,uu.username,fm.comment_time,se.title, seid=se.ID ,fm.comment,fm.ID }).ToList();
            List<dynamic> Otherallmsg = new List<dynamic>();
            foreach(var oitem in Otherall)
            {
                dynamic otherObj = new ExpandoObject();
                otherObj.img = oitem.img;
                otherObj.username = oitem.username;
                otherObj.time = oitem.comment_time;
                otherObj.title = oitem.title;
                otherObj.seid = oitem.seid;
                otherObj.comment = oitem.comment;
                otherObj.fmid = oitem.ID;
                Otherallmsg.Add(otherObj);
            }
            ViewBag.othermsg = Otherallmsg;
            //我的评论：我发表的评论
            var Myall = (from f in _context.Forum_msg.Where(f => f.userID.ToString() == userId)
                      join s in _context.Science_essay on f.essayID equals s.ID join u in _context.users on s.userID equals u.ID select new { f.comment_time, u.username, s.title, eid=s.ID, f.ID, f.comment}).ToList();
            List<dynamic> fallmsg = new List<dynamic>();
            foreach(var item in Myall)
            {
                dynamic dyObj = new ExpandoObject();
                dyObj.time = item.comment_time;
                dyObj.name = item.username;
                dyObj.title = item.title;
                dyObj.eid = item.eid;
                dyObj.fid = item.ID;
                dyObj.comment = item.comment;
                fallmsg.Add(dyObj);
            }
            ViewBag.allsmg = fallmsg;
            return View();
        }

        //修改头像
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifyImg(int? id,string img)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userToUpdate = await _context.users.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<UsersViewModel>(userToUpdate, "", u => u.img))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content("<meta http-equiv='content-type' content='text/html; charset = utf-8' /><script>history.go(-1);</script>", "text/html");
                    //return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "上传图像失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(userToUpdate);
        }
        
        //[HttpPost,ActionName("Index")]
        //修改个人资料
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifyData(string username,string sex,string email,string telephone,string workplace, string occupation,string address)
        {
            var ModifyDataId = this.User.FindFirstValue("ID");
            if (ModifyDataId == null)
            {
                return NotFound();
            }
            var userToUpdate = await _context.users.FirstOrDefaultAsync(u => u.ID.ToString() == ModifyDataId);
            if (await TryUpdateModelAsync<UsersViewModel>(userToUpdate, "", u => u.username, u => u.sex, u => u.email,u => u.telephone, u => u.workplace, u => u.occupation, u => u.address))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content("<meta http-equiv='content-type' content='text/html; charset = utf-8' /><script>history.go(-1);</script>", "text/html");
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改个人信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(userToUpdate);
        }

        //修改密码验证密码是否一致
        [AcceptVerbs("Post")]
        public IActionResult VerifyPwd(string password)
        {
            var PwdId = this.User.FindFirstValue("ID");
            var isSame = _context.users.Where(m=>m.ID.ToString()==PwdId).FirstOrDefault(m => m.password == password);
            if (isSame != null)
            {
                //return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('账号已被占用,请改用其他账号');location.href='Register'</script>", "text/html");
                //return Json(new { message = "密码一致" });
                return Json(true);
            }else
            {
                return Json(new { message = "原密码输入错误" });
            }
            //return Json(true);
        }
        
        /// <summary>
        /// 失败： 利用 Identity 框架中 UserManager 对象的 ChangePasswordAsync 方法用来修改密码，该方法返回一个 IdentityResult 对象，可通过其 Succeeded 属性查看操作是否成功。在此修改成功后调用 _signInManager.SignOutAsync() 方法来清除当前 Cookie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifyPassword(string password)
        {
            var PwdId1 = this.User.FindFirstValue("ID");
            if (PwdId1 == null)
            {
                return NotFound();
            }
            var userToUpdate = await _context.users.FirstOrDefaultAsync(u => u.ID.ToString() == PwdId1);
            if (await TryUpdateModelAsync<UsersViewModel>(userToUpdate, "", u => u.password))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    //return Json(new { message = "密码修改成功" });
                    return Content("<meta http-equiv='content-type' content='text/html; charset = utf-8' /><script>alert('密码修改成功!请重新登录');location.href='Logout'</script>", "text/html");
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "密码修改失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(userToUpdate);
        }

        //登出：修改密码后强制登出
        public IActionResult Logout()
        {
            //TODO:注销处理
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        //写文章
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("title,author,source,fb_time,wz_content,wz_style,state,userID")] Science_essayViewModel science_essayViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(science_essayViewModel);
                await _context.SaveChangesAsync();
                return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('成功提交文章！继续提交……');if (r == true){history.go(-1);}else{location.href = 'Index';}</script>", "text/html");
                //return RedirectToAction(nameof(Index));
            }
            return View(science_essayViewModel);
        }

        //查看文章
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

        //编辑文章
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
            return View(science_essayViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //此处绑定的ID不可省略
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
                //return RedirectToAction("Details",new { id=id });
                return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功修改文章！');location.href='/PersonCenter/Details/" + id + "'</script>", "text/html");
            }
            return View(science_essayViewModel);
        }
        private bool Science_essayViewModelExists(int id)
        {
            return _context.Science_essay.Any(e => e.ID == id);
        }

        //删除文章
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该篇文章吗？');if (r == true){location.href='/PersonCenter/DeleteConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var science_essayViewModel = await _context.Science_essay.FindAsync(id);
            _context.Science_essay.Remove(science_essayViewModel);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该篇文章！');location.href='/PersonCenter/Index'</script>", "text/html");
        }

        //删除留言
        public IActionResult DeleteForumMsg(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条留言吗？');if (r == true){location.href='/PersonCenter/DeleteForumMsgConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> DeleteForumMsgConfirm(int id)
        {
            var forum_msgViewModel = await _context.Forum_msg.FindAsync(id);
            _context.Forum_msg.Remove(forum_msgViewModel);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条留言！');location.href='/PersonCenter/Index'</script>", "text/html");
        }

        //搜索
        public IActionResult SearchArticle(string userID,string searchString)
        {
            var queryArticle = from use in _context.Science_essay where use.userID.ToString()==userID select use; //LINQ查询
            if (!String.IsNullOrEmpty(searchString))
            {
                //Lambsa表达式
                queryArticle = queryArticle.Where(s => s.title.Contains(searchString)
                                            || s.state.Contains(searchString));
            }
            return Json(queryArticle);
        }
    }
}