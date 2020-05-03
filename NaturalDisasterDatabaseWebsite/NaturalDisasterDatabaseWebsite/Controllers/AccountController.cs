using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NaturalDisasterDatabaseWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace NaturalDisasterDatabaseWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly NaturalDisasterDatabaseWebsiteContext _context;

        public AccountController(NaturalDisasterDatabaseWebsiteContext context)
        {
            _context = context;
        }
        //public AccountController(UserManager<UsersViewModel> userManager, SignInManager<UsersViewModel> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}
        public IActionResult Index()
        {
            return View();
        }
        //登录
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UsersViewModel dto)

        {
            if (string.IsNullOrEmpty(dto.username) || string.IsNullOrEmpty(dto.password) || string.IsNullOrEmpty(dto.status))
            {
                return Content("<meta http-equiv='content-type' content='text/html; charset = utf-8' /><script>alert('账号 | 密码 | 身份不能为空');location.href='Login'</script>", "text/html");
            }
            ///SingleOrDefaultAsync 只取一条明细，如果没有数据返回 null， 如果明细条目大于1条报异常
            ///FirstOrDefaultAsync 只取一条明细，如果没有数据返回null， 如果明细条目大于1条取第一条
            //var loginuser = await _context.users.FirstOrDefaultAsync(u => u.username == dto.username);
            var loginuser = await _context.users.Where(u => u.username == dto.username && u.password == dto.password && u.status == dto.status).SingleOrDefaultAsync();
            if (loginuser == null)
            {
                var str = "登录失败，可能原因：\\n 1、账号 | 密码 | 身份错误；\\n 2、没有该用户，请确定是否已注册";
                return Content("<meta http-equiv='content-type' content='text/html; charset = utf-8' /><script>alert('"+str+"');location.href='Login'</script>", "text/html");
            };
            if (loginuser.username != dto.username || loginuser.password != dto.password || loginuser.status != dto.status)
            {
                return Content("<meta http-equiv='content-type' content='text/html; charset = utf-8' /><script>alert('账号或密码或身份错误');location.href='Login'</script>", "text/html");
            };
            //return BadRequest("没有该用户");

            //if (loginuser.img == "")
            //{
            //    loginuser.img = "head-default.png";
            //}
            var claims = new List<Claim>
                {
                    new Claim("ID",loginuser.ID.ToString()),
                    new Claim(ClaimTypes.Name,loginuser.username),
                    new Claim("password",loginuser.password),
                    new Claim("sex",loginuser.sex),
                    new Claim("email",loginuser.email),
                    //new Claim(ClaimTypes.Role,"管理员")
                    new Claim(ClaimTypes.Role,loginuser.status),
                    new Claim("status",loginuser.status),
                    new Claim("img",loginuser.img),
                    new Claim("telephone",loginuser.telephone),
                    new Claim("workplace",loginuser.workplace),
                    new Claim("occupation",loginuser.occupation),
                    new Claim("address",loginuser.address),
                };
                //ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    //ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                    ExpiresUtc = DateTime.UtcNow.AddDays(1),
                    ///ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    ///cookie 的绝对过期时间，会覆盖ExpireTimeSpan的设置。
                    ///ExpiresUtc = DateTime.UtcNow.AddMinutes(1),

                    ///IsPersistent = true,
                    ///表示 cookie 是否是持久化的以便它在不同的 request 之间传送。设置了ExpireTimeSpan或ExpiresUtc是必须的。
                    IsPersistent = false,//在浏览器持久化，false的时候走session持久化

                    ///AllowRefresh = <bool>,
                    /// Refreshing the authentication session should be allowed.
                    AllowRefresh = false //动态刷新令牌

                    ///IssuedUtc = <DateTimeOffset>,
                    ///  凭证认证的时间。

                    ///RedirectUri = <string>
                    ///http 跳转的时候的路径。

                };
                //SignInAsync 创建加密的 cookie，并将其添加到当前响应中。 如果未指定 AuthenticationScheme，则使用默认方案
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            if (loginuser.status == "管理员")
            {
                return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>location.href='../HomeBack/Index'</script>", "text/html");
            }
            //return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>location.href='../PensonCenter/Index'</script>", "text/html");
            return RedirectToAction("Index","PersonCenter");
        }

        //注册
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("username,password,sex,email,status,telephone,img,workplace,occupation,address")] UsersViewModel users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(users);
                    await _context.SaveChangesAsync();
                    return new ContentResult()
                    {
                        Content = "<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' />" +
                        "<div class='content' style='text-align:center; color:#52FA4D; letter-spacing:3px;'>注册成功！</div>" +
                        "<script>" +
                        "   var content = document.getElementsByClassName('content')[0];" +
                        "   var timeLeft = 2;" +
                        "   function tiaozhuan(timeLeft) {" +
                        "       if (timeLeft > 0) {" +
                        "           setTimeout(function() {" +
                        "               timeLeft--;" +
                        "               content.innerText = timeLeft + '后将跳转到登录页面';" +
                        "               tiaozhuan(timeLeft);" +
                        "           },1000); " +
                        "       }" +
                        "       else { window.location.href = 'Login'; }" +
                        "   }" +
                        "   tiaozhuan(timeLeft);" +
                        "</script> ",
                        ContentType = "text/html",
                        StatusCode = 200
                    };
                }
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "注册失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
            }
            return RedirectToAction(nameof(TipsFailed));
        }
        public IActionResult TipsFailed()
        {
            return View();
        }


        //注册账号时验证账号是否已存在,AcceptVerbs是Bind特性之一
        [AcceptVerbs("Post")]
        public IActionResult VerifyUsername(string username)
        {
            //Lambda表达式
            var isExists1 = _context.users.FirstOrDefault(m => m.username == username);
            if (isExists1 != null)
            {
                return Json(new { message = "账号已被占用, 请改用其他账号!" });
            }
            return Json(true);
        }
        //邮箱
        [AcceptVerbs("Post")]
        public IActionResult VerifyEmail(string email)
        {
            var isExists2 = _context.users.FirstOrDefault(m => m.email == email);
            if (isExists2 != null)
            {
                return Json(new { message = "已存在该邮箱!" });
            }
            return Json(true);
        }
        //手机
        [AcceptVerbs("Post")]
        public IActionResult VerifyTelephone(string telephone)
        {
            var isExists3 = _context.users.FirstOrDefault(m => m.telephone == telephone);
            if (isExists3 != null)
            {
                return Json(new { message = "已存在该号码!" });
            }
            return Json(true);
        }
        private IActionResult FailureResult(string errorMessage)
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //TODO:注销处理
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Home");
        }

        //找回密码
        public IActionResult RetrievePassword()
        {
            return View();
        }

        [AcceptVerbs("Post")]
        public IActionResult RetrievePassword(UsersViewModel usr)
        {
            if (!string.IsNullOrEmpty(usr.username) && ( !string.IsNullOrEmpty(usr.email) || !string.IsNullOrEmpty(usr.telephone)))
            {
                var isExists4 = _context.users.Where(s => s.username == usr.username).SingleOrDefault();
                if (isExists4 != null)
                {
                    var isExists5 = _context.users.Where(u => u.username == usr.username && u.email == usr.email).SingleOrDefault();
                    var isExists6 = _context.users.Where(u => u.username == usr.username && u.telephone == usr.telephone).SingleOrDefault();
                    if (isExists5 != null || isExists6 != null)
                    {
                        var queryPwd = from u in _context.users.Where(u=>u.username == usr.username) select u.password;
                        return Json(new { message = queryPwd });
                    }
                    else
                    {
                        return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('亲爱的用户，对不起，该邮箱或手机号码不属于该账号，请重新尝试！');history.go(-1);</script>", "text/html");
                    }
                }
                else
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('亲爱的用户，对不起，查无此号，请重新尝试！');history.go(-1);</script>", "text/html");
                }
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('亲爱的用户，对不起，查无此号，请重新尝试！');history.go(-1);</script>", "text/html");
        }
    }
}