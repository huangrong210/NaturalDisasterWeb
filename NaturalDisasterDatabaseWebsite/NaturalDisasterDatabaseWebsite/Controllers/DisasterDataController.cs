using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaturalDisasterDatabaseWebsite.Models;

namespace NaturalDisasterDatabaseWebsite.Controllers
{
    [Authorize(Roles = "管理员")]
    public class DisasterDataController : Controller
    {
        private readonly NaturalDisasterDatabaseWebsiteContext _context;
        public DisasterDataController(NaturalDisasterDatabaseWebsiteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //时刻
            //var croptime = (from cropt in _context.CropDetailList join uu in _context.users on cropt.userID equals uu.ID select new { cropt, uu.username}).ToList();
            //ViewBag.croptime = croptime;
            var croptime = (from cropt in _context.CropDetailList join uu in _context.users on cropt.userID equals uu.ID select new { cropt.ID,cropt.croptime,cropt.cropplace,cropt.croplongitude,cropt.cropdimension,cropt.cropstyle,cropt.croploss,cropt.croparea,cropt.cropdetails,cropt.userID, uu.username }).ToList();
            //Dynamic动态类型：可以存储任何类型的值在动态数据类型变量中。这些变量的类型检查是在运行时发生的
            List<dynamic> Otherallmsg1 = new List<dynamic>();
            foreach (var oitem in croptime)
            {
                dynamic otherObj = new ExpandoObject();
                otherObj.ID = oitem.ID;
                otherObj.croptime = oitem.croptime;
                otherObj.cropplace = oitem.cropplace;
                otherObj.croplongitude = oitem.croplongitude;
                otherObj.cropdimension = oitem.cropdimension;
                otherObj.cropstyle = oitem.cropstyle;
                otherObj.croploss = oitem.croploss;
                otherObj.croparea = oitem.croparea;
                otherObj.cropdetails = oitem.cropdetails;
                otherObj.userID = oitem.userID;
                otherObj.username = oitem.username;

                Otherallmsg1.Add(otherObj);
            }
            ViewBag.croptime = Otherallmsg1;

            var foresttime = (from forestt in _context.ForestDetailList join uu in _context.users on forestt.userID equals uu.ID select new { forestt.ID, forestt.foresttime, forestt.forestplace, forestt.forestlogitude, forestt.forestdimension, forestt.forestloss, forestt.foreststyle, forestt.forestarea, forestt.forestdetails, forestt.userID, uu.username }).ToList();
            List<dynamic> Otherallmsg2 = new List<dynamic>();
            foreach (var oitem in foresttime)
            {
                dynamic otherObj = new ExpandoObject();
                otherObj.ID = oitem.ID;
                otherObj.foresttime = oitem.foresttime;
                otherObj.forestplace = oitem.forestplace;
                otherObj.forestlogitude = oitem.forestlogitude;
                otherObj.forestdimension = oitem.forestdimension;
                otherObj.forestloss = oitem.forestloss;
                otherObj.foreststyle = oitem.foreststyle;
                otherObj.forestarea = oitem.forestarea;
                otherObj.forestdetails = oitem.forestdetails;
                otherObj.userID = oitem.userID;
                otherObj.username = oitem.username;

                Otherallmsg2.Add(otherObj);
            }
            ViewBag.foresttime = Otherallmsg2;

            var geologytime = (from geologyt in _context.GeologyDetailList join uu in _context.users on geologyt.userID equals uu.ID select new { geologyt.ID, geologyt.geologytime, geologyt.geologyplace, geologyt.geologylogitude, geologyt.geologydimension, geologyt.geologycasualty, geologyt.geologylevel, geologyt.geologystyle, geologyt.geologyloss,geologyt.geologyarea,geologyt.geologydetails, geologyt.userID, uu.username }).ToList();
            List<dynamic> Otherallmsg3 = new List<dynamic>();
            foreach (var oitem in geologytime)
            {
                dynamic otherObj = new ExpandoObject();
                otherObj.ID = oitem.ID;
                otherObj.geologytime = oitem.geologytime;
                otherObj.geologyplace = oitem.geologyplace;
                otherObj.geologylogitude = oitem.geologylogitude;
                otherObj.geologydimension = oitem.geologydimension;
                otherObj.geologycasualty = oitem.geologycasualty;
                otherObj.geologylevel = oitem.geologylevel;
                otherObj.geologystyle = oitem.geologystyle;
                otherObj.geologyloss = oitem.geologyloss;
                otherObj.geologyarea = oitem.geologyarea;
                otherObj.geologydetails = oitem.geologydetails;
                otherObj.userID = oitem.userID;
                otherObj.username = oitem.username;

                Otherallmsg3.Add(otherObj);
            }
            ViewBag.geologytime = Otherallmsg3;

            var firetime = (from firet in _context.FireDetailList join uu in _context.users on firet.useID equals uu.ID select new { firet.ID, firet.firetime, firet.fireplace, firet.firelogitude, firet.firedimension, firet.firecasualty, firet.fireloss, firet.firearea, firet.fireslevel, firet.firedetails, firet.useID, uu.username }).ToList();
            List<dynamic> Otherallmsg4 = new List<dynamic>();
            foreach (var oitem in firetime)
            {
                dynamic otherObj = new ExpandoObject();
                otherObj.ID = oitem.ID;
                otherObj.firetime = oitem.firetime;
                otherObj.fireplace = oitem.fireplace;
                otherObj.firelogitude = oitem.firelogitude;
                otherObj.firedimension = oitem.firedimension;
                otherObj.firecasualty = oitem.firecasualty;
                otherObj.fireloss = oitem.fireloss;
                otherObj.firearea = oitem.firearea;
                otherObj.fireslevel = oitem.fireslevel;
                otherObj.firedetails = oitem.firedetails;
                otherObj.userID = oitem.useID;
                otherObj.username = oitem.username;

                Otherallmsg4.Add(otherObj);
            }
            ViewBag.firetime = Otherallmsg4;

            var floodtime = (from floodt in _context.FloodDetailList join uu in _context.users on floodt.userID equals uu.ID select new { floodt.ID, floodt.floodtime, floodt.floodplace, floodt.floodlogitude, floodt.flooddimension, floodt.floodlevel, floodt.floodloss, floodt.floodcasualty, floodt.floodstyle, floodt.floodarea,floodt.flooddetails, floodt.userID, uu.username }).ToList();
            List<dynamic> Otherallmsg5 = new List<dynamic>();
            foreach (var oitem in floodtime)
            {
                dynamic otherObj = new ExpandoObject();
                otherObj.ID = oitem.ID;
                otherObj.floodtime = oitem.floodtime;
                otherObj.floodplace = oitem.floodplace;
                otherObj.floodlogitude = oitem.floodlogitude;
                otherObj.flooddimension = oitem.flooddimension;
                otherObj.floodlevel = oitem.floodlevel;
                otherObj.floodloss = oitem.floodloss;
                otherObj.floodcasualty = oitem.floodcasualty;
                otherObj.floodstyle = oitem.floodstyle;
                otherObj.floodarea = oitem.floodarea;
                otherObj.flooddetails = oitem.flooddetails;
                otherObj.userID = oitem.userID;
                otherObj.username = oitem.username;

                Otherallmsg5.Add(otherObj);
            }
            ViewBag.floodtime = Otherallmsg5;

            var meteorologytime = (from meteorologyt in _context.QixiangDetailList join uu in _context.users on meteorologyt.userID equals uu.ID select new { meteorologyt.ID, meteorologyt.qixiangtime, meteorologyt.qixiangplace, meteorologyt.qixianglogitude, meteorologyt.qixiangdimension, meteorologyt.qixiangloss, meteorologyt.qixiangarea, meteorologyt.qixiangcasualty, meteorologyt.qixiangstyle, meteorologyt.qixiangdetails, meteorologyt.userID, uu.username }).ToList();
            List<dynamic> Otherallmsg6 = new List<dynamic>();
            foreach (var oitem in meteorologytime)
            {
                dynamic otherObj = new ExpandoObject();
                otherObj.ID = oitem.ID;
                otherObj.qixiangtime = oitem.qixiangtime;
                otherObj.qixiangplace = oitem.qixiangplace;
                otherObj.qixianglogitude = oitem.qixianglogitude;
                otherObj.qixiangdimension = oitem.qixiangdimension;
                otherObj.qixiangloss = oitem.qixiangloss;
                otherObj.qixiangarea = oitem.qixiangarea;
                otherObj.qixiangcasualty = oitem.qixiangcasualty;
                otherObj.qixiangstyle = oitem.qixiangstyle;
                otherObj.qixiangdetails = oitem.qixiangdetails;
                otherObj.userID = oitem.userID;
                otherObj.username = oitem.username;

                Otherallmsg6.Add(otherObj);
            }
            ViewBag.meteorologytime = Otherallmsg6;

            var marinetime = (from marinet in _context.MarineDetailList join uu in _context.users on marinet.userID equals uu.ID select new { marinet.ID, marinet.marinetime, marinet.marineplace, marinet.marinelogitude, marinet.marinedimension, marinet.marineloss, marinet.marinecasualty, marinet.marinestyle, marinet.marinedetails, marinet.userID, uu.username }).ToList();
            List<dynamic> Otherallmsg7 = new List<dynamic>();
            foreach (var oitem in marinetime)
            {
                dynamic otherObj = new ExpandoObject();
                otherObj.ID = oitem.ID;
                otherObj.marinetime = oitem.marinetime;
                otherObj.marineplace = oitem.marineplace;
                otherObj.marinelogitude = oitem.marinelogitude;
                otherObj.marinedimension = oitem.marinedimension;
                otherObj.marineloss = oitem.marineloss;
                otherObj.marinecasualty = oitem.marinecasualty;
                otherObj.marinestyle = oitem.marinestyle;
                otherObj.marinedetails = oitem.marinedetails;
                otherObj.userID = oitem.userID;
                otherObj.username = oitem.username;

                Otherallmsg7.Add(otherObj);
            }
            ViewBag.marinetime = Otherallmsg7;

            var quaketime = (from quaket in _context.QuakeDetailList join uu in _context.users on quaket.userID equals uu.ID select new { quaket.ID, quaket.quaketime, quaket.quakeplace, quaket.quakelongitude, quaket.quakedimension, quaket.quakelevel, quaket.quakedepth, quaket.quakecasualty, quaket.quakeloss,quaket.quakearea,quaket.quakedetails, quaket.userID, uu.username }).ToList();
            List<dynamic> Otherallmsg8 = new List<dynamic>();
            foreach (var oitem in quaketime)
            {
                dynamic otherObj = new ExpandoObject();
                otherObj.ID = oitem.ID;
                otherObj.quaketime = oitem.quaketime;
                otherObj.quakeplace = oitem.quakeplace;
                otherObj.quakelongitude = oitem.quakelongitude;
                otherObj.quakedimension = oitem.quakedimension;
                otherObj.quakelevel = oitem.quakelevel;
                otherObj.quakedepth = oitem.quakedepth;
                otherObj.quakecasualty = oitem.quakecasualty;
                otherObj.quakeloss = oitem.quakeloss;
                otherObj.quakearea = oitem.quakearea;
                otherObj.quakedetails = oitem.quakedetails;
                otherObj.userID = oitem.userID;
                otherObj.username = oitem.username;

                Otherallmsg8.Add(otherObj);
            }
            ViewBag.quaketime = Otherallmsg8;

            //年度
            var cropyear = (from cropy in _context.cropBiologicalDisaster select cropy).ToList();
            ViewBag.cropyear = cropyear;

            var forestyear = (from foresty in _context.forestBiologicalDisaster select foresty).ToList();
            ViewBag.forestyear = forestyear;

            var geologyyear = (from geologyy in _context.geologicalDisaster select geologyy).ToList();
            ViewBag.geologyyear = geologyyear;

            var fireyear = (from firey in _context.forestFireDisaster select firey).ToList();
            ViewBag.fireyear = fireyear;

            var floodyear = (from floody in _context.floodDisaster select floody).ToList();
            ViewBag.floodyear = floodyear;

            var meteorologyyear = (from meteorologyy in _context.meteorologicalDisaster select meteorologyy).ToList();
            ViewBag.meteorologyyear = meteorologyyear;

            var marineyear = (from mariney in _context.marineDisaster select mariney).ToList();
            ViewBag.marineyear = marineyear;

            var quakeyear = (from quakey in _context.earthquakeDisaster select quakey).ToList();
            ViewBag.quakeyear = quakeyear;

            return View();
            //return View(await _context.users.ToListAsync());
        }

        //编辑时刻灾害数据：农作物
        public IActionResult EditCrop(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crop = from cc in _context.CropDetailList where cc.ID==id select cc;
            if (crop == null)
            {
                return NotFound();
            }
            ViewBag.cropedit = crop.ToList();
            return View();
        }
        [HttpPost, ActionName("EditCrop")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCropPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cropToUpdate = await _context.CropDetailList.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<CropDetailsViewModel>(cropToUpdate, "", u => u.croptime, u => u.cropplace, u => u.croplongitude, u => u.cropdimension, u => u.cropstyle, u => u.croploss, u => u.croparea, u => u.cropdetails))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(cropToUpdate);
        }

        //编辑时刻灾害数据：森林生物
        public IActionResult EditForest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forest = from cc in _context.ForestDetailList where cc.ID == id select cc;
            if (forest == null)
            {
                return NotFound();
            }
            ViewBag.forestedit = forest.ToList();
            return View();
        }
        [HttpPost, ActionName("EditForest")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditForestPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var forestToUpdate = await _context.ForestDetailList.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<ForestDetailsViewModel>(forestToUpdate, "", u => u.foresttime, u => u.forestplace, u => u.forestlogitude, u => u.forestdimension, u => u.forestloss, u => u.foreststyle, u => u.forestarea, u => u.forestdetails))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(forestToUpdate);
        }

        //编辑时刻灾害数据：地质
        public IActionResult EditGeology(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geology = from cc in _context.GeologyDetailList where cc.ID == id select cc;
            if (geology == null)
            {
                return NotFound();
            }
            ViewBag.geologyedit = geology.ToList();
            return View();
        }
        [HttpPost, ActionName("EditGeology")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditGeologyPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var geologyToUpdate = await _context.GeologyDetailList.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<GeologyDetailsViewModel>(geologyToUpdate, "", u => u.geologytime, u => u.geologyplace, u => u.geologylogitude, u => u.geologydimension,u=>u.geologycasualty,u=>u.geologylevel, u => u.geologyloss, u => u.geologystyle, u => u.geologyarea, u => u.geologydetails))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(geologyToUpdate);
        }
        //编辑时刻灾害数据：火灾
        public IActionResult EditFire(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fire = from cc in _context.FireDetailList where cc.ID == id select cc;
            if (fire == null)
            {
                return NotFound();
            }
            ViewBag.fireedit = fire.ToList();
            return View();
        }
        [HttpPost, ActionName("EditFire")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFirePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var fireToUpdate = await _context.FireDetailList.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<FireDetailsViewModel>(fireToUpdate, "", u => u.firetime, u => u.fireplace, u => u.firelogitude, u => u.firedimension, u => u.firecasualty, u => u.fireslevel, u => u.fireloss, u => u.firearea, u => u.firedetails))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(fireToUpdate);
        }

        //编辑时刻灾害数据：洪水
        public IActionResult EditFlood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flood = from cc in _context.FloodDetailList where cc.ID == id select cc;
            if (flood == null)
            {
                return NotFound();
            }
            ViewBag.floodedit = flood.ToList();
            return View();
        }
        [HttpPost, ActionName("EditFlood")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFloodPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var floodToUpdate = await _context.FloodDetailList.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<FloodDetailsViewModel>(floodToUpdate, "", u => u.floodtime, u => u.floodplace, u => u.floodlogitude, u => u.flooddimension, u => u.floodcasualty, u => u.floodlevel, u => u.floodloss, u => u.floodstyle, u => u.floodarea, u => u.flooddetails))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(floodToUpdate);
        }

        //编辑时刻灾害数据：气象
        public IActionResult EditMeteorology(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meteorology = from cc in _context.QixiangDetailList where cc.ID == id select cc;
            if (meteorology == null)
            {
                return NotFound();
            }
            ViewBag.meteorologyedit = meteorology.ToList();
            return View();
        }
        [HttpPost, ActionName("EditMeteorology")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMeteorologyPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var meteorologyToUpdate = await _context.QixiangDetailList.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<QixiangDetailsViewModel>(meteorologyToUpdate, "", u => u.qixiangtime, u => u.qixiangplace, u => u.qixianglogitude, u => u.qixiangdimension, u => u.qixiangcasualty, u => u.qixiangloss, u => u.qixiangstyle, u => u.qixiangarea, u => u.qixiangdetails))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(meteorologyToUpdate);
        }

        //编辑时刻灾害数据：海洋
        public IActionResult EditMarine(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marine = from cc in _context.MarineDetailList where cc.ID == id select cc;
            if (marine == null)
            {
                return NotFound();
            }
            ViewBag.marineedit = marine.ToList();
            return View();
        }
        [HttpPost, ActionName("EditMarine")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMarinePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var marineToUpdate = await _context.MarineDetailList.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<MarineDetailsViewModel>(marineToUpdate, "", u => u.marinetime, u => u.marineplace, u => u.marinelogitude, u => u.marinedimension, u => u.marinecasualty, u => u.marineloss, u => u.marinestyle, u => u.marinedetails))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(marineToUpdate);
        }

        //编辑时刻灾害数据：地震
        public IActionResult EditQuake(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quake = from cc in _context.QuakeDetailList where cc.ID == id select cc;
            if (quake == null)
            {
                return NotFound();
            }
            ViewBag.quakeedit = quake.ToList();
            return View();
        }
        [HttpPost, ActionName("EditQuake")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditQuakePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var quakeToUpdate = await _context.QuakeDetailList.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<QuakeDetailsViewModel>(quakeToUpdate, "", u => u.quaketime, u => u.quakeplace, u => u.quakelongitude, u => u.quakedimension, u=>u.quakelevel, u=>u.quakedepth, u => u.quakecasualty, u => u.quakeloss,u=>u.quakearea, u => u.quakedetails))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(quakeToUpdate);
        }

        //编辑年度灾害数据：农作物
        public IActionResult YearEditCrop(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cropyear = from cc in _context.cropBiologicalDisaster where cc.ID == id select cc;
            if (cropyear == null)
            {
                return NotFound();
            }
            ViewBag.cropyear = cropyear.ToList();
            return View();
        }
        [HttpPost, ActionName("YearEditCrop")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearEditCropPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yearCropToUpdate = await _context.cropBiologicalDisaster.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<CropBiologicalViewModel>(yearCropToUpdate, "", u => u.cbYears, u => u.cbOccurArea, u => u.cbControlArea, u => u.cbSaveEconomic, u => u.cbRealEconomic, u => u.cbRemarks))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(yearCropToUpdate);
        }

        //编辑年度灾害数据：森林
        public IActionResult YearEditForest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forestyear = from cc in _context.forestBiologicalDisaster where cc.ID == id select cc;
            if (forestyear == null)
            {
                return NotFound();
            }
            ViewBag.forestyear = forestyear.ToList();
            return View();
        }
        [HttpPost, ActionName("YearEditForest")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearEditForestPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yearForestToUpdate = await _context.forestBiologicalDisaster.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<ForestViewModel>(yearForestToUpdate, "", u => u.fbYears, u => u.fbTotalOccurArea, u => u.fbTotalControlArea, u => u.fbTotalControlRate, u => u.fbDiseasesOccurArea, u => u.fbDiseasesControlArea, u => u.fbDiseasesControlRate, u => u.fbPestOccurArea, u => u.fbPestControlArea, u => u.fbPestControlRate, u => u.fbMouseOccurArea, u => u.fbMouseControlArea, u => u.fbMouseControlRate, u => u.fbHarmPlantsOccurArea, u => u.fbHarmPlantsControlArea, u => u.fbHarmlPlantsControlRate, u => u.fbEconomicLosses, u => u.fbRemarks))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(yearForestToUpdate);
        }

        //编辑年度灾害数据：地质
        public IActionResult YearEditGeology(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var geologyyear = from cc in _context.geologicalDisaster where cc.ID == id select cc;
            if (geologyyear == null)
            {
                return NotFound();
            }
            ViewBag.geologyyear = geologyyear.ToList();
            return View();
        }
        [HttpPost, ActionName("YearEditGeology")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearEditGeologyPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yearGeologyToUpdate = await _context.geologicalDisaster.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<GeologicalViewModel>(yearGeologyToUpdate, "", u => u.gYears, u => u.gTOccurNumbers, u => u.gCasualtiesNumbers, u => u.gEconomicLosses, u => u.gCProjectNumbers, u=>u.gControlInvest,u=>u.gZhiliArea,u=>u.gRemarks))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(yearGeologyToUpdate);
        }

        //编辑年度灾害数据：火灾
        public IActionResult YearEditFire(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fireyear = from cc in _context.forestFireDisaster where cc.ID == id select cc;
            if (fireyear == null)
            {
                return NotFound();
            }
            ViewBag.fireyear = fireyear.ToList();
            return View();
        }
        [HttpPost, ActionName("YearEditFire")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearEditFirePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yearFireToUpdate = await _context.forestFireDisaster.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<FireViewModel>(yearFireToUpdate, "", u => u.ffYears, u => u.ffNumbers, u => u.ffGeneralNumbers, u => u.ffMiddleNumbers, u => u.ffMajorNumbers, u => u.ffSpecialNumbers, u => u.ffTFireArea, u => u.ffTAffectedArea, u => u.ffCasualtiesNumbers, u => u.ffEconomicLossed, u => u.ffRemarks))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(yearFireToUpdate);
        }

        //编辑年度灾害数据：洪水
        public IActionResult YearEditFlood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var floodyear = from cc in _context.floodDisaster where cc.ID == id select cc;
            if (floodyear == null)
            {
                return NotFound();
            }
            ViewBag.floodyear = floodyear.ToList();
            return View();
        }
        [HttpPost, ActionName("YearEditFlood")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearEditFloodPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yearFloodToUpdate = await _context.floodDisaster.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<FloodViewModel>(yearFloodToUpdate, "", u => u.fYears, u => u.fAgrishouzArea, u => u.fAgrichengzArea, u => u.fWatershouzArea, u => u.fWaterchengzArea, u => u.fDroughtshouzArea, u => u.fDroughtchengzArea, u => u.fDrainageArea, u => u.fEconomicLosses, u => u.fRemarks))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(yearFloodToUpdate);
        }

        //编辑年度灾害数据：气象
        public IActionResult YearEditMeteorology(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meteorologyyear = from cc in _context.meteorologicalDisaster where cc.ID == id select cc;
            if (meteorologyyear == null)
            {
                return NotFound();
            }
            ViewBag.meteorologyyear = meteorologyyear.ToList();
            return View();
        }
        [HttpPost, ActionName("YearEditMeteorology")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearEditMeteorologyPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yearMeteorologyToUpdate = await _context.meteorologicalDisaster.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<MeteorologyViewModel>(yearMeteorologyToUpdate, "", u => u.mYears, u => u.mTShouzArea, u => u.mTJuesArea, u => u.mManShouzNumbers, u => u.mCasualtiesNumbers, u => u.mEconomicLosses, u => u.mRemarks))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(yearMeteorologyToUpdate);
        }

        //编辑年度灾害数据：海洋
        public IActionResult YearEditMarine(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marineyear = from cc in _context.marineDisaster where cc.ID == id select cc;
            if (marineyear == null)
            {
                return NotFound();
            }
            ViewBag.marineyear = marineyear.ToList();
            return View();
        }
        [HttpPost, ActionName("YearEditMarine")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearEditMarinePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yearMarineToUpdate = await _context.marineDisaster.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<MarineViewModel>(yearMarineToUpdate, "", u => u.maYears, u => u.maTOccurNumber, u => u.maCasualtiesNumbers, u => u.maEconomicLosses, u => u.maGXEconomicLoss, u => u.maRemarks))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(yearMarineToUpdate);
        }

        //编辑年度灾害数据：地震
        public IActionResult YearEditQuake(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quakeyear = from cc in _context.earthquakeDisaster where cc.ID == id select cc;
            if (quakeyear == null)
            {
                return NotFound();
            }
            ViewBag.quakeyear = quakeyear.ToList();
            return View();
        }
        [HttpPost, ActionName("YearEditQuake")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearEditQuakePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var yearQuakeToUpdate = await _context.earthquakeDisaster.FirstOrDefaultAsync(u => u.ID == id);
            if (await TryUpdateModelAsync<EarthquakeViewModel>(yearQuakeToUpdate, "", u => u.eYears, u => u.eTotalNumbers, u => u.eCasualties, u => u.eEconomicLosses, u => u.eRemarks))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功更新数据');history.go(-1);</script>", "text/html");

                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "修改信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(yearQuakeToUpdate);
        }

        //删除时刻灾害数据：农作物
        public IActionResult DeleteCrop(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/DeleteCropConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> DeleteCropConfirm(int id)
        {
            var cropdata = await _context.CropDetailList.FindAsync(id);
            _context.CropDetailList.Remove(cropdata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除时刻灾害数据：森林
        public IActionResult DeleteForest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/DeleteForestConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> DeleteForestConfirm(int id)
        {
            var forestdata = await _context.ForestDetailList.FindAsync(id);
            _context.ForestDetailList.Remove(forestdata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除时刻灾害数据：地质
        public IActionResult DeleteGeology(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/DeleteGeologyConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> DeleteGeologyConfirm(int id)
        {
            var geologydata = await _context.GeologyDetailList.FindAsync(id);
            _context.GeologyDetailList.Remove(geologydata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除时刻灾害数据：火灾
        public IActionResult DeleteFire(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/DeleteFireConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> DeleteFireConfirm(int id)
        {
            var firedata = await _context.FireDetailList.FindAsync(id);
            _context.FireDetailList.Remove(firedata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除时刻灾害数据：洪水
        public IActionResult DeleteFlood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/DeleteFloodConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> DeleteFloodConfirm(int id)
        {
            var flooddata = await _context.FloodDetailList.FindAsync(id);
            _context.FloodDetailList.Remove(flooddata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除时刻灾害数据：气象
        public IActionResult DeleteMeteorology(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/DeleteMeteorologyConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> DeleteMeteorologyConfirm(int id)
        {
            var meteorologydata = await _context.QixiangDetailList.FindAsync(id);
            _context.QixiangDetailList.Remove(meteorologydata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }
        //删除时刻灾害数据：海洋
        public IActionResult DeleteMarine(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/DeleteMarineConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> DeleteMarineConfirm(int id)
        {
            var marinedata = await _context.MarineDetailList.FindAsync(id);
            _context.MarineDetailList.Remove(marinedata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }
        //删除时刻灾害数据：地震
        public IActionResult DeleteQuake(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/DeleteQuakeConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> DeleteQuakeConfirm(int id)
        {
            var quakedata = await _context.QuakeDetailList.FindAsync(id);
            _context.QuakeDetailList.Remove(quakedata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除年度灾害数据：农作物
        public IActionResult YearDeleteCrop(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/YearDeleteCropConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> YearDeleteCropConfirm(int id)
        {
            var yearcropdata = await _context.cropBiologicalDisaster.FindAsync(id);
            _context.cropBiologicalDisaster.Remove(yearcropdata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除年度灾害数据：森林
        public IActionResult YearDeleteForest(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/YearDeleteForestConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> YearDeleteForestConfirm(int id)
        {
            var yearforestdata = await _context.forestBiologicalDisaster.FindAsync(id);
            _context.forestBiologicalDisaster.Remove(yearforestdata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除年度灾害数据：地质
        public IActionResult YearDeleteGeology(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/YearDeleteGeologyConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> YearDeleteGeologyConfirm(int id)
        {
            var yeargeologydata = await _context.geologicalDisaster.FindAsync(id);
            _context.geologicalDisaster.Remove(yeargeologydata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除年度灾害数据：火灾
        public IActionResult YearDeleteFire(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/YearDeleteFireConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> YearDeleteFireConfirm(int id)
        {
            var yearfiredata = await _context.forestFireDisaster.FindAsync(id);
            _context.forestFireDisaster.Remove(yearfiredata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除年度灾害数据：洪水
        public IActionResult YearDeleteFlood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/YearDeleteFloodConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> YearDeleteFloodConfirm(int id)
        {
            var yearflooddata = await _context.floodDisaster.FindAsync(id);
            _context.floodDisaster.Remove(yearflooddata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除年度灾害数据：气象
        public IActionResult YearDeleteMeteorology(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/YearDeleteMeteorologyConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> YearDeleteMeteorologyConfirm(int id)
        {
            var yearmeteorologydata = await _context.meteorologicalDisaster.FindAsync(id);
            _context.meteorologicalDisaster.Remove(yearmeteorologydata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除年度灾害数据：海洋
        public IActionResult YearDeleteMarine(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/YearDeleteMarineConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> YearDeleteMarineConfirm(int id)
        {
            var yearmarinedata = await _context.marineDisaster.FindAsync(id);
            _context.marineDisaster.Remove(yearmarinedata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //删除年度灾害数据：地震
        public IActionResult YearDeleteQuake(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var r=confirm('确定要删除该条数据吗？');if (r == true){location.href='/DisasterData/YearDeleteQuakeConfirm/" + id + "';}else{history.go(-1);}</script>", "text/html");
        }
        public async Task<IActionResult> YearDeleteQuakeConfirm(int id)
        {
            var yearquakedata = await _context.earthquakeDisaster.FindAsync(id);
            _context.earthquakeDisaster.Remove(yearquakedata);
            await _context.SaveChangesAsync();
            return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功删除该条数据！');location.href='/DisasterData/Index'</script>", "text/html");
        }

        //添加时刻灾害数据:农作物
        [AllowAnonymous]
        public IActionResult CreateCrop()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCrop([Bind("croptime,cropplace,croplongitude,cropdimension,cropstyle,croploss,croparea,cropdetails,userID")] CropDetailsViewModel cropnewdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cropnewdata);
                await _context.SaveChangesAsync();
                if(User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var backMana=confirm('上报成功！确定返回灾害数据管理界面，取消返回个人中心');if(backMana==true){location.href='/DisasterData/Index'}else{location.href='/PersonCenter/Index'}</script>", "text/html");
                }
                else
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('上报成功！');location.href='/PersonCenter/Index'</script>", "text/html");
                }
            }
            return View(cropnewdata);

            //DBContext db = new DBContext();//实例化上下文
            //List<table> list = new List<table>();//泛型集合实体类型，注意哦一定要跟你添加的实体一样的否则是添加不了的
            //db.table.InsertAllOnSubmit(list);//其实他这个方法db.table.InsertAllOnSubmit<table>(list)的
            //db.SubmitChanges();//这一句疑是感觉不需要的
        }

        //添加时刻灾害数据:森林
        [AllowAnonymous]
        public IActionResult CreateForest()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForest([Bind("foresttime,forestplace,croplongitude,forestdimension,forestloss,foreststyle,forestarea,forestdetails,userID")] ForestDetailsViewModel forestnewdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forestnewdata);
                await _context.SaveChangesAsync();
                if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var backMana=confirm('上报成功！确定返回灾害数据管理界面，取消返回个人中心');if(backMana==true){location.href='/DisasterData/Index'}else{location.href='/PersonCenter/Index'}</script>", "text/html");
                }
                else
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('上报成功！');location.href='/PersonCenter/Index'</script>", "text/html");
                }
            }
            return View(forestnewdata);
        }

        //添加时刻灾害数据:地质
        [AllowAnonymous]
        public IActionResult CreateGeology()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGeology([Bind("geologytime,geologyplace,geologylogitude,geologydimension,geologycasualty,geologylevel,geologyloss,geologystyle,geologyarea,geologydetails,userID")] GeologyDetailsViewModel geologynewdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(geologynewdata);
                await _context.SaveChangesAsync();
                if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var backMana=confirm('上报成功！确定返回灾害数据管理界面，取消返回个人中心');if(backMana==true){location.href='/DisasterData/Index'}else{location.href='/PersonCenter/Index'}</script>", "text/html");
                }
                else
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('上报成功！');location.href='/PersonCenter/Index'</script>", "text/html");
                }
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
            //return View(geologynewdata);
        }

        //添加时刻灾害数据:火灾
        [AllowAnonymous]
        public IActionResult CreateFire()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFire([Bind("firetime,fireplace,firelogitude,firedimension,firecasualty,fireslevel,fireloss,firearea,firedetails,userID")] FireDetailsViewModel firenewdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(firenewdata);
                await _context.SaveChangesAsync();
                if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var backMana=confirm('上报成功！确定返回灾害数据管理界面，取消返回个人中心');if(backMana==true){location.href='/DisasterData/Index'}else{location.href='/PersonCenter/Index'}</script>", "text/html");
                }
                else
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('上报成功！');location.href='/PersonCenter/Index'</script>", "text/html");
                }
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
            //return View(geologynewdata);
        }

        //添加时刻灾害数据:洪水
        [AllowAnonymous]
        public IActionResult CreateFlood()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFlood([Bind("floodtime,floodplace,floodlogitude,flooddimension,floodcasualty,floodlevel,floodloss,floodstyle,floodarea,flooddetails,userID")] FloodDetailsViewModel floodnewdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(floodnewdata);
                await _context.SaveChangesAsync();
                if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var backMana=confirm('上报成功！确定返回灾害数据管理界面，取消返回个人中心');if(backMana==true){location.href='/DisasterData/Index'}else{location.href='/PersonCenter/Index'}</script>", "text/html");
                }
                else
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('上报成功！');location.href='/PersonCenter/Index'</script>", "text/html");
                }
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加时刻灾害数据:气象
        [AllowAnonymous]
        public IActionResult CreateMeteorology()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMeteorology([Bind("qixiangtime,qixiangplace,qixianglogitude,qixiangdimension,qixiangcasualty,qixiangloss,qixiangstyle,qixiangarea,qixiangdetails,userID")] QixiangDetailsViewModel meteorologynewdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meteorologynewdata);
                await _context.SaveChangesAsync();
                if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var backMana=confirm('上报成功！确定返回灾害数据管理界面，取消返回个人中心');if(backMana==true){location.href='/DisasterData/Index'}else{location.href='/PersonCenter/Index'}</script>", "text/html");
                }
                else
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('上报成功！');location.href='/PersonCenter/Index'</script>", "text/html");
                }
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加时刻灾害数据:海洋
        [AllowAnonymous]
        public IActionResult CreateMarine()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMarine([Bind("marinetime,marineplace,marinelogitude,marinedimension,marinecasualty,marineloss,marinestyle,marinedetails,userID")] MarineDetailsViewModel marinenewdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marinenewdata);
                await _context.SaveChangesAsync();
                if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var backMana=confirm('上报成功！确定返回灾害数据管理界面，取消返回个人中心');if(backMana==true){location.href='/DisasterData/Index'}else{location.href='/PersonCenter/Index'}</script>", "text/html");
                }
                else
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('上报成功！');location.href='/PersonCenter/Index'</script>", "text/html");
                }
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加时刻灾害数据:地震
        [AllowAnonymous]
        public IActionResult CreateQuake()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuake([Bind("quaketime,quakeplace,quakelongitude,quakedimension,quakelevel,quakedepth,quakecasualty,quakeloss,quakearea,quakedetails,userID")] QuakeDetailsViewModel quakenewdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quakenewdata);
                await _context.SaveChangesAsync();
                if (User.Identity.IsAuthenticated && User.FindFirstValue("status") == "管理员")
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>var backMana=confirm('上报成功！确定返回灾害数据管理界面，取消返回个人中心');if(backMana==true){location.href='/DisasterData/Index'}else{location.href='/PersonCenter/Index'}</script>", "text/html");
                }
                else
                {
                    return Content("<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('上报成功！');location.href='/PersonCenter/Index'</script>", "text/html");
                }
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加年度灾害数据:农作物
        public IActionResult YearCreateCrop()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearCreateCrop([Bind("cbYears,cbOccurArea,cbControlArea,cbSaveEconomic,cbRealEconomic,cbRemarks")] CropBiologicalViewModel yearcropdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yearcropdata);
                await _context.SaveChangesAsync();
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功添加数据');history.go(-1);</script>", "text/html");
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加年度灾害数据:森林
        public IActionResult YearCreateForest()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearCreateForest([Bind("fbYears,fbTotalOccurArea,fbTotalControlArea,fbTotalControlRate,fbDiseasesOccurArea,fbDiseasesControlArea,fbDiseasesControlRate,fbPestOccurArea,fbPestControlArea,fbPestControlRate,fbMouseOccurArea,fbMouseControlArea,fbMouseControlRate,fbHarmPlantsOccurArea,fbHarmPlantsControlArea,fbHarmlPlantsControlRate,fbEconomicLosses,fbRemarks")] ForestViewModel yearforestdata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yearforestdata);
                await _context.SaveChangesAsync();
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功添加数据');history.go(-1);</script>", "text/html");
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加年度灾害数据:地质
        public IActionResult YearCreateGeology()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearCreateGeology([Bind("gYears,gTOccurNumbers,gCasualtiesNumbers,gEconomicLosses,gCProjectNumbers,gControlInvest,gZhiliArea,gRemarks")] GeologicalViewModel yeargeologydata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yeargeologydata);
                await _context.SaveChangesAsync();
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功添加数据');history.go(-1);</script>", "text/html");
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加年度灾害数据:火灾
        public IActionResult YearCreateFire()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearCreateFire([Bind("ffYears,ffNumbers,ffGeneralNumbers,ffMiddleNumbers,ffMajorNumbers,ffSpecialNumbers,ffTFireArea,ffTAffectedArea,ffCasualtiesNumbers,ffEconomicLossed,ffRemarks")] FireViewModel yearfiredata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yearfiredata);
                await _context.SaveChangesAsync();
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功添加数据');history.go(-1);</script>", "text/html");
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加年度灾害数据:洪水
        public IActionResult YearCreateFlood()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearCreateFlood([Bind("fYears,fAgrishouzArea,fAgrichengzArea,fWatershouzArea,fWaterchengzArea,fDroughtshouzArea,fDroughtchengzArea,fDrainageArea,fEconomicLosses,fRemarks")] FloodViewModel yearflooddata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yearflooddata);
                await _context.SaveChangesAsync();
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功添加数据');history.go(-1);</script>", "text/html");
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加年度灾害数据: 气象
        public IActionResult YearCreateMeteorology()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearCreateMeteorology([Bind("mYears,mTShouzArea,mTJuesArea,mManShouzNumbers,mCasualtiesNumbers,mEconomicLosses,mRemarks")] MeteorologyViewModel yearmeteorologydata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yearmeteorologydata);
                await _context.SaveChangesAsync();
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功添加数据');history.go(-1);</script>", "text/html");
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加年度灾害数据: 海洋
        public IActionResult YearCreateMarine()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearCreateMarine([Bind("maYears,maTOccurNumber,maCasualtiesNumbers,maEconomicLosses,maGXEconomicLoss,maRemarks")] MarineViewModel yearmarinedata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yearmarinedata);
                await _context.SaveChangesAsync();
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功添加数据');history.go(-1);</script>", "text/html");
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //添加年度灾害数据: 地震
        public IActionResult YearCreateQuake()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YearCreateQuake([Bind("eYears,eTotalNumbers,eCasualties,eEconomicLosses,eRemarks")] EarthquakeViewModel yearquakedata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yearquakedata);
                await _context.SaveChangesAsync();
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('成功添加数据');history.go(-1);</script>", "text/html");
            }
            else
            {
                return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('添加数据失败');history.go(-1);</script>", "text/html");
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Createcrop(string[] aa)
        //{
        //    var msg = "插入数据成功";
        //    if (aa != null)
        //    {

        //        foreach (var i in aa)
        //        {
        //            //var list = _context.Forum_msg.Where(p => p.ID == Convert.ToInt32(i)).ToList();
        //            //foreach (var item in list)
        //            //{
        //            //    _context.Forum_msg.Remove(item);
        //            //    _context.SaveChanges();
        //            //}
        //        }

        //        return Json(new { msg });
        //        //return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('插入数据成功~~~');location.href='Index'</script>", "text/html");
        //    }
        //    else
        //    {
        //        return Json(new { error = "检测不到数据" });
        //        //return Content($"<meta http-equiv='Content-Type' content='text/html; charset = UTF-8' /><script>alert('检测不到数据');location.go(-1);</script>", "text/html");
        //    }
        //    //return RedirectToAction(nameof(Index));
        //    //var newcropList = new List<CropDetailsViewModel>();
        //    //foreach (var customerId in newcropList)
        //    //{
        //    //    //构建试听表实体
        //    //    var newc = new CropDetailsViewModel()
        //    //    {
        //    //        croptime = croptime,
        //    //        cropplace = cropplace,
        //    //        croplongitude = croplongitude,
        //    //        cropdimension = cropdimension,
        //    //        cropstyle = cropstyle,
        //    //        croploss = croploss,
        //    //        croparea = croparea,
        //    //        cropdetails = cropdetails,
        //    //        userID= userID
        //    //    };
        //    //    newcropList.Add(newc);
        //    //}

        //    //if (ModelState.IsValid)
        //    //{
        //    //    _context.Add(newc);
        //    //    await _context.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    //return View(newc);
        //    //return View();

        //    //_context.BatchInsert(newcropList);
        //}

        //public IActionResult BatchInsert<T>(List<CropDetailsViewModel> list) where T : CropDetailsViewModel
        //{
        //    this.Set<T>().AddRange(list);
        //    this.SaveChanges();
        //    return list.Count;
        //}

    }
}