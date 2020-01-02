using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaAPI.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Users
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int UId { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UNo { get; set; }
        /// <summary>
        /// 昵称(微信号)
        /// </summary>
        public string UName { get; set; }
        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string URealName { get; set; }
        /// <summary>
        /// 用户生日
        /// </summary>
        public DateTime Ubirthday { get; set; }
        /// <summary>
        /// 用户类别
        /// </summary>
        public string UType { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UPass { get; set; }
        /// <summary>
        /// 收货姓名
        /// </summary>
        public string ConsigneeName { get; set; }
        /// <summary>
        /// 收货电话
        /// </summary>
        public string ConsigneePhone { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string ConsigneeAddress { get; set; }
    }
}
