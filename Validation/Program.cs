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
    validator.ValidateAll(scoreForPerson);


	try
	{
		validator.ValidateAll(null);

	}
	catch (Exception ex)
	{
		Console.WriteLine($"What do I have here {ex.Message} {ex.GetType()}");
		
	}

}