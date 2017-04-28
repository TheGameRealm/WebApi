using Common.Enums;
using Common.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public partial class CellDTO
    {
        public CellDTO()
        {
            this.CellId = Guid.Empty;
            this.Description = StaticText.Nothing;
            this.Directions = Directions.None;
            this.PathDescription = StaticText.DefaultPathDescription;
            this.PortalDirections = Directions.None;

            this.CellItems = new List<CellItemDTO>();
        }

        public Guid CellId { get; set; }
        public string Description { get; set; }
        public Guid? MapRefId { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public Directions Directions { get; set; }

        private string pathDescription;
        public string PathDescription
        {
            get
            {
                return !string.IsNullOrEmpty(this.pathDescription)
                    ? this.pathDescription : StaticText.DefaultPathDescription;
            }
            set
            {
                this.pathDescription = value;
            }
        }
        public Directions? PortalDirections { get; set; }
        public Guid? GotoMapRefId { get; set; }
        public int? GotoX { get; set; }
        public int? GotoY { get; set; }

        public MapDTO GotoMapRef { get; set; }
        public MapDTO MapRef { get; set; }

        public List<CellItemDTO> CellItems { get; set; }
        
    }
}
