using Common.DTOs;
using Data.Entities;

namespace Data.Repositories
{
    public interface ISecurityRepository
    {
        UserDTO GetUser(string userId);
    }
}