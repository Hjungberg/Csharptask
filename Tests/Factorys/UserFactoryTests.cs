
using Biz.Dtos;
using Biz.Factorys;
using Biz.Models;

namespace Tests.Factorys;

public class UserFactoryTests
{   
    [Fact]
    public void Create_ShoudReturnURF()
    {
        var result = UserFactory.Create();
        Assert.NotNull(result);
        Assert.IsType<UserRegForm>(result);
    }

    [Fact]
    public void Create_ShoudUser_WhenURFIsProvided()
    {
        var userRegForm = new UserRegForm()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "email@domain.com",
            Phone = "Phone",
            Address = "Address",
            PostCode = "PostCode",
            City = "City",
        };


        var result = UserFactory.Create(userRegForm);
        Assert.NotNull(result);
        Assert.IsType<User>(result);
        Assert.Equal(userRegForm.FirstName, result.FirstName);
        Assert.Equal(userRegForm.LastName, result.LastName);
        Assert.Equal(userRegForm.Address, result.Address);
        Assert.Equal(userRegForm.PostCode, result.PostCode);
        Assert.Equal(userRegForm.City, result.City);
        Assert.Equal(userRegForm.Email, result.Email);
        Assert.Equal(userRegForm.Phone, result.Phone);
    }

}
