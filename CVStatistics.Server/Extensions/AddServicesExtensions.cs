using CVStatistics.Domain.Interfaces;
using CVStatistics.Server.Options;
using CVStatistics.Services;
using CVStatistics.Services.APIExternal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Text.Json.Serialization;

namespace CVStatistics.Server.Extensions
{
    public static class AddServicesExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            builder.Services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
            builder.Services.AddVersionedApiExplorer(congig =>
            {
                congig.GroupNameFormat = "'v'VVV";
                congig.SubstituteApiVersionInUrl = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddHttpClient<IGetpostmanCoronavirusApiHttpClient, GetpostmanCoronavirusApiHttpClient>();
            builder.Services.AddScoped<IExternalCoronavirusService, ExternalCoronavirusService>();
            builder.Services.AddHostedService<UpdateLocalStatisticsService>();
            //builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            //builder.Services.AddScoped<IPasswordHasher<AccountDAL>, PasswordHasher<AccountDAL>>();
        }
    }
}
