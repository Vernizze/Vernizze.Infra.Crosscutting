namespace Vernizze.Infra.CrossCutting.DataObjects.AppSettings.Base
{
    public abstract class BaseAppSettings
    {
        public RedisSettings redis_settings { get; set; }
        public AzureConfigs azure_settings { get; set; }
        public EMailSettings email_settings { get; set; }
		public ConnectionStringsFilePath connection_strings_file_path { get; set; }
    }
}
