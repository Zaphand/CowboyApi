using CowboyApi.Classes;
using CowboyApi.Context;
using CowboyApi.Services;
using Microsoft.AspNetCore.Authentication;

internal class Program
{

    internal static IServiceProvider ServiceProvider { get; private set; }

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);



        SystemVariables.OpenAIKey = builder.Configuration["OpenAIKey"];
        // Add services to the container.
        builder.Services.AddDbContext<CowContext>();
        builder.Services.AddScoped<OpenAIService>();


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader()
                .AllowAnyOrigin();

            });
        });

        builder.Services.AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, CowboyAuthenticationSchemeHandler>(
            "Tokens",
            options =>
            {


            }
        );


        var app = builder.Build();

        ServiceProvider = app.Services;

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }


    public static T Resolve<T>()
    {
        return ServiceProvider.GetService<T>();
    }

}