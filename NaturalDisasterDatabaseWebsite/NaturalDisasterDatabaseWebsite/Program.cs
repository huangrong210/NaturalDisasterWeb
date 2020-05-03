//包含程序的入口点
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NaturalDisasterDatabaseWebsite.Models;
using NaturalDisasterDatabaseWebsite.Data;

namespace NaturalDisasterDatabaseWebsite
{
    /// <summary>
    /// 主机：ASP.NET Core 应用在启动时构建主机 。 主机是封装所有应用资源的对象，例如：HTTP 服务器实现；中间件组件；Logging；DI；Configuration
    /// 一个对象中包含所有应用的相互依赖资源的主要原因是生存期管理：控制应用启动和正常关闭。
    /// 提供两个主机：通用主机和 Web 主机。 通用主机是推荐的机型，而 Web 主机仅很适用于向后兼容。
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * 主机负责web应用程序的启用和生存期管理，配置服务器和请求处理管道
             * 主机配置日志、依赖关系的注入
             * 主机实际上是一个封装了应用资源的对象
             * 创建主机生成器—>配置主机—>创建主机—>运行主机**/
            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<NaturalDisasterDatabaseWebsiteContext>();
                    DBInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            host.Run();
        }

        /// <summary>
        /// 配置具有常用选项的主机：
        /// 将 Kestrel 用作 Web 服务器并启用 IIS 集成。
        /// 从 appsettings.json、appsettings.[EnvironmentName].json、环境变量、命令行参数和其他配置源中加载配置 。
        /// 将日志记录输出发送到控制台并调试提供程序。
        /// 
        /// ASP.NET Core 提供以下服务器实现：
        /// Kestrel 是跨平台 Web 服务器 。 Kestrel 通常使用 IIS 在反向代理配置中运行。 在 ASP.NET Core 2.0 或更高版本中，Kestrel 可作为面向公众的边缘服务器运行，直接向 Internet 公开。
        /// IIS HTTP 服务器是适用于使用 IIS 的 Windows 的服务器 。 借助此服务器，ASP.NET Core 应用和 IIS 在同一进程中运行。
        /// HTTP.sys是适用于不与 IIS 一起使用的 Windows 的服务器 。
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            ///HOST有两种：通用的主机（泛型的），webhost（前者的扩展）
            /// 默认配置
            ///环境变量（DOTNET开头）
            ///加载命令行参数
            ///加载应用配置
            ///配置的默认日志组件
            WebHost.CreateDefaultBuilder(args)
                ///调用这里面的一些扩展方法，进行自定义的配置
                ///默认配置，启用Kestrel
                ///组件配置
                ///主机配置项
                ///主机的web应用启动类Startup
                ///(http://*.6000)环境变量<硬编码<应用配置< 命令行
                .UseStartup<Startup>();
    }
}
