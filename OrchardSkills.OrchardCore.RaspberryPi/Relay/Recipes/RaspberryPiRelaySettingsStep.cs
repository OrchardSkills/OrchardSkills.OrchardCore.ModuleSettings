using System;
using System.Threading.Tasks;
using OrchardCore.Entities;
using OrchardSkills.OrchardCore.RaspberryPi.Relay.Settings;
using OrchardSkills.OrchardCore.RaspberryPi.Relay.ViewModels;
using OrchardCore.Recipes.Models;
using OrchardCore.Recipes.Services;
using OrchardCore.Settings;

namespace OrchardSkills.OrchardCore.RaspberryPi.Relay.Recipes
{
    public class RaspberryPiRelaySettingsStep : IRecipeStepHandler
    {
        private readonly ISiteService _siteService;
        public RaspberryPiRelaySettingsStep(ISiteService siteService)
        {
            _siteService = siteService;
        }

        public async Task ExecuteAsync(RecipeExecutionContext context)
        {
            if (!string.Equals(context.Name, nameof(RaspberryPiRelaySettings), StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            var model = context.Step.ToObject<RaspberryPiRelaySettingsViewModel>();
            var container = await _siteService.LoadSiteSettingsAsync();
            container.Alter<RaspberryPiRelaySettings>(nameof(RaspberryPiRelaySettings), aspect =>
            {
                aspect.GpioPin = model.GpioPin;
            });
            await _siteService.UpdateSiteSettingsAsync(container);
        }

    }
}
