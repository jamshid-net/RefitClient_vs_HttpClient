using BenchmarkDotNet.Attributes;
using Refit;
using RefitClient.FakeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RefitClient.BenchmarkTests;

[MemoryDiagnoser]
public class TheTest
{
    // Test HttpClient vs RefitClient
    private const  string BASEURL = "https://localhost:7088";

    [Benchmark]
    public async Task<List<User>> GetUsersRefit()
    {
        var userAPI = RestService.For<IUserApi>(BASEURL);
        
        var users = await userAPI.GetUsers();
        return users;
    }

    [Benchmark]
    public async Task<List<User>> GetUsersHttp()
    {
        var httpClient = new HttpClient() { BaseAddress = new Uri(BASEURL)};
       var users =await httpClient.GetFromJsonAsync<List<User>>("/api/RefitTest/GetUsers");
        return users;
    }
}
