// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Validation;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IValidator, MaxValidator>();
builder.Services.AddScoped<IValidator, MinValidator>();
builder.Services.AddScoped<IValidator, ExistsValidator>();
builder.Services.AddScoped<IValidateService, ValidateService>();
using var host = builder.Build();
RunCode(host.Services);


static void RunCode(IServiceProvider hostProvider)
{
    using var serviceScope = hostProvider.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var validator = provider.GetRequiredService<IValidateService>();
    var scoreForPerson = new PersonScore {Id = 2, Score = 75};
    var messages = validator.ValidateAll(scoreForPerson);
    foreach (var message in messages)
    {
        Console.WriteLine(message);
    }

	messages = validator.ValidateAll(null);
    foreach (var message in messages)
    {
        Console.WriteLine(message);
    }

}