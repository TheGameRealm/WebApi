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
    [MapsTo(typeof(MapDTO), ReverseMap = true)]
    public partial class Map : EntityBase
    {
        public Map()
        {
            this.MapGuid = Guid.Empty;
            this.Name = StaticText.Void;
            this.Description = StaticText.Nothing;

            this.Cells = new List<Cell>();
        }

        [Key]
        public Guid MapGuid { get; set; }
        [StringLength(128), Required]
        public string Name { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        public int Level { get; set; }

        public virtual ICollection<Cell> Cells { get; set; }
    }
}
