using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Vernizze.Infra.CrossCutting.DataObjects.AppSettings.Base;
using System.IO;
using Vernizze.Infra.CrossCutting.Utils;

namespace Vernizze.Infra.CrossCutting.Libraries.FileSettings
{
    public abstract class FileSettingsBuilder<T> 
        : IFileSettingsBuilder<T> where T : new()
    {
        #region Variables

        private string _fileName;

        #endregion

        #region Attributes
        protected T ObjetoSetting { get; set; }

        #endregion

        #region Constructors

        public FileSettingsBuilder() { }

        #endregion

        #region Public Methods
        public IFileSettingsBuilder<T> SetFileName(string fileName)
        {
            this._fileName = FilesAndFolders.SetCurrentFileName(fileName);
            CheckFileExists();
            return this;
        }

        public IFileSettingsBuilder<T> SetFileName(string path, string fileName)
        {
            this._fileName = FilesAndFolders.SetCurrentFileName(path, fileName);
            CheckFileExists();
            return this;
        }

        public T GetResult() => this.ObjetoSetting;

        public abstract IFileSettingsBuilder<T> ReadFromFile();

        #endregion

        #region Protected Methods
        protected string GetFileName() => this._fileName;
        protected void CheckFileExists() => FilesAndFolders.ThrowFileNotFoundException(this._fileName);

        #endregion
    }
}
