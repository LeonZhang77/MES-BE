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
    [Entity(TableCnName = "完工单",TableName = "Production_OverWorkOrder",DBServer = "SysDbContext")]
    public partial class Production_OverWorkOrder:SysEntity
    {
        /// <summary>
       ///完工单主键ID
       /// </summary>
       [Key]
       [Display(Name ="完工单主键ID")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int OverWorkOrder_Id { get; set; }

       /// <summary>
       ///工单
       /// </summary>
       [Display(Name ="工单")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int WorkOrder_Id { get; set; }

        /// <summary>
        ///审批状态
        /// </summary>
        [Display(Name = "审批状态")]
        [Column(TypeName = "int")]
        [Editable(true)]
        [Required(AllowEmptyStrings = false)]
        public int Status { get; set; }
        
       /// <summary>
       ///工单编号
       /// </summary>
       [Display(Name ="工单编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string WorkOrderCode { get; set; }

        /// <summary>
        ///审批时间
        /// </summary>
        [Display(Name = "审批时间")]
        [Column(TypeName = "datetime")]
        public DateTime? ApproverDate { get; set; }

        /// <summary>
        ///审批人
        /// </summary>
        [Display(Name = "审批人")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string ApproverUserName { get; set; }

        /// <summary>
        ///工序
        /// </summary>
        [Display(Name ="工序")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int Process_Id { get; set; }

       /// <summary>
       ///工序名称
       /// </summary>
       [Display(Name ="工序名称")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProcessName { get; set; }

       /// <summary>
       ///工序编号
       /// </summary>
       [Display(Name ="工序编号")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public string ProcessCode { get; set; }

       /// <summary>
       ///工艺路线ID
       /// </summary>
       [Display(Name ="工艺路线ID")]
       [Column(TypeName="int")]
       [Editable(true)]
       [Required(AllowEmptyStrings=false)]
       public int ProcessLine_Id { get; set; }

       /// <summary>
       ///创建时间
       /// </summary>
       [Display(Name ="创建时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? CreateDate { get; set; }

       /// <summary>
       ///创建人编号
       /// </summary>
       [Display(Name ="创建人编号")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? CreateID { get; set; }

       /// <summary>
       ///创建人
       /// </summary>
       [Display(Name ="创建人")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string Creator { get; set; }

       /// <summary>
       ///修改人
       /// </summary>
       [Display(Name ="修改人")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       [Editable(true)]
       public string Modifier { get; set; }

       /// <summary>
       ///修改时间
       /// </summary>
       [Display(Name ="修改时间")]
       [Column(TypeName="datetime")]
       [Editable(true)]
       public DateTime? ModifyDate { get; set; }

       /// <summary>
       ///修改人编号
       /// </summary>
       [Display(Name ="修改人编号")]
       [Column(TypeName="int")]
       [Editable(true)]
       public int? ModifyID { get; set; }

       
    }
}