using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardSkills.OrchardCore.RaspberryPi.Relay.Settings;
using OrchardSkills.OrchardCore.RaspberryPi.Relay.ViewModels;
using OrchardCore.Settings;


namespace OrchardSkills.OrchardCore.RaspberryPi.Relay.Drivers
{
    public class RaspberryPiRelaySettingsDisplayDriver : SectionDisplayDriver<ISite, RaspberryPiRelaySettings>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RaspberryPiRelaySettingsDisplayDriver (
            IAuthorizationService authorizationService,
            IHttpContextAccessor httpContextAccessor)
        {
            _authorizationService = authorizationService;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<IDisplayResult> EditAsync(RaspberryPiRelaySettings settings, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (!await _authorizationService.AuthorizeAsync(user, OrchardSkills.OrchardCore.RaspberryPi.Permissions.ManageRaspberryPiRelay))
            {
                return null;
            }

            return Initialize<RaspberryPiRelaySettingsViewModel>("RaspberryPiRelaySettings_Edit", model =>
            {
                model.GpioPin = settings.GpioPin;
            }).Location("Content:5").OnGroup(RaspberryPiConstants.Features.RaspberryPiRelay);
        }

        public override async Task<IDisplayResult> UpdateAsync(RaspberryPiRelaySettings settings, BuildEditorContext context)
        {
            if (context.GroupId == RaspberryPiConstants.Features.RaspberryPiRelay)
            {
                var user = _httpContextAccessor.HttpContext?.User;
                if (user == null || !await _authorizationService.AuthorizeAsync(user, Permissions.ManageRaspberryPiRelay))
                {
                    return null;
                }

                var model = new RaspberryPiRelaySettingsViewModel();
                await context.Updater.TryUpdateModelAsync(model, Prefix);

                if (context.Updater.ModelState.IsValid)
                {
                    settings.GpioPin = model.GpioPin;
                }
            }
            return await EditAsync(settings, context);
        }


    }
}
