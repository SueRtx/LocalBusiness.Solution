using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using LocalApi.Models;
using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using LocalApi.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace LocalApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

      services.AddDbContext<LocalApiContext>(opt =>
        opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])
        ));

      services.AddAuthentication(options => {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })

      .AddJwtBearer(jwt => {
        var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters 
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false,
          ValidateLifetime = true,
          RequireExpirationTime = false
        };
      });

      services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<LocalApiContext>();

      services.AddControllers();
      
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo 
        { 
          Version = "v1",
          Title = "Local Business API", 
          Description = "API FOR LOCAL BUSINESS LIST",

          Contact = new OpenApiContact
          {
            Name = "Sue Roberts",
            Email = "suerobertstx@yahoo.com",
          }
        });

        // To Enable authorization using Swagger (JWT)  
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()  
        {  
          Name = "Authorization",  
          Type = SecuritySchemeType.ApiKey,  
          Scheme = "Bearer",  
          BearerFormat = "JWT",  
          In = ParameterLocation.Header,  
          Description = "JWT Authorization header using the Bearer scheme.",  
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement  
        {  
          {  
            new OpenApiSecurityScheme  
              {  
                Reference = new OpenApiReference  
                {  
                  Type = ReferenceType.SecurityScheme,  
                  Id = "Bearer"  
                }  
              },  
              new string[] {}  
          }  
        });  
      
        // Set the comments path for the Swagger JSON and UI.
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BUSINESS API V1");
        c.RoutePrefix = string.Empty;
      });

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
