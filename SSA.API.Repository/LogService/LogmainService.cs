using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSA.API.Repository.LogService
{
    public class LogmainService : SqlSugarRepository<Logtable.LogMain>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMains"></param>
        /// <returns></returns>
        public bool Add(Logtable.LogMain[] logMains)
        {
            return base.InsertRange(logMains); //使用自已的仓储方法
        }

        //获取所有
        public List<Logtable.LogMain> GetOrders()
        {
            return base.GetList(); //使用自已的仓储方法
        }

        //分页
        public List<Logtable.LogMain> GetLogmainPage(Expression<Func<Logtable.LogMain, bool>> where, int pagesize, int pageindex)
        {
            return base.GetPageList(where, new SqlSugar.PageModel() { PageIndex = pageindex, PageSize = pagesize }); //使用自已的仓储方法
        }

        //调用仓储扩展方法
        public List<Logtable.LogMain> GetLogmainByJson(string Json)
        {
            return base.CommQuery(Json);
        }
    }
}
