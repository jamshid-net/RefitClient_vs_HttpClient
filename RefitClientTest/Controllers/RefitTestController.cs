using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace RefitClientTest.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class RefitTestController : ControllerBase
{
    [HttpGet]
    public Task<List<User>> GetUsers()
    {
        Faker faker = new Faker();
        List<User> users = new List<User>();    
        for (int i = 0; i < 10; i++)
        {
            users.Add(new User()
            {
                Id = 1,
                Name = faker.Name.FullName(),
                Username = faker.Internet.UserName()
            }) ;
        }
        return Task.FromResult(users);
    }



    

}
