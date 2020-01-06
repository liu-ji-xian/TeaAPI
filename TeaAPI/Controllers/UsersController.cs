using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeaAPI.Model;

namespace TeaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[EnableCors("cors")]//设置跨域处理的代理
    public class UsersController : ControllerBase
    {
        public TeaContext db;
        public UsersController(TeaContext db) { this.db = db; }

        /// <summary>
        /// 管理员显示用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsers")]
        public async Task<object> GetUsers(string name)
        {
            if (name != null)
            {
                var linq = from a in db.Users
                           where a.URealName.Contains(name)
                           select new
                           {
                               a.UNo,
                               a.UName,
                               a.URealName,
                               a.Ubirthday,
                               a.UType,
                               a.ConsigneeName,
                               a.ConsigneePhone,
                               a.ConsigneeAddress
                           };
                return await linq.ToListAsync();
            }
            else
            {
                var linq = from a in db.Users
                           where a.UType=="普通用户"
                           select new
                           {
                               a.UNo,
                               a.UName,
                               a.URealName,
                               a.Ubirthday,
                               a.UType,
                               a.ConsigneeName,
                               a.ConsigneePhone,
                               a.ConsigneeAddress
                           };
                return await linq.ToListAsync();
            }
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Addusers")]
        public async Task<ActionResult<int>> Addusers(Users s)
        {
            db.Users.Add(s);
            return await db.SaveChangesAsync();
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUsers")]
        public async Task<ActionResult<int>> UpdateUsers(Users u)
        {
            db.Entry(u).State = EntityState.Modified;
            int result = await db.SaveChangesAsync();
            db.Entry(u).State = EntityState.Deleted;
            return result;
        }

        /// <summary>
        /// 返填用户信息
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpGet("FanTian")]
        public async Task<object> FanTian(int id)
        {
            var linq = from a in db.Users
                       where a.UId == id
                       select new
                       {
                           a.UNo,
                           a.UName,
                           a.URealName,
                           a.Ubirthday,
                           a.UType,
                           a.ConsigneeName,
                           a.ConsigneePhone,
                           a.ConsigneeAddress
                       };
            return await linq.ToListAsync();
        }

        ///// <summary>
        ///// 注册
        ///// </summary>
        ///// <param name="em"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("enroll")]
        //public async Task<ActionResult<int>> Enroll(Users u)
        //{
        //    db.Users.Add(u);
        //    return await db.SaveChangesAsync();

        //}

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpGet]
        public async Task<ActionResult<Users>> Login(string UNo, string UPass)
        {
            return await db.Users.FirstOrDefaultAsync(e => e.UNo.Equals(UNo) && e.UPass.Equals(UPass));
        }
    }
}