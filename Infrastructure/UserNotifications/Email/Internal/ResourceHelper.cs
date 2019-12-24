using System;
using System.IO;
using System.Reflection;

namespace Infrastructure.UserNotifications.Email.Internal
{
    class ResourceHelper
    {
        public static bool Exists(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();

            return Array.IndexOf(resources, resourceName) >= 0;
        }

        public static string GetResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream != null)
                {
                    using (var streamReader = new StreamReader(resourceStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }

            return null;
        }
    }
}