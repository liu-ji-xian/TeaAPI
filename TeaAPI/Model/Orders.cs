using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaAPI.Model
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class Orders
    {
        /// <summary>
        /// 订单主键
        /// </summary>
        [Key]
        public int OId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string ONo { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string OName { get; set; }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string OPhone { get; set; }
        /// <summary>
        /// 收货人地址
        /// </summary>
        public string Oaddress { get; set; }
        /// <summary>
        /// 下单账号
        /// </summary>
        public string UIds { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OStartTime { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime OendTime { get; set; }
        /// <summary>
        /// 订单状态(已提交，代发货，运输中，待收货，已完成)
        /// </summary>
        public string Ostate { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal Omoney { get; set; }
    }
}
