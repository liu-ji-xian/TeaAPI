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
        public async Task<object> ShowGoods(string name="")
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
                           a.GType,
                           a.GState
                       };
            return await linq.ToListAsync();
        }
        /// <summary>
        /// 添加一个商品信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddGoods")]
        public async Task<ActionResult<int>> AddGoods(Goods g)
        {
            string datenum = string.Empty;//记录编号（设置一个初始值）
            var countnum = (from d in db.Goods select d.GNo).Count();///先求出表中的记录编号的数量
            if (countnum == 0)//如果表中的记录编号的数量为0，就是这是个新表，还没有数据
            {
                datenum = DateTime.Now.ToString("yyyyMMdd") + "000001";//将要产生的记录编号
            }
            else
            {
                var maxtnum = (from d in db.Goods select d.GNo).Max();//如果表中数量不为0，求出表中的记录编号的最大值

                //截取表中的记录编号的最大值的前8位（注：前8位位4位年，两位月，两位日）如201908012

                var feignum = maxtnum.Substring(0, 8);//表中的记录编号的最大值的前8位

                var todate = DateTime.Now.ToString("yyyyMMdd");//今日日期的字符串

                if (feignum != todate)//如果表中的记录编号的最大值的前8位与今日日期的字符串不相等
                {
                    datenum = DateTime.Now.ToString("yyyyMMdd") + "000001";//说明将要产生的记录编号是今天的第一个记录编号
                }
                else//否则表中的记录编号的最大值的前8位与今日日期的字符串相等
                {
                    //截取最大记录编号的六位流水号，比对流水号的值
                    var sixstr = maxtnum.Substring(maxtnum.Length - 6, 6); //最大记录编号的六位流水号

                    var intsix = Convert.ToInt32(sixstr);//将最大记录编号的六位流水号转为数字类型

                    //表中的记录编号的最大值的前8位与今日日期的字符串相等说明至少今日有一笔数据
                    var intnext = intsix + 1;//将要产生的记录编号六位流水号的值是：最大记录编号的六位流水号+1

                    if (intnext < 10)//如果将要产生的记录编号六位流水号的值<10
                    {
                        datenum = todate + "00000" + Convert.ToString(intnext);//记录编号为：5个0拼接要产生的记录编号六位流水号的字符串
                    }
                    if (intnext >= 10 && intnext < 100)//如果将要产生的记录编号六位流水号的值>= 10而且< 100
                    {
                        datenum = todate + "0000" + Convert.ToString(intnext);////记录编号为：4个0拼接要产生的记录编号六位流水号的字符串
                    }
                    if (intnext >= 100 && intnext < 1000)//如果将要产生的记录编号六位流水号的值>= 100而且< 1000
                    {
                        datenum = todate + "000" + Convert.ToString(intnext);////记录编号为：3个0拼接要产生的记录编号六位流水号的字符串
                    }
                    if (intnext >= 1000 && intnext < 10000)//如果将要产生的记录编号六位流水号的值>= 1000而且< 10000
                    {
                        datenum = todate + "00" + Convert.ToString(intnext);////记录编号为：2个0拼接要产生的记录编号六位流水号的字符串
                    }
                    if (intnext >= 10000 && intnext < 100000)//如果将要产生的记录编号六位流水号的值>= 10000而且< 100000
                    {
                        datenum = todate + "0" + Convert.ToString(intnext);////记录编号为：1个0拼接要产生的记录编号六位流水号的字符串
                    }
                    if (intnext >= 100000 && intnext < 1000000)//如果将要产生的记录编号六位流水号的值>= 100000而且< 1000000
                    {
                        datenum = todate + Convert.ToString(intnext);////记录编号为：1个0拼接要产生的记录编号六位流水号的字符串
                    }
                }
            }
            g.GNo = datenum;
            db.Goods.Add(g);
            return await db.SaveChangesAsync();
        }

        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UPGoods")]
        public async Task<ActionResult<int>>UPGoods(Goods g)
        {
            db.Entry(g).State = EntityState.Modified;
            int result = await db.SaveChangesAsync();
            db.Entry(g).State = EntityState.Deleted;
            return result;
        }

        //[HttpGet]
        //[Route("UpGStateThree")]
        //[Obsolete]
        //public async Task<IActionResult> UpGStateThree()
        //{
        //    int i= db.Database.ExecuteSqlCommand(string.Format($"update Goods where State='停用'"));
        //    return NoContent();

        //}

    }
}