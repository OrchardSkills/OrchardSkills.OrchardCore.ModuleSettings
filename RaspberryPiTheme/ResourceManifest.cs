using OrchardCore.ResourceManagement;

namespace OrchardCore.Themes.RaspberryPiTheme
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineStyle("RaspberryPiTheme-css" )
                .SetUrl("~/RaspberryPiTheme/css/mdb.min.css")
                .SetVersion("1.0.0");

            manifest
                .DefineScript("RaspberryPiTheme-js")
                .SetUrl("~/RaspberryPiTheme/js/mdb.min.js")
                .SetVersion("1.0.0");

            manifest
                .DefineStyle("RaspberryPiTheme-vendor-font-awesome")
                .SetUrl("https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.15.1/css/all.min.css")
                .SetCdnIntegrity("sha256-FMvZuGapsJLjouA6k7Eo2lusoAX9i0ShlWFG6qt7SLc=")
                .SetVersion("5.15.1");

            manifest
                .DefineScript("RaspberryPiTheme-vendor-font-awesome")
                .SetCdn("https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.15.1/js/fontawesome.min.js")
                .SetCdnIntegrity("sha256-dNZKI9qQEpJG03MLdR2Rg9Dva1o+50fN3zmlDP+3I+Y=")
                .SetVersion("5.15.1");
        }
    }
}
