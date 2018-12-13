using System;

namespace FunService.Configuration
{
    public interface ISettingsManager
    {
        Uri ChuckNorrisServiceUri { get; }
    }
}