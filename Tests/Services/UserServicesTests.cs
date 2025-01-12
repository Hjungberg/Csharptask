

using Biz.Dtos;
using Biz.Interfaces;
using Biz.Models;
using Biz.Services;
using Moq;
using System.Text.Json;

namespace Tests.Services;

public class UserServicesTests
{
    private readonly Mock<IFileService> _fileServieMock;
    private readonly IUserService _userService;

    public UserServicesTests()
    {
        _fileServieMock = new Mock<IFileService>();
        _userService = new UserService(_fileServieMock.Object);
    }

    [Fact]
    public void Save_ShoudAddUserToListAndSaveAndReturnTrue()
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

        _fileServieMock.Setup(x => x.SaveContentToFile(It.IsAny<string>())).Returns(true);



        var result = _userService.Save(userRegForm);
        Assert.True(result);
        _fileServieMock.Verify(x => x.SaveContentToFile(It.IsAny<string>()), Times.Once);  
        
    }
    [Fact]

    public void GetAll_ShoudReturnListOfUsers()
    {

        List<User> expected = [ new User {
            Id = "0",
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "email@domain.com",
            Phone = "Phone",
            Address = "Address",
            PostCode = "PostCode",
            City = "City", }];
        var json = JsonSerializer.Serialize(expected);

        _fileServieMock.Setup(x => x.GetContentFromFile()).Returns(json);

        var result = _userService.GetAll();

        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(expected[0].Id, result.First().Id);
        Assert.Equal(expected[0].FirstName, result.First().FirstName);
        Assert.Equal(expected[0].LastName, result.First().LastName);
        Assert.Equal(expected[0].Address, result.First().Address);
        Assert.Equal(expected[0].PostCode, result.First().PostCode);
        Assert.Equal(expected[0].City, result.First().City);
        Assert.Equal(expected[0].Email, result.First().Email);
        Assert.Equal(expected[0].Phone, result.First().Phone);

    }
}