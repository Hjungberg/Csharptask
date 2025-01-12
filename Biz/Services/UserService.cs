using Biz.Dtos;
using Biz.Factorys;
using Biz.Interfaces;
using Biz.Models;
using System.Collections.Immutable;
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
    public bool EditSave(UserRegForm form)
    {
        var user = UserFactory.Create(form);

        var json = JsonSerializer.Serialize(_users);
        var result = _fileService.SaveContentToFile(json);
        return result;
    }

    // Hade problem med dom här. Lite ai tips fick allt att i alla fall funka. Ser fram imot databaser istället för filer /Henke
    public bool Edit(string userId, UserRegForm updatedForm)
    {
        var index = _users.FindIndex(u => u.Id == userId);
        if (index == -1) return false; 
        _users[index] = new User
        {
            Id = userId,
            FirstName = updatedForm.FirstName,
            LastName = updatedForm.LastName,
            Address = updatedForm.Address,
            PostCode = updatedForm.PostCode,
            City = updatedForm.City,
            Phone = updatedForm.Phone,
            Email = updatedForm.Email
        };
        

        return EditSave(updatedForm);
    }
    public bool Delete(string userId, UserRegForm updatedForm)
    {

        var index = _users.FindIndex(u => u.Id == userId);
        if (index == -1) return false; 
        _users.RemoveAt(index); 

        return EditSave(updatedForm);
    }


}
