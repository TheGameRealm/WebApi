using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public partial class AspNetUserLogin : EntityBase
    {
        public AspNetUserLogin()
        {
            this.User = new AspNetUser();
        }

        [Key, MaxLength(128), Required]
        public string UserId { get; set; }
        [MaxLength(128), Required]
        public string LoginProvider { get; set; }
        [MaxLength(128), Required]
        public string ProviderKey { get; set;  }
        
        public AspNetUser User { get; set; }
    }
}
