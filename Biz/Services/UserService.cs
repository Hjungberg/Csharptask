using Biz.Dtos;
using Biz.Factorys;
using Biz.Interfaces;
using Biz.Models;
using System.Text.Json;

namespace Biz.Services;

public class UserService(IFileService fileService) : IUserService
{
    private readonly IFileService _fileService = fileService;
    private List<User> _users = [];

    public IEnumerable<User> GetAll()
    {
        string content = _fileService.GetContentFromFile();

        try
        {
            _users = JsonSerializer.Deserialize<List<User>>(content)!;
        }
        catch 
        {
            _users = [];
        }
        return _users;
    }

    public bool Save(UserRegForm form)
    {
        var user = UserFactory.Create(form);
        _users.Add(user);

        var json = JsonSerializer.Serialize(_users);
        var result = _fileService.SaveContentToFile(json);
        return result;
    }
}
