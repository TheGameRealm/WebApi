using Common.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public partial class InventoryDTO
    {
        public InventoryDTO()
        {
            this.ItemRefId = Guid.Empty;
            this.UniqueId = Guid.Empty;
        }

        public System.Guid InventoryId { get; set; }
        public System.Guid PlayerRefId { get; set; }
        public System.Guid ItemRefId { get; set; }
        public System.Guid? UniqueId { get; set; }
          
    }
}
