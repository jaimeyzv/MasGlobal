using MasGlobal.Insfrastucture.Interfaces;
using System.Configuration;

namespace MasGlobal.Insfrastucture
{
    public class ConfigurationManagerWrapper : IConfigurationManagerWrapper
    {
        string IConfigurationManagerWrapper.GetAppSettings(string path)
        {
            return ConfigurationManager.AppSettings[path];
        }
    }
}
