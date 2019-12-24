using Core.Services;
using System.Configuration;

namespace ConsoleApp2
{
    public class DefaultSettingsManager : ISettingsManager
    {
        public TResult GetSection<TResult>(string sectionName)
        {
            return default(TResult);
        }

        public string GetValue(string settingName)
        {
            return ConfigurationManager.AppSettings[settingName];
        }
    }
}
