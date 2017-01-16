using Common.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public partial class Map : EntityBase
    {
        public Map()
        {
            this.MapGuid = Guid.Empty;
            this.Name = StaticText.Void;
            this.Description = StaticText.Nothing;
            this.isHositle = false;

            this.Cells = new List<Cell>();
        }

        [Key]
        public Guid MapGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public bool isHositle { get; set; }

        public virtual ICollection<Cell> Cells { get; set; }
    }
}
