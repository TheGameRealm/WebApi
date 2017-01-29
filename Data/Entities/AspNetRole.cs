using AutoMapper.Attributes;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [MapsTo(typeof(RoleDTO), ReverseMap = true)]
    public partial class AspNetRole : EntityBase
    {
        public AspNetRole()
        {

        }

        [Key, StringLength(128)]
        public string Id { get; set; }
        [StringLength(256), Required]
        public string Name { get; set; }

    }
}
