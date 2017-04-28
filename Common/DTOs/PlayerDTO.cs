using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs.Alexa;
using Common.Enums;

namespace Common.DTOs
{
    public partial class PlayerDTO
    {
        public PlayerDTO()
        {
            this.PlayerId = Guid.Empty;
            this.Name = string.Empty;
            this.MapRefId = Guid.Empty;

            this.Inventories = new List<InventoryDTO>();
        }

        public Guid PlayerId { get; set; }
        public string Name { get; set; }

        public Guid MapRefId { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }

        public Verbosity Verbosity { get; set; }

        public int Level { get; set; }
        public int Gold { get; set; }

        public int Toughness { get; set; }
        public int Energy { get; set; }
        public Guid AccountRefId { get; set; }

        public List<InventoryDTO> Inventories { get; set; }
        public virtual AlexaAccountDTO AlexaAccount { get; set; }
        public virtual MapDTO Map { get; set; }

    }
}
