using Vernizze.Infra.CrossCutting.DataObjects.AppSettings.Base;

namespace Vernizze.Infra.CrossCutting.Libraries.FileSettings
{
    public interface IFileSettingsBuilder<T> where T : new() // BaseAppSettings, new()
    {
        IFileSettingsBuilder<T> SetFileName(string fileName);
        IFileSettingsBuilder<T> SetFileName(string path, string fileName);
        IFileSettingsBuilder<T> ReadFromFile();
        T GetResult();
    }
}