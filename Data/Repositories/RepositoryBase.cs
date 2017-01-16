using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class RepositoryBase
    {
        protected RealmContext Context { get; set; }

        public RepositoryBase(RealmContext context)
        {
            this.Context = context;
        }

    }
}
