using Biz.Factorys;
using Biz.Interfaces;

namespace ConsolePresentation.Dialogs;

public class MenuDialogs(IUserService userService)
{
    private readonly IUserService _userService = userService;

    public void MainMenu()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("-- Menu Options --");
            Console.WriteLine("------------------");
            Console.WriteLine("1. Add User");
            Console.WriteLine("2. View all Users");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Select Option: ");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    AddUserOption();
                    break;
                case "2":
                    ViewÁllUsers();
                    break;

                case "0":
                    running = false;
                    break;

                default:
                    break;
            }
        }
    }
    public void AddUserOption()
    {
        var form = UserFactory.Create();

        Console.Clear();
        Console.WriteLine("-- Add User --");
        Console.Write("First Name: ");
        form.FirstName = Console.ReadLine()!;
        Console.Write("Last Name: ");
        form.LastName = Console.ReadLine()!;
        Console.Write("Address: ");
        form.Address = Console.ReadLine()!;
        Console.Write("Post Code: ");
        form.PostCode = Console.ReadLine()!;
        Console.Write("City: ");
        form.City  = Console.ReadLine()!;
        Console.Write("Email: ");
        form.Email = Console.ReadLine()!;
        Console.Write("Phonenumber: ");
        form.Phone = Console.ReadLine()!;

        var result = _userService.Save(form);

        if (result)
        {
            Console.WriteLine("Success!");
        }
        else
        { 
            Console.WriteLine("Faild to add user!");
        }

    }

    public void ViewÁllUsers()
    {

        Console.Clear();
        Console.WriteLine("-- All Users --");

        var users = _userService.GetAll();

        foreach (var user in users)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine($"{user.FirstName} {user.LastName}");
            Console.WriteLine(user.Address);
            Console.WriteLine(user.PostCode);
            Console.WriteLine(user.City);
            Console.Write("Email: ");
            Console.WriteLine(user.Email);
            Console.Write("Phone number: ");
            Console.WriteLine(user.Phone);

             
        }
        Console.ReadKey();


    }

}
