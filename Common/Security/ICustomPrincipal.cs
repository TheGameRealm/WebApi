using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Common.Security
{
    public interface ICustomPrincipal
    {
        IIdentity Identity { get; }
        List<string> Roles { get; set; }
        bool IsInRole(string role);

        Guid AccountId { get; set; }
        Guid PlayerId { get; set; }
    }
}