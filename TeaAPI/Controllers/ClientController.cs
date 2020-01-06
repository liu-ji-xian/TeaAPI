using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeaAPI.Model;

namespace TeaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        public TeaContext db;
        public ClientController(TeaContext db) { this.db = db; }

        #region 显示客户订单
        /// <summary>
        /// 显示客户订单
        /// </summary>

        [HttpGet]
        [Route("SelOrder")]
        public async Task<List<Orders>> SelOrder(string id)
        {
            var linq = from u in db.Orders
                       where u.ONo==id
                       select u;
            return await linq.ToListAsync();
        }

        [HttpGet]
        [Route("SelOrders")]
        public async Task<List<Orders>> SelOrders()
        {
            var linq = from u in db.Orders
                       select u;
            return await linq.ToListAsync();
        }

        #endregion

        #region 显示客户订单
        /// <summary>
        /// 显示客户订单
        /// </summary>

        [HttpGet]
        [Route("OrdersInfo")]
        public  Object OrdersInfo(string id)
        {
                var linq = from o in db.OrderInfo
                           join g in db.Goods on o.GNos equals g.GNo
                           where o.OINode == id
                           select new
                           {
                               o.OINode,
                               o.GNos,
                               o.GNum,
                               g.GoodsPicture,
                               g.GName,
                               g.GRemark,
                               g.GState,
                           };
                return linq.ToList();   

        }

        #endregion


    }
}