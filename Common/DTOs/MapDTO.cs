using Common.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class MapDTO : DTOBase
    {
        public MapDTO()
        {
            this.MapGuid = Guid.Empty;
            this.Name = StaticText.Void;
            this.Description = StaticText.Nothing;
            this.Level = 1;

            this.CellsDTO = new List<CellDTO>();
        }

        public Guid MapGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<CellDTO> CellsDTO { get; set; }
    }
}
