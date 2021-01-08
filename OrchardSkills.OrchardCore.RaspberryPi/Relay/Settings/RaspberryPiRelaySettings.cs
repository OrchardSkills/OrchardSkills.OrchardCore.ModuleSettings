using OrchardCore.DisplayManagement.Entities;
using OrchardCore.Settings;

namespace OrchardSkills.OrchardCore.RaspberryPi.Relay.Settings
{
    public class RaspberryPiRelaySettings : SectionDisplayDriver<ISite, RaspberryPiRelaySettings>
    {
        public int GpioPin { get; set; } = 17;
    }
}
