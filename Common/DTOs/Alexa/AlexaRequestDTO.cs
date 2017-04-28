using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Alexa
{
    public partial class AlexaRequestDTO
    {
        public int Id { get; set; }
        public string RequestId { get; set; }
        public string SessionId { get; set; }
        public string UserId { get; set; }

        public DateTime Timestamp { get; set; }
        public string Intent { get; set; }
        public List<KeyValuePair<string, string>> Slots { get; set; }
        public bool IsNew { get; set; }
        public string Version { get; set; }
        public string Type { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid AccountRefId { get; set; }
    }
}
