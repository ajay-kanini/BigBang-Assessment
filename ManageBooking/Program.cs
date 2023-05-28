using ManageBooking.Context;
using ManageBooking.Intefaces;
using ManageBooking.Model;
using ManageBooking.Services;
using Microsoft.EntityFrameworkCore;

namespace ManageBooking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddSwaggerGen(c => {
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.Http,
            //        Scheme = "Bearer",
            //        BearerFormat = "JWT",
            //        In = ParameterLocation.Header,
            //        Description = "JWT Authorization header using the Bearer scheme."
            //    });
            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //     {
            //         {
            //               new OpenApiSecurityScheme
            //                 {
            //                     Reference = new OpenApiReference
            //                     {
            //                         Type = ReferenceType.SecurityScheme,
            //                         Id = "Bearer"
            //                     }
            //                 },
            //                 new string[] {}

            //         }
            //     });
            //});
            builder.Services.AddDbContext<BookingContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
            });
            builder.Services.AddScoped<IRepo<int, Booking>, BookingRepo>();
            builder.Services.AddScoped<BookingService>();
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
            //            ValidateIssuer = false,
            //            ValidateAudience = false
            //        };
            //    });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}