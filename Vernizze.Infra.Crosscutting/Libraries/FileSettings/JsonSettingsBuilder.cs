using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Vernizze.Infra.CrossCutting.DataObjects.AppSettings.Base;
using System.IO;
using Vernizze.Infra.CrossCutting.Utils;

namespace Vernizze.Infra.CrossCutting.Libraries.FileSettings
{
    public class JsonSettingsBuilder<T> : FileSettingsBuilder<T> 
        where T : new() //BaseAppSettings, new()
    {
        public override IFileSettingsBuilder<T> ReadFromFile()
        {
            var fileName = this.GetFileName();
            var json = FilesAndFolders.GetFileContent(fileName);
            
            this.ObjetoSetting = JsonConvert.DeserializeObject<T>(json);

            return this;
        }
    }
}
