using Common.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Attributes;

namespace Common.DTOs
{
    public partial class CellItemDTO
    {
        public CellItemDTO()
        {
            this.CellItemId = Guid.Empty;
            this.UniqueId = Guid.Empty;
        }

        public System.Guid CellItemId { get; set; }
        public System.Guid CellRefId { get; set; }
        public System.Guid ItemRefId { get; set; }
        public System.Guid? UniqueId { get; set; }

    }
}
