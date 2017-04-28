using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Alexa
{
    public partial class AlexaAccountDTO
    {
        public AlexaAccountDTO()
        {
            //this.Requests = new List<AlexaRequestDTO>();
            //this.Players = new List<PlayerDTO>();
        }

        public Guid AccountId { get; set; }
        public string AlexaUserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastRequest { get; set; }
        public int RequestCount { get; set; }
        

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public IList<AlexaRequestDTO> Requests { get; set; }
        //public IList<PlayerDTO> Players { get; set; }
    }
}
