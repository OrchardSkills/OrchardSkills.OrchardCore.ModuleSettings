using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using OrchardCore.Environment.Shell.Descriptor.Models;
using OrchardCore.Modules;
using OrchardCore.Navigation;

namespace OrchardSkills.OrchardCore.RaspberryPi
{
    [Feature(RaspberryPiConstants.Features.RaspberryPiRelay)]
    public class RaspberryPiRelayAdminMenu : INavigationProvider
    {
        private readonly ShellDescriptor _shellDescriptor;
        private readonly IStringLocalizer S;

        public RaspberryPiRelayAdminMenu(
            IStringLocalizer<RaspberryPiRelayAdminMenu> localizer,
            ShellDescriptor shellDescriptor)
        {
            S = localizer;
            _shellDescriptor = shellDescriptor;
        }

        public Task BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (String.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                builder.Add(S["Configuration"], configuration => configuration
                        .Add(S["Settings"], settings => settings
                            .Add(S["Raspberry Pi"], S["Raspberry Pi"].PrefixPosition(), settings => settings
                            .AddClass("raspberryPiRelay").Id("raspberryPiRelay")
                            .Action("Index", "Admin", new { area = "OrchardCore.Settings", groupId = RaspberryPiConstants.Features.RaspberryPiRelay })
                                .Permission(Permissions.ManageRaspberryPiRelay)
                                .LocalNav())
                            )
                        );
            }
            return Task.CompletedTask;
        }
    }
}
