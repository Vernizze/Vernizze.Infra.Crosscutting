using System.Collections.Generic;

namespace Vernizze.Infra.CrossCutting.DataObjects.AppSettings
{
    public class AzureConfigs
    {
        public List<AzureConfig> configs { get; set; }
    }

    public class AzureConfig
    {
        public string reference { get; set; }
        public string account_name { get; set; }
        public string account_key { get; set; }
        public string container { get; set; }
    }
}
