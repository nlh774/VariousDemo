using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF6Model
{
    [Table("TCBaseMessage")]
    public class MessageContract
    {
        /// <summary>
        /// 消息主键
        /// </summary>
        [Key]
        [Column("MID")]
        public long MessageId { get; set; }

        /// <summary>
        /// 系统ID
        /// </summary>
        [Column("MAID")]
        [Required]
        public long AccountId { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        [Column("mTitle")]
        [StringLength(256)]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Column("mContent")]
        public string Content { get; set; }

        /// <summary>
        /// 归属账号
        /// </summary>
        public virtual AccountContract Account { get; set; }
    }
}
