using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EF6Model
{
    public class UserContract
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public long AccountId { get; set; }

        public string Name { get; set; }

        public string CardId { get; set; }

        public string Password { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
