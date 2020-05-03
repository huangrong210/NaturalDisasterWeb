using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaturalDisasterDatabaseWebsite.Models;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;

namespace NaturalDisasterDatabaseWebsite.Controllers
{
    //[Authorize]
    [Authorize(Roles = "管理员")]
    public class UsersController : Controller
    {
        private readonly NaturalDisasterDatabaseWebsiteContext _context;

        /***
         * 控制器中的每个public方法均可作为HTTP终结点调用。HTTP终结点是Web应用程序中可定向的URL（如https://localhost:5001/Home），其中结合了所用的协议HTTPS、TCP端口等Web服务器的网络位置localhost:5001，以及目标URI：Home
         ***/
        //NaturalDisasterDatabaseWebsiteContext作为构造函数参数
        public UsersController(NaturalDisasterDatabaseWebsiteContext context)
        {
            _context = context;
        }

        /***
         * 异步代码在运行时，会引入的少量开销，在低流量时对性能的影响可以忽略不计，但在针对高流量情况下潜在的性能提升是客观的
         * 以下代码中，async关键字、Task<>返回值、await关键字和ToListAync方法让代码异步执行
         * async 关键字用于告知编译器该方法主体将生成回调并自动创建 Task<IActionResult> 返回对象
         * 返回类型 Task<IActionResult> 表示正在进行的工作返回的结果为 IActionResult 类型
         * await 关键字会使得编译器将方法拆分为两个部分。 第一部分是以异步方式结束已启动的操作。 第二部分是当操作完成时注入调用回调方法的地方
         * ToListAsync 是 ToList 方法的的异步扩展版本
        ***/
        ///注释指出这是一个HTTP GET 方法，它通过向基URL追加users进行调用
        ///IActionResult 是所有返回结果的必须实现的接口，用这个作为返回值，也就是说该方法可以接受任意返回值
        // GET: users
        public async Task<IActionResult> Index(string searchString, string sortOrder, string currentFilter, int? pageNumber)
        {
            ///分页：添加了一个页码参数、一个当前排序顺序参数和一个当前筛选器参数
            ///名为 CurrentSort 的 ViewData 元素为视图提供当前排序顺序，因为此值必须包含在分页链接中，以便在分页时保持排序顺序相同
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentPage"] = pageNumber;
            //排序
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ID_desc" : "";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "username_desc" : "";
            //ViewData["PwdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "pwd_desc" : "Pwd";
            ViewData["PwdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "password_desc" : "";
            ViewData["SexSortParm"] = String.IsNullOrEmpty(sortOrder) ? "sex_desc" : "";
            ViewData["EmailSortParm"] = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewData["StatusSortParm"] = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewData["ImgSortParm"] = String.IsNullOrEmpty(sortOrder) ? "img_desc" : "";
            ViewData["PhoneSortParm"] = String.IsNullOrEmpty(sortOrder) ? "telephone_desc" : "";
            ViewData["PlaceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "workplace_desc" : "";
            ViewData["OccuSortParm"] = String.IsNullOrEmpty(sortOrder) ? "occupation_desc" : "";
            ViewData["AddressSortParm"] = String.IsNullOrEmpty(sortOrder) ? "address_desc" : "";

            //分页
            //如果在分页过程中搜索字符串发生变化，则页面必须重置为 1，因为新的筛选器会导致显示不同的数据
            if (searchString != null)
            { pageNumber = 1;}
            else
            { searchString = currentFilter; }
            ///添加搜索（用户管理）
            ///名为 CurrentFilter 的 ViewData 元素为视图提供当前筛选器字符串。 
            ///此值必须包含在分页链接中，以便在分页过程中保持筛选器设置，并且在页面重新显示时必须将其还原到文本框中
            ViewData["CurrentFilter"] = searchString;
            var query_user = from u in _context.users select u; //LINQ查询
            if (!String.IsNullOrEmpty(searchString))
            {
                //Lambsa表达式
                query_user = query_user.Where(s => s.username.Contains(searchString)
                                                || s.sex.Contains(searchString)
                                                || s.email.Contains(searchString)
                                                || s.status.Contains(searchString)
                                                || s.telephone.Contains(searchString)
                                                || s.workplace.Contains(searchString)
                                                || s.occupation.Contains(searchString)
                                                || s.address.Contains(searchString));
            }

            //排序(大部分都是降序)
            ///<summary>
            /// 此代码接收来自 URL 中的查询字符串的 sortOrder 参数
            /// 查询字符串值由 ASP.NET Core MVC 提供，作为操作方法的参数
            /// 该参数将是一个字符串，可为“Name”或“pwd”等，可选择后跟下划线和字符串“desc”来指定降序。 默认排序顺序为升序。
            /// 首次请求索引页时，没有任何查询字符串。 用户按照姓氏升序显示，这是 switch 语句中的 fall-through 事例所建立的默认值
            /// 当用户单击列标题超链接时，查询字符串中会提供相应的 sortOrder 值
            /// 如果只有两列可供选择，可以通过switch语句中对列名称进行硬编码来编写LINQ。
            /// 若有许多列，可使用EF.Property方法将属性名称指定为一个字符串，如下:
            ///</summary>
            if (string.IsNullOrEmpty(sortOrder))
            {
                //sortOrder = "username"; //此处要与模型中定义的名称一致
                sortOrder = "ID"; //此处要与模型中定义的名称一致
            }
            bool descending = false;
            if (sortOrder.EndsWith("_desc"))
            {
                sortOrder = sortOrder.Substring(0, sortOrder.Length - 5);
                descending = true;
            }
            if (descending)
            { query_user = query_user.OrderByDescending(u => EF.Property<object>(u, sortOrder)); }
            else
            { query_user = query_user.OrderBy(u => EF.Property<object>(u, sortOrder)); }
            ///<summary>
            ///switch (sortOrder)
            ///{
            ///    case "name_desc":
            ///        query_user = query_user.OrderByDescending(u => u.username);
            ///        break;
            ///    case "pwd_desc":
            ///        query_user = query_user.OrderByDescending(u => u.password);
            ///        break;
            ///    case "Pwd":
            ///        query_user = query_user.OrderBy(u => u.password);
            ///        break;
            ///    case "email_desc":
            ///        query_user = query_user.OrderByDescending(u => u.email);
            ///        break;
            ///    case "status_desc":
            ///        query_user = query_user.OrderByDescending(u => u.status);
            ///        break;
            ///    case "img_desc":
            ///        query_user = query_user.OrderByDescending(u => u.img);
            ///        break;
            ///    case "phone_desc":
            ///        query_user = query_user.OrderByDescending(u => u.telephone);
            ///        break;
            ///    case "place_desc":
            ///        query_user = query_user.OrderByDescending(u => u.workplace);
            ///        break;
            ///    case "occu_desc":
            ///        query_user = query_user.OrderByDescending(u => u.occupation);
            ///        break;
            ///    case "address_desc":
            ///        query_user = query_user.OrderByDescending(u => u.address);
            ///        break;
            ///    default:
            ///        query_user = query_user.OrderBy(u => u.username);
            ///        break;
            ///}
            ///</summary>

            //ViewData["rows"] = rows;
            int pageSize = 10; //每页显示条数
            ViewData["pageSize"] = pageSize;
            int page = (pageNumber ?? 1);
            ///<summary>
            ///PaginatedList.CreateAsync 方法会将用户查询转换为支持分页的集合类型中的用户的单个页面。 然后将用户的单个页面传递给视图
            ///PaginatedList.CreateAsync 方法需要一个页码。 两个问号表示 NULL 合并运算符。 NULL 合并运算符为可为 NULL 的类型定义默认值；表达式 (pageNumber ?? 1) 表示如果 pageNumber 有值，则返回该值，如果 pageNumber 为 NULL，则返回 1
            ///</summary>
            return View(await PaginatedList<UsersViewModel>.CreateAsync(query_user.AsNoTracking(), page, pageSize));
            //return View(await query_user.AsNoTracking().ToListAsync());

            //用于显示数据库中的所有用户
            //return View(await _context.users.ToListAsync());
        }

        //[HttpPost]
        //public string Index(string searchString, bool notUsed)
        //{
        //    //notUsed 参数用户创建Index方法的重载
        //    return "From [HttpPost] Index: filter on" + searchString;
        //}

        // GET: users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ///使用 SingleOrDefaultAsync 方法检索单个 user 实体
            ///AsNoTracking 方法将会提升性能
            ///<summary>
             ///* 【ASP.NET Core】EF Core - “导航属性”
             ///* “导航属性”是实体框架用得算是比较频繁的概念
             ///* 首先，它是类型成员，其次，它是属性，这不是 F 话，而是明确它的本质。那么，什么场景下会用到导航属性呢？重点就落在“导航”一词上了，当实体 A 需要引用实体 B 时，实体 A 中需要公开一个属性，通过这个属性，能找到关联的实体 B。
             ///* 又或者，X 实体表示你的博客，P 实体表示你发的一篇博文。你的博客肯定会发很多博文的，所以，X 实体中可能需要一个 List<P> 类型的属性，这个属性包含了你的博客所发表的文章。
             ///* 通过一个实体的属性成员，可以定位到与之有关联的实体，这就是导航的用途了
            ///Include 和 ThenInclude 方法使上下文加载 users.essay 导航属性，并在每个注册中加载 science_essay.fMsgs 导航属性
            ///Include 和 ThenInclude 方法使上下文加载 users.fMsgs 导航属性，并在每个注册中加载 forum_msg.essay 导航属性
            ///</summary>
            var users = await _context.users
                        .Include(u => u.forum_msgs).ThenInclude(e => e.essay)
                        .Include(s => s.essay)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.ID == id);
                        //.SingleOrDefaultAsync(m => m.ID == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        //第一个（HTTP GET）Create操作方法显示初始的“创建”表单
        // GET: users/Create
        public IActionResult Create()
        {
            return View();
        }

        //第二个（[HttpPost]）‘Create’版本处理表单发布
        ///ValidateAntiForgeryToken 特性帮助抵御跨网站请求伪造 (CSRF) 攻击。 令牌通过 FormTagHelper 自动注入到视图中，并在用户提交表单时包含该令牌。 令牌由 ValidateAntiForgeryToken 特性验证
        ///Bind 特性是防止在创建方案中过多发布的一种方法
        ///ASP.NET Core 所有以 Http 开头的特性用于标识该方法只接受特定的 HTTP 请求方法
        // POST: users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("username,password,sex,email,status,img,telephone,workplace,occupation,address")] UsersViewModel users)
        {
            ///<summary>
            /// 将ASP.NET Core MVC模型绑定器创建的user实体添加到users实体集，然后将更改保存到数据库
            /// 模型绑定器指的是 ASP.NET Core MVC 功能，用户可利用它来轻松处理使用表单提交的数据
            /// 模型绑定器将已发布的表单值转换为 CLR 类型，并将其传递给操作方法的参数
            ///</summary>
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(users);
                    //实体状态：Added，SaveChanges 方法发出 INSERT 语句
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException /* ex */)
            {
                ///Log the error (uncomment ex variable name and write a log.
                /// 如果保存更改时捕获到来自 DbUpdateException 的异常，则会显示一般错误消息。 有时 DbUpdateException 异常是由应用程序外部的某些内容而非编程错误引起的，因此建议用户再次尝试
                ModelState.AddModelError("","新增用户失败"+"再次尝试，如果问题仍然存在"+"请联系系统管理者.");
            }
            return View(users);
        }

        // GET: users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            return View(users);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("id,username,password,email,status,img,telephone,workplace,occupation,address")] UsersViewModel users)
        //{
        //    if (id != users.ID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(users);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!usersExists(users.ID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(users);
        //}

        // GET: users/Delete/5
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userToUpdate = await _context.users.FirstOrDefaultAsync(u => u.ID == id);
            if(await TryUpdateModelAsync<UsersViewModel>(userToUpdate,"",u => u.username,u => u.password,u=>u.sex, u => u.email, u=> u.status, u => u.img, u => u.telephone, u => u.workplace, u => u.occupation, u => u.address))
            {
                try
                {
                    //实体状态Modified：SaveChanges 方法发出 UPDATE 语句
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "更新用户信息失败" + "再次尝试，如果问题仍然存在" + "请联系系统管理者.");
                }
            }
            return View(userToUpdate);
        }

        ///此代码接受可选参数，指示保存更改失败后是否调用此方法。 没有失败的情况下调用 HttpGet Delete 方法时，此参数为 false。 由 HttpPost Delete 方法调用以响应数据库更新错误时，此参数为 true，并且将错误消息传递到视图。
        public async Task<IActionResult> Delete(int? id,bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.users
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (users == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] ="删除失败.请再次尝试，如果问题仍存在"+"请联系系统管理员.";
            }

            return View(users);
        }

        //此代码检索所选的实体，然后调用 Remove 方法以将实体的状态设置为 Deleted
        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.users.FindAsync(id);
            if(users == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.users.Remove(users);
                //实体状态Deleted：SaveChanges 方法发出 DELETE 语句
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch(DbUpdateException /* ex */)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        //测试方法：MVC默认的URL路由逻辑格式：/[Controller]/[ActionName]/[Parameters]
        //使用 HtmlEncoder.Default.Encode 防止恶意输入（即 JavaScript）损害应用。
        //在 $"Hello {name}, NumTimes is: {numTimes}" 中使用内插字符串。
        public string Welcome(string name, int ID = 1)
        {
            //return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
            /***
             * 运行应用并输入以下 URL：https://localhost:{PORT}/users/Welcome/3?name=Rick
             * 此时，第三个 URL 段与路由参数 id 相匹配。 Welcome 方法包含 MapRoute 方法中匹配 URL 模板的参数 id。 后面的 ?（id? 中）表示 id 参数可选。（这一点具体理解请看Startup.cs文件的Configure方法中的路由配置）
             ***/
        }
    }
}
