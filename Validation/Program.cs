// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Validation;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddScoped<IRepository, Repository>();
using var host = builder.Build();
RunCode();

host.Run();

static void RunCode()
{
    Console.WriteLine("Hello");
}