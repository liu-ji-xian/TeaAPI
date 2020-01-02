using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaAPI.Model
{
    /// <summary>
    /// 商品类型
    /// </summary>
    public class GoodsType
    {
        /// <summary>
        /// 商品主键
        /// </summary>
        [Key]
        public int GTId { get; set; }
        /// <summary>
        /// 商品类别名称
        /// </summary>
        public string GTName { get; set; }
    }
}
