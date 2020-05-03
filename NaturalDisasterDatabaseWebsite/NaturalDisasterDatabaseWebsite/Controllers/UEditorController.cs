using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UEditor.Core;
//using UEditorNetCore;

namespace NaturalDisasterDatabaseWebsite.Controllers
{
    //配置路由
    //[Route("api/[controller]")]
    public class UEditorController : Controller
    {
        private readonly UEditorService _ueditorService;
        public UEditorController(UEditorService ueditorService)
        {
            this._ueditorService = ueditorService;
        }

        [HttpGet,HttpPost]
        public ContentResult Upload()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}