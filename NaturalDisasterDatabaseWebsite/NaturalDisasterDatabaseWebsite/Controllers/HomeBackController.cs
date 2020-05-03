using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NaturalDisasterDatabaseWebsite.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NaturalDisasterDatabaseWebsite.Controllers
{
    [Authorize(Roles = "管理员")]
    public class HomeBackController : Controller
    {
        private readonly NaturalDisasterDatabaseWebsiteContext _context;

        public HomeBackController(NaturalDisasterDatabaseWebsiteContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [AcceptVerbs("Post")]
        public IActionResult GetUserImg(string id)
        {
            //Lambda表达式
            var imgsrc = from userid in _context.users where userid.ID.ToString()==id select userid.img;
            if (imgsrc != null)
            {
                return Json(new { imgsrc });
            }
            return Json(true);
        }
    }
}
