using Common.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public partial class MapDTO
    {
        public MapDTO()
        {
            this.MapId = Guid.Empty;
            this.Name = StaticText.Void;
            this.Description = StaticText.Nothing;
            this.Level = 0;

            this.CellsDTO = new List<CellDTO>();
        }

        public Guid MapId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public List<CellDTO> CellsDTO { get; set; }
    }
}
