using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using OrchardCore.Navigation;
using OrchardCore.Recipes;
using OrchardCore.Security.Permissions;
using OrchardCore.Settings;
using OrchardSkills.OrchardCore.RaspberryPi.Devices;
using OrchardSkills.OrchardCore.RaspberryPi.Relay.Drivers;
using OrchardSkills.OrchardCore.RaspberryPi.Relay.Recipes;

namespace OrchardSkills.OrchardCore.RaspberryPi
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<RelayDevice>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Relay",
                areaName: "OrchardSkills.OrchardCore.RaspberryPi",
                pattern: "Relay",
                defaults: new { controller = "Relay", action = "Index" }
            );
        }
    }
    [Feature(RaspberryPiConstants.Features.RaspberryPiRelay)]
    public class RaspberryPiRelayStartup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            
            services.AddScoped<IPermissionProvider, Permissions.RaspberryPiRelay>();
            services.AddRecipeExecutionStep<RaspberryPiRelaySettingsStep>();
            services.AddScoped<IDisplayDriver<ISite>, RaspberryPiRelaySettingsDisplayDriver>();
            services.AddScoped<INavigationProvider, RaspberryPiRelayAdminMenu>();
        }
    }
}
