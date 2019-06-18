using System;
using System.Collections.Generic;
using System.Text;
using Vernizze.Infra.CrossCutting.DataObjects.AppSettings.Base;
using Vernizze.Infra.CrossCutting.Extensions;
using Newtonsoft.Json;

namespace Vernizze.Infra.CrossCutting.Libraries.FileSettings
{
    public static class FileSettingsFactory<T>
        where T : new() // BaseAppSettings, new()
    {
        private static IFileSettingsBuilder<T> instance;

        public static IFileSettingsBuilder<T> GetInstance(EnumFileSettingsType settingType)
        {
            switch (settingType)
            {
                case EnumFileSettingsType.JsonSettings:
                    instance = new JsonSettingsBuilder<T>();
                    break;
                //case EnumFileSettingsType.TxtSettings:
                //    break;
                //case EnumFileSettingsType.XmlSettings:
                //    break;
                default:
                    throw new TypeAccessException("Instancia não inválida para a Factory de Arquivos");
            }

            return instance;
        }
    }
}
