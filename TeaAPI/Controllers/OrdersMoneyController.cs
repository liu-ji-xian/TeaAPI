using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaAPI.Model;

namespace TeaAPI.Controllers
{
    /// <summary>
    /// 统计商城信息
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrdersMoneyController : ControllerBase
    {


        //从当前年的第一天到当前天的所有营业额
        //select year(OendTime) 年,sum(Omoney) 销售合计 from orders where Ostate='已完成' and YEAR(OendTime)=2020 group by YEAR(OendTime)
        //从当前年的第一天到当前天的每月营业额
        //select YEAR(OendTime)年,MONTH(OendTime)月,sum(Omoney) 销售合计 from orders where Ostate='已完成' and YEAR(OendTime)=2020 and month(OendTime) =1 group by year(OendTime),month(OendTime)
        //从商城运营当天到当天的每年营业额
        //select year(OendTime) 年,sum(Omoney) 销售合计 from orders where Ostate='已完成'  group by YEAR(OendTime)
        //显示某一年的某一个月的每天
        //select YEAR(OendTime)年,MONTH(OendTime)月, day(OendTime)天,sum(Omoney) 销售合计 from orders where Ostate='已完成' and YEAR(OendTime)=2020 and month(OendTime) =1 group by year(OendTime),month(OendTime),day(OendTime)
        //显示当前下单量用户排行榜(倒序)
        //select *from(select ONo,COUNT(*) count from Orders group by ONo) t order by  t.count desc
        //显示单笔成交额用户排行榜(倒序)
        //select * from Orders where Ostate='已完成'order by Omoney desc
        //显示总成交额用户排行榜(倒序)
        //select *from( select sum(Omoney) summoney,UIds from Orders group by UIds)t order by t.summoney desc
        //显示最近一个月成交量最大的商品
        //


        //利用线程
        //每一段时间更新一次总成交额（当天，月度，年度）
        //每一段时间更新最新成交信息（成交人信息，订单信息）

       
       

        /// <summary>
        /// 当天成交额
        /// </summary>
        /// <returns></returns>
        [Route("GetSumMoneyByDay")]
        [HttpGet]
        public decimal GetSumMoneyByDay()
        {
            var time = DateTime.Now;
            var year = time.Year;
            var month = time.Month; ;
            var day = time.Day;
            List<Orders> i=DBHelper.GetList<Orders>("select sum(Omoney) Omoney from orders where Ostate='已完成' and YEAR(OendTime)=" + year+" and month(OendTime) ="+month+" and day(OendTime)="+day+" group by year(OendTime),month(OendTime),day(OendTime)");
            if (i.Count > 0)
            {
                Orders orders = i[0];
                decimal f = orders.Omoney;

                return f;
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// 当天成交量
        /// </summary>
        /// <returns></returns>
        [Route("GetSuccerSumByDay")]
        [HttpGet]
        public int GetSumCountByDay()
        {
            var time = DateTime.Now;
            var year = time.Year;
            var month = time.Month; ;
            var day = time.Day;
            var db = DBHelper.ExecuteScalar("select count(1) Count from orders where  YEAR(OendTime)=" + year + " and month(OendTime) =" + month + " and day(OendTime)=" + day + " group by year(OendTime),month(OendTime),day(OendTime)");
            if (db != null)
            {
                int i = int.Parse(db.ToString());
                return i;
            }
            else
            {
                return 0;
            }


        }

        /// <summary>
        /// 当天下单量
        /// </summary>
        /// <returns></returns>
        [Route("GetOrdersCountByDay")]
        [HttpGet]
        public int GetOrdersCountByDay()
        {
            var time = DateTime.Now;
            var year = time.Year;
            var month = time.Month; ;
            var day = time.Day;
            var db = DBHelper.ExecuteScalar("select count(1) Count from orders where  YEAR(OStartTime)=" + year + " and month(OStartTime) =" + month + " and day(OStartTime)=" + day + " group by year(OStartTime),month(OStartTime),day(OStartTime)");
            if (db != null)
            {
                int i = int.Parse(db.ToString());
                return i;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 本月下单量
        /// </summary>
        /// <returns></returns>
        [Route("GetOrdersCountByMonth")]
        [HttpGet]
        public int GetOrdersCountByMonth()
        {
            var time = DateTime.Now;
            var year = time.Year;
            var month = time.Month; ;
            var db = DBHelper.ExecuteScalar("select count(1) Count  from orders where YEAR(OStartTime)=" + year + " and month(OStartTime) =" + month + " group by year(OStartTime),month(OStartTime)");
            if (db != null)
            {
                int i = int.Parse(db.ToString());
                return i;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 本月成交量
        /// </summary>
        /// <returns></returns>
        [Route("GetSuccessCountByMonth")]
        [HttpGet]
        public int GetSuccessCountByMonth()
        {
            var time = DateTime.Now;
            var year = time.Year;
            var month = time.Month; ;
            var db = DBHelper.ExecuteScalar("select count(1) Count  from orders where YEAR(OendTime)=" + year + " and month(OendTime) =" + month + "  group by year(OendTime),month(OendTime)");
            if (db != null)
            {
                int i = int.Parse(db.ToString());
                return i;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 本月成交额
        /// </summary>
        /// <returns></returns>
        [Route("GetOrdersMoneyByMonth")]
        [HttpGet]
        public decimal GetOrdersMoneyByMonth()
        {
            var time = DateTime.Now;
            var year = time.Year;
            var month = time.Month; ;
            List<Orders> i = DBHelper.GetList<Orders>("select sum(Omoney) Omoney from orders where Ostate='已完成' and YEAR(OendTime)=" + year + " and month(OendTime) =" + month + " group by year(OendTime),month(OendTime)");
            if (i.Count > 0)
            {
                Orders orders = i[0];
                decimal f = orders.Omoney;

                return f;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 订单列表(按时间从晚到早排序)
        /// </summary>
        /// <returns></returns>
        [Route("OrderListByTime")]
        [HttpGet]
        public List<Orders> OrderListByTime()
        {
            List<Orders> orders = DBHelper.GetList<Orders>("select top(20) *from Orders order by OStartTime desc");
            return orders;
        }


    }
}