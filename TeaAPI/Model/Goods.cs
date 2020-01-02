using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaAPI.Model
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int GId { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string GNo { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string GoodsPicture { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GName { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public float GPrice { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public int GNum { get; set; }
        /// <summary>
        /// 商品备注
        /// </summary>
        public string GRemark { get; set; }
        /// <summary>
        /// 商品类型
        /// </summary>
        public int GType { get; set; }
        /// <summary>
        /// 商品状态
        /// </summary>
        public string GState { get; set; }
    }
}
