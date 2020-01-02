using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaAPI.Model
{
    /// <summary>
    /// 订单详情表
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// 订单详情主键
        /// </summary>
        [Key]
        public int OIId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OINode { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string GNos { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int GNum { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Gremark { get; set; }
    }
}
