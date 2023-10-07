using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefitClient.FakeData;
public interface IUserApi
{
    [Get("/api/RefitTest/GetUsers")]
    Task<List<User>> GetUsers();
}

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Username { get; set; }
}