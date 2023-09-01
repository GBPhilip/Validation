// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Validation;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IAsync, MaxValidator>();
builder.Services.AddScoped<IAsync, MinValidator>();
builder.Services.AddScoped<IValidator, ExistsValidator>();
builder.Services.AddScoped<IValidateService, ValidateService>();
using var host = builder.Build();
await RunCode(host.Services);


static async Task RunCode(IServiceProvider hostProvider)
{
    using var serviceScope = hostProvider.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var validator = provider.GetRequiredService<IValidateService>();
    var scoreForPerson = new PersonScore {Id = 2, Score = 110};
    var messages1 = await validator.ValidateAllAsync(scoreForPerson);
    foreach (var message in messages1)
    {
        Console.WriteLine(message);
    }

    List<string> message2 = new();
    message2 = await validator.ValidateAllAsync(null);

    foreach (var message in message2)
    {
        Console.WriteLine(message);
    }

}