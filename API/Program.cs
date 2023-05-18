using Microsoft.AspNetCore.Authentication.Negotiate;
using NoiThat.DataLayer;
using NoiThat.Services;
using NoiThat.Services.Entity;
using NoiThat.Services.Interface;

namespace API
{
    public class Program
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .SetIsOriginAllowed((host) => true)
                     .AllowCredentials()
                 );
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
        }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
            .AddJsonOptions(
            options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
                .AddNegotiate();

            builder.Services.AddAuthorization(options =>
            {
                // By default, all incoming requests will be authorized according to the default policy.
                options.FallbackPolicy = options.DefaultPolicy;
            });
            builder.Services.Configure<InteriorDatabaseSettings>(
            builder.Configuration.GetSection("InteriorDatabase"));

            // Xác định class triển khai interface cho services
            builder.Services.AddScoped<ICategoryResponsitory, CategoryResponsitory>();
            builder.Services.AddScoped<IProductResponsitory, ProductResponsitory>();
            builder.Services.AddScoped<IRoleResponsitory, RoleResponsitory>();
            builder.Services.AddScoped<IAccountResponsitory, AccountResponsitory>();
            // Xác định class triển khai interface cho responsitory
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped<IRoleServices, RoleServices>();
            builder.Services.AddScoped<IAccountServices, AccountServices>();
            builder.Services.AddScoped<FileServices>();

            builder.Services.AddScoped(typeof(IBaseServices<>), typeof(BaseServices<>));
            //builder.Services.AddScoped(typeof(IRoleResponsitory<>), typeof(RoleResponsitory<>));
            builder.Services.AddScoped(typeof(IBaseResponsitory<>), typeof(BaseRepository<>));
            // cross
            builder.Services.AddCors();


            var app = builder.Build();
            app.UseCors();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}