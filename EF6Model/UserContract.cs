using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF6Model
{
    [Table("TCBaseUser")]
    public class UserContract
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        public string CardId { get; set; }

        public string Password { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
