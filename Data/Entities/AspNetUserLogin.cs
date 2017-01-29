using AutoMapper.Attributes;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [MapsTo(typeof(UserLoginDTO), ReverseMap = true)]
    public partial class AspNetUserLogin : EntityBase
    {
        public AspNetUserLogin()
        {
            this.User = new AspNetUser();
        }

        [Key, StringLength(128)]
        public string UserId { get; set; }
        [StringLength(128), Required]
        public string LoginProvider { get; set; }
        [StringLength(128), Required]
        public string ProviderKey { get; set;  }
        
        public AspNetUser User { get; set; }
    }
}
