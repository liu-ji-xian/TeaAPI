using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeaAPI.Model
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 菜单主键
        /// </summary>
        [Key]
        public int Mid { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string MUrl { get; set; }
    }
}
