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
    public class GoodsController : ControllerBase
    {
        public TeaContext db;
        public GoodsController(TeaContext db) { this.db = db; }
        /// <summary>
        /// 管理员显示商品列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ShowGoods")]
        public async Task<object> ShowGoods(string name = "")
        {
            var linq = from a in db.Goods
                       where a.GName.Contains(name)
                       select new
                       {
                           a.GNo,
                           a.GoodsPicture,
                           a.GName,
                           a.GPrice,
                           a.GNum,
                           a.GRemark,
                           a.GState
                       };
            return await linq.ToListAsync();
        }


        /// <summary>
        /// 获取前六条数据
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("Shows")]
        //public async Task<object> Shows()
        //{
        //    var linq = (from a in db.Goods
        //                select a).Take(6);           
        //    return await linq.ToListAsync();
        //}

        #region Dapper
        //Dapper连接数据库查询前6条数据
        [HttpGet]
        [Route("Shows")]
        public List<Goods> TopShow()
        {
            return DapperHelper<Goods>.Query("select top(6) * from Goods");
        }



        #endregion





        /// <summary>
        /// 添加一个商品信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddGoods")]
        public int AddGoods(Goods g)
        {
            string sql = $"Pro_AddGoods {g.GoodsPicture},{g.GName},'{g.GPrice}','{g.GNum}','{g.GRemark}','{g.GState}'";
            return DBHelper.ExecuteNonQuery(sql);

        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UPGoods")]
        public int UPGoods(Goods g, string id)
        {
            string sql = $"update Goods set GoodsPicture='{g.GoodsPicture}',GName='{g.GName}',GPrice='{g.GPrice}',GNum='{g.GNum}',GRemark='{g.GRemark}',GState='{g.GState}' where GNo='{id}'";
            return DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 修改为上架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UPStateOne")]
        public int UPStateOne(string id)
        {
            string sql = $"update Goods set GState='上架' where GNo='{id}'";
            return DBHelper.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 修改为下架
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("UPStateTwo")]
        public int UpStateTwo(string id)
        {
            string sql = $"update Goods set GState='下架' where GNo='{id}'";
            return DBHelper.ExecuteNonQuery(sql);
        }






    }
}