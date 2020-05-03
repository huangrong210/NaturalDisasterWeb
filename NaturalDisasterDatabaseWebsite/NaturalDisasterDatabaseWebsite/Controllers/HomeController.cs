using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NaturalDisasterDatabaseWebsite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
namespace NaturalDisasterDatabaseWebsite.Controllers
{
    //属性路由
    //[Route("home")]
    
    public class HomeController : Controller
    {
        private readonly NaturalDisasterDatabaseWebsiteContext _context;

        /// <summary>
        /// ASP.NET Core 有内置的依赖关系注入 (DI) 框架，可使配置的服务适用于应用的类
        /// 在类中获取服务实例的一种方法是使用所需类型的参数创建构造函数
        /// 参数可以是服务类型或接口。 DI 系统在运行时提供服务
        /// 尽管DI是内置的，但允许插入第三方控制反转(IoC)容器
        /// </summary>
        /// <param name="context"></param>
        private IHostingEnvironment _hostingEnv;
        public HomeController(NaturalDisasterDatabaseWebsiteContext context,IHostingEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;
        }

        //[Route("")] //默认访问
        //首页->GET:/Views/Home/Index
        //Index方法返回带有在控制器类中硬编码的消息的字符串
        public IActionResult Index()
        {
            //调用控制器的VIew方法：它使用视图模板来生成HTML响应。控制器方法（又称操作方法，如Index方法）通常返回IActionResult（或派生自ActionResult的类），而不是string等类型
            var model = _context.naturalDisasterStyles.Where(n=>n.ID>1).ToList(); //LINQ查询
            var lunbo1 = _context.naturalDisasterStyles.Where(n => n.ID == 1).ToList();
            ViewBag.lunbo1 = lunbo1;
            return View(model);
        }

        //[Route("about")]
        //关于
        public IActionResult About()
        {
            //ViewData字典是一个动态对象，这意味着可以使用任何类型；只有将内容防灾其中后ViewData对象才具有定义的属性
            //控制器将数据打包到ViewData字典中，ViewData字典对象包含将传递给视图的数据，然后，视图将数据作为HTML呈现给浏览器
            return View();
        }

        //联系
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        //隐私
        public IActionResult Privacy()
        {
            return View();
        }

        //灾害数据
        public IActionResult EightDisasters()
        {
            return View();
        }

        //灾害知识：科普、时政、未知
        public IActionResult Knowledge()
        {
            //科普：已发布
            var model1 = _context.Science_essay.Where(s => s.state.Contains("已发布") && s.wz_style.Contains("科普")).OrderByDescending(s => s.fb_time).Take(10).ToList(); //LINQ查询
            ViewBag.kepu = model1;

            //时政：已发布
            var model2 = _context.Science_essay.Where(s => s.state.Contains("已发布") && s.wz_style.Contains("时政")).OrderByDescending(s => s.fb_time).Take(10).ToList();
            ViewBag.shizheng = model2;

            //未知：已发布
            var model3 = _context.Science_essay.Where(s => s.state.Contains("已发布") && s.wz_style.Contains("未知")).OrderByDescending(s => s.fb_time).Take(5).ToList();
            ViewBag.weizhi = model3;

            //轮播图
            var lunbo2 = _context.naturalDisasterStyles.Where(n => n.ID == 1).ToList();
            ViewBag.lunbo2 = lunbo2;
            var lunbo = _context.naturalDisasterStyles.Where(n => n.ID > 1).ToList();
            ViewBag.lunbo = lunbo;
            return View();
            //return View(_context.Science_essay.Where(s => s.state.Contains("已发布")).OrderByDescending(s => s.fb_time).Take(10).ToList());
        }
        public async Task<IActionResult> KnowledgeDetail(int? id)
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
            var forumMsg = _context.Forum_msg.Where(f => f.essayID == id).OrderByDescending(f=>f.comment_time).Include(s=>s.user).ToList();
            ViewBag.forumMsg = forumMsg;
            return View(science_essayViewModel);
        }

        // POST: Forum_msg/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewForumMsg([Bind("comment,comment_time,userID,essayID")] Forum_msgViewModel forum_msgViewModel,string essayID,string comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (comment == null)
                    {
                        return Content("<meta http-equiv='content-type' content='text/html; charset = utf-8' /><script>alert('请输入评论内容');history.go(-1);</script>", "text/html");
                    }
                    _context.Add(forum_msgViewModel);
                    await _context.SaveChangesAsync();
                    return Content("<meta http-equiv='content-type' content='text/html; charset = utf-8' /><script>alert('发表成功');history.go(-1);</script>", "text/html");
                }
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "发布信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
            }
            return View(forum_msgViewModel);
        }
        public IActionResult MoreNews()
        {
            return View(_context.Science_essay.Where(s => s.state.Contains("已发布")).OrderByDescending(s => s.fb_time).ToList());
        }

        /// <summary>
        /// 更多未知类型文章
        /// </summary>
        /// <returns></returns>
        public IActionResult MoreOthers()
        {
            return View(_context.Science_essay.Where(s => s.state.Contains("已发布")).OrderByDescending(s => s.fb_time).ToList());
        }
        public IActionResult MorePScience()
        {
            return View(_context.Science_essay.Where(s => s.state.Contains("已发布")).OrderByDescending(s => s.fb_time).ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //错误
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //注册：上传头像
        string[] picFormatArray = { "png", "jpg", "jpeg", "bmp", "gif", "ico", "PNG", "JPG", "JPEG", "BMP", "GIF", "ICO" };
        public IActionResult UploadFiles()
        {
            long size = 0;//图片大小
            var fName = "";
            var files = Request.Form.Files;//获取前端传过来的图片
            size = files.Sum(f => f.Length);
            if (size > 104857600)
            {
                return Json(new { message=$"图片不能超过100MB！"});
            }
            //List<string> filePathResultList = new List<string>(); //多张图片
            foreach (var file in files)
            {
                var fileName = file.FileName.Trim('"');//获取图片名
                fName = fileName;
                //fileName = _hostingEnv.WebRootPath + $@"\upfiles\{fileName}";//指定图片上传的路径
                string filePath = _hostingEnv.WebRootPath + $@"\upfiles\";//指定图片上传的路径
                //size += file.Length;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string suffix = fileName.Split('.')[1]; //图片后缀
                if (!picFormatArray.Contains(suffix))
                {
                    return Json(new { message = "不支持该图片格式！支持格式如：'png', 'jpg', 'jpeg', 'bmp', 'gif','ico'" });
                }
                //fileName = Guid.NewGuid() + "." + suffix; //把原图片名称变为流名称
                string fileFullName = filePath + fileName;
                //using (FileStream fs = System.IO.File.Create(fileName))//创建文件流
                using (FileStream fs = System.IO.File.Create(fileFullName))//创建文件流
                {
                    file.CopyTo(fs);//将上传文件的内容复制到目标流
                    fs.Flush();//清除此流的缓冲区并导致将任何缓冲数据写入
                }
                //filePathResultList.Add($"/upfiles/{fileName}"); //多张图片上传路径
            }
            //string message = $"{files.Count} 个文件 /{size} 字节 上传成功!";
            //return Json(new { message = $"{files.Count}个文件 /{size}字节上传成功!" });
            var userId = this.User.FindFirstValue("ID");
            return Json(new { message=$"上传成功!",fName,userId });
        }

        //首页：农作物生物灾害 地图数据
        [HttpGet]
        public IActionResult GetCropMap()
        {
            var cropdlist = (from cd in _context.CropDetailList select cd).ToList();
            if (cropdlist == null)
            {
                return NotFound();
            }

            return Json(new { cropdlist });
        }
        //首页：森林生物灾害 地图数据
        [HttpGet]
        public IActionResult GetForestMap()
        {
            var forestdlist = (from fd in _context.ForestDetailList select fd).ToList();
            if (forestdlist == null)
            {
                return NotFound();
            }

            return Json(new { forestdlist });
        }
        //首页：地质灾害 地图数据
        [HttpGet]
        public IActionResult GetGeologyMap()
        {
            var geologydlist = (from gd in _context.GeologyDetailList select gd).ToList();
            if (geologydlist == null)
            {
                return NotFound();
            }

            return Json(new { geologydlist });
        }
        //首页：森林火灾 地图数据
        [HttpGet]
        public IActionResult GetFireMap()
        {
            var firedlist = (from fired in _context.FireDetailList select fired).ToList();
            if (firedlist == null)
            {
                return NotFound();
            }

            return Json(new { firedlist });
        }
        //首页：洪水灾害 地图数据
        [HttpGet]
        public IActionResult GetFloodMap()
        {
            var flooddlist = (from floodd in _context.FloodDetailList select floodd).ToList();
            if (flooddlist == null)
            {
                return NotFound();
            }

            return Json(new { flooddlist });
        }
        //首页：气象灾害 地图数据
        [HttpGet]
        public IActionResult GetQixiangMap()
        {
            var qidlist = (from qid in _context.QixiangDetailList select qid).ToList();
            if (qidlist == null)
            {
                return NotFound();
            }

            return Json(new { qidlist });
        }
        //首页：海洋灾害 地图数据
        [HttpGet]
        public IActionResult GetMarineMap()
        {
            var marinedlist = (from mad in _context.MarineDetailList select mad).ToList();
            if (marinedlist == null)
            {
                return NotFound();
            }

            return Json(new { marinedlist });
        }
        //首页：地震灾害 地图数据
        [HttpGet]
        public IActionResult GetQuakeMap()
        {
            var quakedlist = (from quaked in _context.QuakeDetailList select quaked).ToList();
            if (quakedlist == null)
            {
                return NotFound();
            }

            return Json(new { quakedlist });
        }

        //首页：查询数据

        //[HttpPost]
        [AcceptVerbs("Post")]
        public IActionResult queryDataMap(string eightselect, string startDate, string endDate)
        {
            var msg = "暂无数据";
            if (startDate == null)
            {
                var endTime = DateTime.Now.ToString("yyyy-MM-dd");
                if(endDate == endTime)
                {
                    if (eightselect == "农作物生物灾害") { return GetCropMap(); }
                    if (eightselect == "森林生物灾害") { return GetForestMap(); }
                    if (eightselect == "地质灾害") { return GetGeologyMap(); }
                    if (eightselect == "森林火灾") { return GetFireMap(); }
                    if (eightselect == "洪水灾害") { return GetFloodMap(); }
                    if (eightselect == "气象灾害") { return GetQixiangMap(); }
                    if (eightselect == "海洋灾害") { return GetMarineMap(); }
                    if (eightselect == "地震灾害") { return GetQuakeMap(); }
                    return Json(new { msg });
                }
                else
                {
                    var end = DateTime.Parse(endDate);
                    if (eightselect == "农作物生物灾害")
                    {
                        var cropdlist = (from cdate in _context.CropDetailList where cdate.croptime <= end select cdate).ToList();
                        return Json(new { cropdlist });
                    }
                    if (eightselect == "森林生物灾害")
                    {
                        var forestdlist = (from fddate in _context.ForestDetailList where fddate.foresttime <= end select fddate).ToList();
                        return Json(new { forestdlist });
                    }
                    if (eightselect == "地质灾害")
                    {
                        var geologydlist = (from gddate in _context.GeologyDetailList where gddate.geologytime <= end select gddate).ToList();
                        return Json(new { geologydlist });
                    }
                    if (eightselect == "森林火灾")
                    {
                        var firedlist = (from fireddate in _context.FireDetailList where fireddate.firetime <= end select fireddate).ToList();
                        return Json(new { firedlist });
                    }
                    if (eightselect == "洪水灾害")
                    {
                        var flooddlist = (from floodddate in _context.FloodDetailList where floodddate.floodtime <= end select floodddate).ToList();
                        return Json(new { flooddlist });
                    }
                    if (eightselect == "气象灾害")
                    {
                        var qidlist = (from qiddate in _context.QixiangDetailList where qiddate.qixiangtime <= end select qiddate).ToList();
                        return Json(new { qidlist });
                    }
                    if (eightselect == "海洋灾害")
                    {
                        var marinedlist = (from maddate in _context.MarineDetailList where maddate.marinetime <= end select maddate).ToList();
                        return Json(new { marinedlist });
                    }
                    if (eightselect == "地震灾害")
                    {
                        var quakedlist = (from quakeddate in _context.QuakeDetailList where quakeddate.quaketime <= end select quakeddate).ToList();
                        return Json(new { quakedlist });
                    }
                }
            }
            else
            {
                var start = DateTime.Parse(startDate);
                var end = DateTime.Parse(endDate);
                if (eightselect == "农作物生物灾害")
                {
                    var cropdlist = (from cdate in _context.CropDetailList where cdate.croptime >= start where cdate.croptime<=end select cdate).ToList();
                    return Json(new { cropdlist });
                }
                if (eightselect == "森林生物灾害") {
                    var forestdlist = (from fddate in _context.ForestDetailList where fddate.foresttime >= start where fddate.foresttime <= end select fddate).ToList();
                    return Json(new { forestdlist });
                }
                if (eightselect == "地质灾害") {
                    var geologydlist = (from gddate in _context.GeologyDetailList where gddate.geologytime >= start where gddate.geologytime <= end select gddate).ToList();
                    return Json(new { geologydlist });
                }
                if (eightselect == "森林火灾") {
                    var firedlist = (from fireddate in _context.FireDetailList where fireddate.firetime >= start where fireddate.firetime <= end select fireddate).ToList();
                    return Json(new { firedlist });
                }
                if (eightselect == "洪水灾害") {
                    var flooddlist = (from floodddate in _context.FloodDetailList where floodddate.floodtime >= start where floodddate.floodtime <= end select floodddate).ToList();
                    return Json(new { flooddlist });
                }
                if (eightselect == "气象灾害") {
                    var qidlist = (from qiddate in _context.QixiangDetailList where qiddate.qixiangtime >= start where qiddate.qixiangtime <= end select qiddate).ToList();
                    return Json(new { qidlist });
                }
                if (eightselect == "海洋灾害") {
                    var marinedlist = (from maddate in _context.MarineDetailList where maddate.marinetime >= start where maddate.marinetime <= end select maddate).ToList();
                    return Json(new { marinedlist });
                }
                if (eightselect == "地震灾害") {
                    var quakedlist = (from quakeddate in _context.QuakeDetailList where quakeddate.quaketime >= start where quakeddate.quaketime <= end select quakeddate).ToList();
                    return Json(new { quakedlist });
                }
            }
            return Json(new { msg });
        }

        //首页：显示到地图
        [HttpPost]
        public IActionResult DisplayToMap(string eightselect, string startDate, string endDate)
        {
            var msg = "暂无数据";
            var start = DateTime.Parse(startDate);
            var end = DateTime.Parse(endDate);
            if (eightselect == "农作物生物灾害")
            {
                var cropdlist = (from cdate in _context.CropDetailList where cdate.croptime >= start where cdate.croptime <= end select cdate).ToList();
                return Json(new { cropdlist });
            }
            if (eightselect == "森林生物灾害")
            {
                var forestdlist = (from fddate in _context.ForestDetailList where fddate.foresttime >= start where fddate.foresttime <= end select fddate).ToList();
                return Json(new { forestdlist });
            }
            if (eightselect == "地质灾害")
            {
                var geologydlist = (from gddate in _context.GeologyDetailList where gddate.geologytime >= start where gddate.geologytime <= end select gddate).ToList();
                return Json(new { geologydlist });
            }
            if (eightselect == "森林火灾")
            {
                var firedlist = (from fireddate in _context.FireDetailList where fireddate.firetime >= start where fireddate.firetime <= end select fireddate).ToList();
                return Json(new { firedlist });
            }
            if (eightselect == "洪水灾害")
            {
                var flooddlist = (from floodddate in _context.FloodDetailList where floodddate.floodtime >= start where floodddate.floodtime <= end select floodddate).ToList();
                return Json(new { flooddlist });
            }
            if (eightselect == "气象灾害")
            {
                var qidlist = (from qiddate in _context.QixiangDetailList where qiddate.qixiangtime >= start where qiddate.qixiangtime <= end select qiddate).ToList();
                return Json(new { qidlist });
            }
            if (eightselect == "海洋灾害")
            {
                var marinedlist = (from maddate in _context.MarineDetailList where maddate.marinetime >= start where maddate.marinetime <= end select maddate).ToList();
                return Json(new { marinedlist });
            }
            if (eightselect == "地震灾害")
            {
                var quakedlist = (from quakeddate in _context.QuakeDetailList where quakeddate.quaketime >= start where quakeddate.quaketime <= end select quakeddate).ToList();
                return Json(new { quakedlist });
            }
            return Json(new { msg });
        }

        //灾害数据：农作物生物灾害
        [HttpGet]
        public IActionResult GetCropCharts()
        {
            var croplist = (from c in _context.cropBiologicalDisaster select c).ToList();
            if (croplist == null)
            {
                return NotFound();
            }
            
            return Json(new { croplist });
        }

        //灾害数据：森林生物灾害
        [HttpGet]
        public IActionResult GetForestCharts()
        {
            var forestlist = (from f in _context.forestBiologicalDisaster select f).ToList();
            if (forestlist == null)
            {
                return NotFound();
            }
            return Json(new { forestlist });
        }

        //灾害数据：地质灾害
        [HttpGet]
        public IActionResult GetGeologicalCharts()
        {
            var geologylist = (from g in _context.geologicalDisaster select g).ToList();
            if (geologylist == null)
            {
                return NotFound();
            }
            return Json(new { geologylist });
        }
        //灾害数据：森林火灾
        [HttpGet]
        public IActionResult GetFireCharts()
        {
            var firelist = (from fi in _context.forestFireDisaster select fi).ToList();
            if (firelist == null)
            {
                return NotFound();
            }
            return Json(new { firelist });
        }

        //灾害数据：洪水灾害
        [HttpGet]
        public IActionResult GetFloodCharts()
        {
            var floodlist = (from fl in _context.floodDisaster select fl).ToList();
            if (floodlist == null)
            {
                return NotFound();
            }
            return Json(new { floodlist });
        }
        //灾害数据：气象灾害
        [HttpGet]
        public IActionResult GetMeteorologyCharts()
        {
            var meteolist = (from me in _context.meteorologicalDisaster select me).ToList();
            if (meteolist == null)
            {
                return NotFound();
            }
            return Json(new { meteolist });
        }
        //灾害数据：海洋灾害（主要以全国为主）
        [HttpGet]
        public IActionResult GetMarineCharts()
        {
            var marinelist = (from me in _context.marineDisaster select me).ToList();
            if (marinelist == null)
            {
                return NotFound();
            }
            return Json(new { marinelist });
        }
        //灾害数据：地震灾害
        [HttpGet]
        public IActionResult GetEarthquakeCharts()
        {
            var earthlist = (from ear in _context.earthquakeDisaster select ear).ToList();
            if (earthlist == null)
            {
                return NotFound();
            }
            return Json(new { earthlist });
        }
    }
}
