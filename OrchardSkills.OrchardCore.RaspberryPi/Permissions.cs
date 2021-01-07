using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrchardCore.Security.Permissions;

namespace OrchardSkills.OrchardCore.RaspberryPi
{
    public class Permissions
    {

        public static readonly Permission ManageRaspberryPiRelay
            = new Permission(nameof(ManageRaspberryPiRelay), "Manage RaspberryPi Relay settings");


        public class RaspberryPiRelay : IPermissionProvider
        {
            public Task<IEnumerable<Permission>> GetPermissionsAsync()
            {
                return Task.FromResult(new[]
                {
                    ManageRaspberryPiRelay
                }
                .AsEnumerable());
            }

            public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
            {
                yield return new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[]
                    {
                        ManageRaspberryPiRelay
                    }
                };
            }
        }
    }
}
