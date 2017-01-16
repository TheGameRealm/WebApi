using Common.Entities;

namespace Data.Repositories
{
    public interface ISecurityRepository
    {
        AspNetUser GetUser(string userId);
    }
}