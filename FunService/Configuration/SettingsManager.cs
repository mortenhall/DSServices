using System;

namespace FunService.Configuration
{
    public class SettingsManager  : ISettingsManager
    {
        public Uri ChuckNorrisServiceUri => new Uri(Environment.GetEnvironmentVariable("CHUCKNORRISSERVICE_HOSTURL"));
    }
}