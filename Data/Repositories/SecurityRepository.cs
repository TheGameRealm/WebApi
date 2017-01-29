using Common.DTOs;
using Data.Entities;
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

        public UserDTO GetUser(string userId)
        {
            var result = base.Context.AspNetUsers.SingleOrDefault(o => o.Id == userId) ?? new AspNetUser();

            return AutoMapper.Mapper.Map<UserDTO>(result);
        }

    }
}
