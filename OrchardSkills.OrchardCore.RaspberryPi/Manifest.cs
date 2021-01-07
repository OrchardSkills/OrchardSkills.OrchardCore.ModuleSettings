using OrchardCore.Modules.Manifest;
using OrchardSkills.OrchardCore.RaspberryPi;

[assembly: Module(
    Name = "RaspberryPi",
    Author = "Orchard Skills",
    Website = "https://orchardskills.com",
    Version = "0.0.1",
    Description = "Raspberry Pi module devices",
    Category = "RaspberryPi"
)]

[assembly: Feature(
    Id = RaspberryPiConstants.Features.RaspberryPiRelay,
    Name = "RaspberryPi Relay",
    Category = "RaspberryPi",
    Description = "Integrate Raspberry Pi Relay"
)]