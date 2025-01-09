
using Biz.Dtos;
using Biz.Helpers;
using Biz.Models;

namespace Biz.Factorys;

public static class UserFactory
{
    public static UserRegForm Create() => new();

    public static User Create(UserRegForm form) => new()
    {
        Id = IdGen.Generate(),
        FirstName = form.FirstName,
        LastName = form.LastName,   
        Email = form.Email,
        Phone = form.Phone,
        Address = form.Address,
        PostCode = form.PostCode,
        City = form.City,
         
    };
}
