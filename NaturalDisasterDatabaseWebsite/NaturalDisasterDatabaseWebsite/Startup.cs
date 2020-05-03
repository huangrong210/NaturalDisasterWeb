//配置应用所需的服务；定义请求处理管道。包含配置应用行为的代码。如，是否需要同意cookie
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NaturalDisasterDatabaseWebsite.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
//using UEditorNetCore;
using Microsoft.Extensions.FileProviders;
using System.IO;
using UEditor.Core;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;

namespace NaturalDisasterDatabaseWebsite
{
    /// <summary>
    /// 配置web应用所需要的服务和中间件
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //public Startup()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json");
        //    Configuration = builder.Build();
        //}
        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// 服务是应用使用的组件（注册服务的）
        /// 将配置（或注册）服务的代码添加到ConfigureServices方法中
        /// 该方法在运行时被调用，可以使用该方法将服务添加到容器中，更多信息配置应用程序的信息，可以查看https://go.microsoft.com/fwlink/?LinkID=398940
        /// 服务容器
        /// IoC容器（反转依赖和接口的方式，直接操控的对象的控制权交给了第三方，通过第三方来实现对象组件的分配和管理，一般是由依赖注入框架提供的，映射依赖、管理对象的创建和生存期）：控制反转，Inversion of Control：注册类型、请求实例：依赖注入（一系列工具和手段，最终的目的是松耦合、可维护、可测试的代码和程序）
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

                // Password settings.
                //options.Password.RequireDigit = true;
                //options.Password.RequiredLength = 6;
            });

            ///编辑器UE：第一个参数为配置文件路径，默认为项目目录下config.json
            ///第二个参数为是否缓存配置文件，默认false
            ///services.AddUEditorService(configFileRelativePath:"ueditor.json",isCacheConfig:false,basePath:"F:\basepath");
            ///注入 百度编辑器 服务
            services.AddUEditorService();

            //services.AddSession();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //添加数据库上下文(依赖注入)
            ///第一种方式：
            ///AddDbContext() 方法 接受一个泛型类型参数，我们指定了 DBContext 派生类的类型 NaturalDisasterDatabaseWebsiteContext。在 AddDbContext() 方法中，我们需要设置我们的 DBContext 的选项。
            ///设置选项可以通过 lambda表达式 来完成，我们所需要做的就是告诉 EF 框架我们的 DBContext 将转到 UseSqlServer
            ///services.AddDbContext<NaturalDisasterDatabaseWebsiteContext>(options =>

            /// options.UseSqlServer(Configuration.GetConnectionString("NaturalDisasterDatabaseWebsiteContext")));
            //第二种方式
            ///在 Startup.cs 中，调用 AddDbContext 扩展方法来预配 ASP.NET Core DI 容器中的 DbContext 类 。 默认情况下，该方法将服务生存期设置为 Scoped。 Scoped 表示上下文对象生存期与 Web 请求生存期一致，并在 Web 请求结束时将自动调用 Dispose 方法
            ///Configuration：
            ///ASP.NET Core 提供了配置框架，可以从配置提供程序的有序集中将设置作为名称 / 值对。 有适用于各种源的内置配置提供程序，例如.json 文件、.xml 文件、环境变量和命令行参数 。 此外可以编写自定义配置提供程序。
            ///例如，可以指定配置来自 appsettings.json 和环境变量 。 然后，当请求 ConnectionString 的值时，框架首先在 appsettings.json 文件中查找 。 如果也在环境变量中找到了值，那么来自环境变量的值将优先使用。
            ///为了管理密码等机密配置数据，ASP.NET Core 提供了机密管理器工具。 对于生产机密，建议使用 Azure 密钥保管库。
            services.AddDbContext<NaturalDisasterDatabaseWebsiteContext>(b =>
              {
                  var dbLink = Configuration.GetSection("ConnectionStrings:NaturalDisasterDatabaseWebsiteContext").Value;
                  if (string.IsNullOrWhiteSpace(dbLink)) { throw new Exception("未找到数据库链接。"); }

                  b.UseSqlServer(dbLink);
              });
            ///    services.AddDefaultIdentity<IdentityUser>().AddDefaultUI(UIFramework.Bootstrap4)
            ///.AddEntityFrameworkStores<NaturalDisasterDatabaseWebsiteContext>();

            ///services.AddIdentity<UsersViewModel, UsersRoleViewModel>()
            ///    .AddEntityFrameworkStores<NaturalDisasterDatabaseWebsiteContext>()
            ///    .AddDefaultTokenProviders();

            ///添加cookie认证服务
            ///注意app.UseAuthentication方法一定要放在下面的app.UseMvc方法前面，否者后面就算调用HttpContext.SignInAsync进行用户登录后，使用
            ///HttpContext.User还是会显示用户没有登录，并且HttpContext.User.Claims读取不到登录用户的任何信息。
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                    {
                        // Cookie settings
                        o.Cookie.HttpOnly = true;
                        //o.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                        o.ExpireTimeSpan = TimeSpan.FromDays(1);
                        //登录路径：这是当用户试图访问资源但未经过身份验证时，程序将会将请求重定向到这个相对路径
                        o.LoginPath = new PathString("/Account/Login");
                        //禁止访问路径：当用户试图访问资源时，但未通过该资源的任何授权策略，请求将被重定向到这个相对路径。
                        //o.ExpireTimeSpan = TimeSpan.FromDays(2); //设置 cookie 的失效时间
                        o.AccessDeniedPath = new PathString("/Home/Privacy");
                        o.SlidingExpiration = true;

                    });

            ///services.AddAuthentication(options =>
            ///{
            ///    //配置授权策略必须为管理员
            ///    options.AddPolicy("管理员", policy => policy.RequireClaim("管理员"));
            ///});

            ///AddIdentity() 方法需要传递两个范型参数: 用户实体的类型和角色实体的类型，这两个范型类型分别是创建的 User 类和一个用户角色类，我们默认使用 Microsoft.AspNetCore.Identity 命名空间下的 IdentityRole
            ///为了在 Identity 框架中使用 EF 框架，我们需要使用 AddEntityFrameworkStores() 方法来使用 EF 框架存储数据，AddEntityFrameworkStores() 会自动配置 UserStore 这样的服务，用于创建用户和验证其密码
            ///services.AddIdentity<UsersViewModel, IdentityRole>().AddEntityFrameworkStores<NaturalDisasterDatabaseWebsiteContext>();
        }

        // 该方法在运行时被调用，可以使用该方法来配置HTTP请求管道
        /// <summary>
        /// 请求处理管道由一系列中间件组件组成
        /// 例如：中间件可能处理静态文件的请求或将HTTP请求重定向到HTTPS
        /// 每个中间件在HttpContext上执行异步操作，然后调用管道中的下一个中间件或终止请求
        /// 配置请求处理管道的代码添加到Configure方法中。
        /// 
        /// 配置中间件，中间件组成管道
        /// 必须的，中间件就是处理HTTP请求和响应的
        /// 
        /// 环境：
        /// 执行环境（例如“开发”、“暂存”和“生产”）是 ASP.NET Core 中的高级概念 。 
        /// 可以通过设置 ASPNETCORE_ENVIRONMENT 环境变量来指定运行应用的环境。 
        /// ASP.NET Core 在应用启动时读取该环境变量，并将该值存储在 IHostingEnvironment 实现中。 可通过 DI 在应用的任何位置使用环境对象。
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //执行环境
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            ///中间件：通过调用其Use...扩展方法，向管道添加中间件组件
            ///app.UseDefaultFiles();
            ///app.UseStaticFiles(); //启用静态文件处理中间件
            ///UseFileServer 中间件：是针对UseDefaultFiles 和 UseStaticFiles 两个中间件的封装
            app.UseFileServer();
            //app.UseMvcWithDefaultRoute();  //方式一：给出一个默认的路由规则，允许访问HomeController
            app.UseHttpsRedirection();
            app.UseCookiePolicy();

            //app.UseSession();

            ///异常处理，异常显示页面和诊断信息的ASP.NET Core中间件
            //app.UseWelcomePage();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/upload")),//自定义存储路径
                RequestPath="/wwwroot/upload",
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control","public,max-age=36000");
                }
            });
            
            //使用认证服务
            app.UseAuthentication();//认证//身份验证中间件   注意这句话要放在app.UseMvc的前面

            //配置默认路由 ：方式二
            ///路由是映射到处理程序的 URL 模式 。 
            ///处理程序通常是 Razor 页面、MVC 控制器中的操作方法或中间件。 
            ///借助 ASP.NET Core 路由，可以控制应用使用的 URL。
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    //Home映射作为控制、Index作为操作(即Home控制器中的Index操作方法)、id，问号?表示id未知：即URL后面的参数
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //路由：方式三
            //app.UseMvc(ConfigureRoute);
        }

        //该方法必须使用IRouteBuilder类型的参数
        //private void ConfigureRoute(IRouteBuilder routeBuilder)
        //{
        //    //Home/Index 
        //    routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}");
        //}
    }
}
