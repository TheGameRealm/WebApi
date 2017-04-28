using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs
{
    public partial class ConfigDTO
    {
        public int ConfigId { get; set; }
        public string Key { get; set; }
        public string Group { get; set; }
        public string Value { get; set; }
    }
}
