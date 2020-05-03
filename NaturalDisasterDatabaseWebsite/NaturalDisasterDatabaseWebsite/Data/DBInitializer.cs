//创建数据库，使用测试数据初始化数据库
//该文件中的代码 首先检查是否有用户数据在数据库中，如果没有的话，就可以假定数据库是新建的，然后使用测试数据进行填充
//代码中使用数组存放测试数据而不是使用List<T>集合是为了优化性能
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NaturalDisasterDatabaseWebsite.Models;

namespace NaturalDisasterDatabaseWebsite.Data
{
    public static class DBInitializer
    {
        public static void Initialize(NaturalDisasterDatabaseWebsiteContext context)
        {
            //EnsureCreated方法自动创建数据库
            context.Database.EnsureCreated();

            // 查找用户
            if (context.users.Any())
            {
                return;   // DB 已有测试（基本）数据
            }

            var users = new UsersViewModel[]
            {
                new UsersViewModel{username="admin",password="123456",sex="女",email="2108123704@qq.com",status="管理员",img="head-default.png",telephone="18877524840",workplace="广西师范大学",occupation="Web前端",address="广西师范大学雁山校区"},
                new UsersViewModel{username="haha",password="185662",sex="男",email="2108123704@qq.com",status="普通用户",img="head-default.png",telephone="18877524840",workplace="广西师范大学",occupation="运维工程师",address="广西师范大学雁山校区"}
            };
            foreach (UsersViewModel u in users)
            {
                context.users.Add(u);
            }
            context.SaveChanges();

            var essays = new Science_essayViewModel[]
            {
                new Science_essayViewModel{ID=1,title="习近平总书记关于防灾减灾救灾重要论述摘录",author="灾协",source="云南防震减灾网",fb_time=DateTime.Parse("2019-07-26 19:53:00"),wz_content="要坚持抗震救灾工作和经济社会发展两手抓、两不误，大力弘扬伟大抗震救灾精神，大力发挥各级党组织领导核心和战斗堡垒作用、广大党员先锋模范作用，引导灾区群众广泛开展自力更生、生产自救活动，在中央和四川省大力支持下，积极发展生产、建设家园，用自己的双手创造幸福美好的生活",wz_style="科普",state="已发布",userID=1},
                new Science_essayViewModel {ID=2,title="古人如何应对洪涝灾害",author="灾协",source="中国水运报",fb_time=DateTime.Parse("2019-11-29 14:53:00"),wz_content="今年入夏以来，从南到北各地水灾多发，抗洪救灾成为舆论热点。事实上，洪涝灾害自古以来就是人类最常面对的自然灾害。因此，人类历史也是一部与洪涝灾害斗争的历史。那么，我国古代在条件有限的情况下是如何应对洪涝灾害呢？",wz_style="科普",state="待审核",userID=2}
            };
            foreach (Science_essayViewModel s in essays)
            {
                context.Science_essay.Add(s);
            }
            context.SaveChanges();

            var fMsgs = new Forum_msgViewModel[]
            {
                new Forum_msgViewModel{ID=1,comment="习大大的胸怀是真的非常宽广！赞赞赞~~~",comment_time=DateTime.Parse("2020-1-6 14:24:00"),userID=2,essayID=1},
                new Forum_msgViewModel{ID=1,comment="古人头脑真睿智啊~赞赞赞~",comment_time=DateTime.Parse("2019-12-28 10:43:00"),userID=5,essayID=2},
            };
            foreach (Forum_msgViewModel e in fMsgs)
            {
                context.Forum_msg.Add(e);
            }
            context.SaveChanges();
        }
    }
}
