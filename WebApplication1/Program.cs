using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using WebApplication1.Controllers.Services;
using WebApplication1.Controllers.Services.Interfaces;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

IConfiguration Config = builder.Configuration;
// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7133/",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TrueMovieAwardsTrueMovieAwardsTrueMovieAwardsTrueMovieAwards"))
    };
}
);
builder.Services.AddCors(options => options.AddPolicy(name: "MovieAwardsOrigins", policy =>
{
    policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
}));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IActor, ActorService>();
builder.Services.AddScoped<IProducer, ProducerService>();
builder.Services.AddScoped<IFestival, FestivalService>();
builder.Services.AddScoped<IHolding, HoldingService>();
builder.Services.AddScoped<IAward, AwardService>();
builder.Services.AddScoped<IGenre, GenreService>();
builder.Services.AddScoped<IMovie, MovieService>();
builder.Services.AddScoped<ISeries, SeriesService>();
builder.Services.AddScoped<IStudio, StudioService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("CS"))
); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer  {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
      
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();

});

var app = builder.Build();


app.UseCors("MovieAwardsOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
