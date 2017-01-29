﻿using Common.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public class CellDTO : DTOBase
    {
        public CellDTO()
        {
            this.CellGuid = Guid.Empty;
            this.Description = StaticText.Nothing;
            this.isHostile = false;
            this.hasPortal = false;
            this.PortalDescription = string.Empty;
            this.canGoEast = false;
            this.canGoNorth = false;
            this.canGoSouth = false;
            this.canGoWest = false;
        }

        public Guid CellGuid { get; set; }
        public MapDTO MapDTO { get; set; }
        public string Description { get; set; }
        public bool isHostile { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public bool hasPortal { get; set; }
        public string PortalDescription { get; set; }
        public Guid? GotoMap { get; set; }
        public int? GotoX { get; set; }
        public int? GotoY { get; set; }
        public bool canGoEast { get; set; }
        public bool canGoNorth { get; set; }
        public bool canGoSouth { get; set; }
        public bool canGoWest { get; set; }
    }
}
