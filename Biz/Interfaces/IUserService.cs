using Biz.Dtos;
using Biz.Models;

namespace Biz.Interfaces;

public interface IUserService
{
    bool Save(UserRegForm form);
    IEnumerable<User> GetAll();
}