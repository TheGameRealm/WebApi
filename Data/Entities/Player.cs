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
    [MapsTo(typeof(PlayerDTO), ReverseMap = true)]
    public class Player : EntityBase
    {
        public Player()
        {
            this.PlayerGuid = Guid.Empty;
            this.Name = string.Empty;
            this.MapGuid = Guid.Empty;
            this.User = new AspNetUser();
        }
        
        [Key]
        public Guid PlayerGuid { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        public Guid MapGuid { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public AspNetUser User { get; set; }
    }
}
