/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iMES.Entity.SystemModels;

namespace iMES.Entity.DomainModels
{
    [Entity(TableCnName = "人员绩效考核",TableName = "View_SalaryReportCover",DBServer = "SysDbContext")]
    public partial class View_SalaryReportCover:SysEntity
    {
        /// <summary>
       ///
       /// </summary>
       [Key]
       [Display(Name ="ID")]
       [Column(TypeName="uniqueidentifier")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public Guid ID { get; set; }

        /// <summary>
        ///报工时间
        /// </summary>
        [Display(Name = "报工时间")]
        [Column(TypeName = "varchar")]
        public DateTime? ReportDate { get; set; }


        /// <summary>
        ///生产人员
        /// </summary>
        [Display(Name ="生产人员")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProductUser { get; set; }

       /// <summary>
       ///账号
       /// </summary>
       [Display(Name ="账号")]
       [MaxLength(100)]
       [Column(TypeName="nvarchar(100)")]
       [Editable(true)]
       public string UserName { get; set; }

       /// <summary>
       ///姓名
       /// </summary>
       [Display(Name ="姓名")]
       [MaxLength(20)]
       [Column(TypeName="nvarchar(20)")]
       [Editable(true)]
       public string UserTrueName { get; set; }

       /// <summary>
       ///完成率
       /// </summary>
       [Display(Name ="完成率")]
       [MaxLength(101)]
       [Column(TypeName="varchar(101)")]
       [Editable(true)]
       public string OverPercent { get; set; }

       /// <summary>
       ///损耗率
       /// </summary>
       [Display(Name ="损耗率")]
       [MaxLength(101)]
       [Column(TypeName="varchar(101)")]
       [Editable(true)]
       public string NoOverPercent { get; set; }

       /// <summary>
       ///应奖
       /// </summary>
       [Display(Name ="应奖")]
       [DisplayFormat(DataFormatString="20,3")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? Award { get; set; }

       /// <summary>
       ///应罚
       /// </summary>
       [Display(Name ="应罚")]
       [DisplayFormat(DataFormatString="20,3")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? Penalty { get; set; }

       /// <summary>
       ///单价
       /// </summary>
       [Display(Name ="单价")]
       [DisplayFormat(DataFormatString="20,3")]
       [Column(TypeName="decimal")]
       [Editable(true)]
       public decimal? UnitPrice { get; set; }

       
    }
}