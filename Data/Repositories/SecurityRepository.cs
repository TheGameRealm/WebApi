using Common.Entities;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SecurityRepository : RepositoryBase, ISecurityRepository
    {
        public SecurityRepository(RealmContext context) : base(context)
        {

        }

        public AspNetUser GetUser(string userId)
        {
            return base.Context.AspNetUsers.SingleOrDefault(o => o.Id == userId) ?? new AspNetUser();
        }

    }
}
