using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public partial class AspNetRole : EntityBase
    {
        public AspNetRole()
        {

        }

        [Key, MaxLength(128)]
        public string Id { get; set; }
        [MaxLength(256), Required]
        public string Name { get; set; }

    }
}
