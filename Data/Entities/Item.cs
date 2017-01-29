using AutoMapper.Attributes;
using Common.DTOs;
using Common.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [MapsTo(typeof(ItemDTO), ReverseMap = true)]
    public class Item : EntityBase
    {
        public Item()
        {
            this.ItemGuid = Guid.Empty;
            this.Name = nameof(StaticText.Rock);
            this.Description = StaticText.Rock;
            this.isWeapon = false;
            this.isUsable = false;
            this.Weight = 1;
        }

        [Key]
        public Guid ItemGuid { get; set; }
        [StringLength(128), Required]
        public string Name { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        public bool isWeapon { get; set; }
        public bool isUsable { get; set; }
        public int Weight { get; set; }
    }
}
