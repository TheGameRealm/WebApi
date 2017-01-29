﻿using AutoMapper.Attributes;
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
    [MapsTo(typeof(UserRoleDTO), ReverseMap = true)]
    public partial class AspNetUserRole : EntityBase
    {
        public AspNetUserRole()
        {
            this.User = new AspNetUser();
            this.Role = new AspNetRole();
        }

        [Key, Column(Order = 1), StringLength(128)]
        public string UserId { get; set; }
        [Key, Column(Order = 2), StringLength(128)]
        public string RoleId { get; set; }

        public AspNetUser User { get; set; }
        public AspNetRole Role { get; set; }
    }
}
