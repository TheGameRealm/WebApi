using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Alexa
{
    public partial class AlexaMemberDTO
    {
        public AlexaMemberDTO()
        {
            this.Requests = new List<AlexaRequestDTO>();
        }

        public int Id { get; set; }
        public string AlexaUserId { get; set; }
        public int RequestCount { get; set; }
        public System.DateTime LastRequestDate { get; set; }
        public System.DateTime CreatedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlexaRequestDTO> Requests { get; set; }
    }
}
