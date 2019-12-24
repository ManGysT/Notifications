namespace Core.Services
{
    public interface ISettingsManager
    {
        TResult GetSection<TResult>(string sectionName);
        string GetValue(string settingName);
    }
}