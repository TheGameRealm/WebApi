using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public partial class AspNetUserClaim : EntityBase
    {
        public AspNetUserClaim()
        {
            this.User = new AspNetUser();
        }

        [Key]
        public int Id { get; set; }
        [MaxLength(128), Required]
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public AspNetUser User { get; set; }
    }
}
