using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using System;

namespace Infrastructure.UserNotifications.Email.Internal
{
    // for more information: https://antaris.github.io/RazorEngine/index.html
    class RazorTemplate
    {
        static RazorTemplate()
        {
            Engine.Razor = RazorEngineServiceFactory();
        }

        public static string Compile(string templateName, object model)
        {
            return Engine.Razor.RunCompile(templateName, (Type)null, model);
        }

        private static IRazorEngineService RazorEngineServiceFactory()
        {
            var config = new TemplateServiceConfiguration
            {
                DisableTempFileLocking = true,
                TemplateManager = new EmbeddedResourceTemplateManager(typeof(RazorTemplate)),
            };

            return RazorEngineService.Create(config);
        }
    }
}