using BenchmarkDotNet.Running;
using ConsoleTables;
using Refit;
using RefitClient.BenchmarkTests;
using RefitClient.FakeData;


var userAPI = RestService.For<IUserApi>("https://localhost:7088");

var users = await userAPI.GetUsers();

string loading = "";

var options = new ConsoleTableOptions
{
    Columns = new[] { "ID", "Name", "Username" },
    EnableCount = true,

};

#if DEBUG
        Console.WriteLine("Running in Debug mode.");
        var table = new ConsoleTable(options);
        Console.WriteLine("Wait Loading...");
        await foreach (var user in GetAsyncSequence(users))
        {
            Console.Clear();
            Console.Write(loading);
            table.AddRow(user.Id, user.Name, user.Username);
            loading += $" . ";
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        table.Write();
        Console.ReadKey();
#else
     Console.WriteLine("Running in Release mode.");
     BenchmarkRunner.Run<TheTest>();
#endif

static async IAsyncEnumerable<User> GetAsyncSequence(List<User> users)
{
    foreach (var user in users)
    {
        await Task.Delay(100);
        yield return user;
    }
}
