using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSA.API.Repository
{
    public class SqlSugarRepository<T> : SimpleClient<T> where T : class, new()
    {
        private readonly string _connectionString = System.Configuration.ConfigurationManager.AppSettings["DefaultConn"];
        public SqlSugarRepository(ISqlSugarClient context = null) : base(context)//注意这里要有默认值等于null
        {
            if (context == null)
            {
                base.Context = new SqlSugarClient(new ConnectionConfig()
                {
                    DbType = SqlSugar.DbType.SqlServer,
                    InitKeyType = InitKeyType.Attribute,
                    IsAutoCloseConnection = true,
                    ConnectionString = _connectionString
                });

                base.Context.Aop.OnLogExecuting = (s, p) =>
                {
                    //Console.WriteLine(s);
                };
            }
        }

        /// <summary>
        /// 扩展方法，自带方法不能满足的时候可以添加新方法
        /// </summary>
        /// <returns></returns>
        public List<T> CommQuery(string json)
        {
            T t = Context.Utilities.DeserializeObject<T>(json);
            var list = base.Context.Queryable<T>().WhereClass(t).ToList();
            return list;
        }
    }


}
