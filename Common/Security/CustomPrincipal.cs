using Common.DTOs;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    public class CustomPrincipal : IPrincipal, ICustomPrincipal
    {
        private readonly string name;

        public CustomPrincipal(string name)
        {
            this.name = name;
            this.Roles = new List<string>();
        }

        public IIdentity Identity
        {
            get
            {
                return new GenericIdentity(this.name);
            }
        }

        public bool IsInRole(string role)
        {
            return this.Roles.Any(o => o == role);
        }

        public List<string> Roles { get; set; }

        public Guid AccountId { get; set; }
        
        public Guid PlayerId { get; set; }
    }
}
