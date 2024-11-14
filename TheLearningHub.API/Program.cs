using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TheLearningHub.core.ICommon;
using TheLearningHub.core.IRepository;
using TheLearningHub.core.IService;
using TheLearningHub.infra.Common;
using TheLearningHub.infra.Repository;
using TheLearningHub.infra.Service;

namespace TheLearningHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("x",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IDbContext, DbContext>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IStudent_Course_Repository, Student_Course_Repository>();
            builder.Services.AddScoped<IStudent_Course_Service, Student_Course_Service>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<ILoginService, Login_Service>();

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,// H,P, Sig => H, P + secret
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Belive in your self, keep going and never stop ... you are star and the ski is the limit., Belive in your self, keep going and never stop ... you are star and the ski is the limit ")),
                ClockSkew = TimeSpan.Zero
            });;


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("x");

            app.MapControllers();

            app.Run();
        }
    }
}
