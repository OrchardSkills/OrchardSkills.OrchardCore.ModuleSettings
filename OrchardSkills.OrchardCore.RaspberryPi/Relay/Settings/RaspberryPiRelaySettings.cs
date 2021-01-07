using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardSkills.OrchardCore.RaspberryPi.Relay.Settings;
using OrchardSkills.OrchardCore.RaspberryPi.Relay.ViewModels;
using OrchardCore.Settings;

namespace OrchardSkills.OrchardCore.RaspberryPi.Relay.Settings
{
    public class RaspberryPiRelaySettings : SectionDisplayDriver<ISite, RaspberryPiRelaySettings>
    {
        public int GpioPin { get; set; }
    }
}
