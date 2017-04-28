namespace Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DTOs;

    public class IntentModel
    {
        public IntentModel()
        {
            this.Response = new AlexaResponseModel();
            this.Output = new StringBuilder();
            this.Player = new PlayerDTO();
            this.Map = new MapDTO();
            this.Cell = new CellDTO();
        }

        public AlexaRequestModel Request { get; set; }

        public AlexaResponseModel Response { get; set; }

        public StringBuilder Output { get; set; }

        public PlayerDTO Player { get; set; }

        public MapDTO Map { get; set; }

        public CellDTO Cell { get; set; }

    }
}
