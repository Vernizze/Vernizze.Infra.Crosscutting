namespace Vernizze.Infra.CrossCutting.DataObjects.AppSettings
{
    public class RedisSettings
    {
        public string redis_ip { get; set; }
        public string redis_port { get; set; }
        public string redis_pwd { get; set; }
        public string register_expiration_minutes { get; set; }
    }
}
