using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace EF6Model
{
    [Table("TCBaseAccount")]
    public class AccountContract
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Column("AID")]
        public long AccountId { get; set; }

        /// <summary>
        /// 账号标识
        /// </summary>
        [Column("aKey")]
        [StringLength(256)]
        public string Key { get; set; }

        /// <summary>
        /// 账号所属的消息集合
        /// </summary>
        public virtual ICollection<MessageContract> Messages { get; set; }
    }
}
