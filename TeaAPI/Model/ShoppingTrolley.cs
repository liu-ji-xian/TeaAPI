using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaAPI.Model
{

    /// <summary>
    /// 购物车表
    /// </summary>
    public class ShoppingTrolley
    {
        /// <summary>
        /// 购物车主键
        /// </summary>
        [Key]
        public int SIId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int GTNum { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string GNos { get; set; }
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UNos { get; set; }
    }
}
