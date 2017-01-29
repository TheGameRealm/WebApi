using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class PlayerDTO : DTOBase
    {
        public PlayerDTO()
        {
            this.PlayerGuid = Guid.Empty;
            this.Name = string.Empty;
            this.MapGuid = Guid.Empty;
        }

        public Guid PlayerGuid { get; set; }
        public string Name { get; set; }
        public Guid MapGuid { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
    }
}
