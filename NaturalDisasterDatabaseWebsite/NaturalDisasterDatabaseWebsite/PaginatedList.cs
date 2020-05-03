//分页类
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NaturalDisasterDatabaseWebsite
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; } //当前页码
        public int TotalPages { get; set; } //总页数
        public int TotalRows { get; set; }  //数据总量

        public PaginatedList(List<T> items, int count, int pageIndex,int pageSize)
        {
            PageIndex = pageIndex;
            TotalRows = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }
        //首页 和 尾页
        //public int EndPage
        //{
        //    get
        //    {
        //        return TotalPages;
        //    }
        //}
        //属性 HasPreviousPage 和 HasNextPage 可用于启用或禁用“上一页”和“下一页”的分页按钮
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        //提取页面大小和页码，并将相应的Skip和Take语句应用于IQueryable
        //当在 IQueryable 上调用 ToListAsync 时，它将返回仅包含请求页的列表
        //由于构造函数不能运行异步代码，因此使用 CreateAsync 方法来创建 PaginatedList<T> 对象，而非构造函数
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            //使用 Skip 和 Take 语句的 PaginatedList 类来筛选服务器上的数据，而不总是对表中的所有行进行检索
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items,count,pageIndex,pageSize);
        }
    }
}
