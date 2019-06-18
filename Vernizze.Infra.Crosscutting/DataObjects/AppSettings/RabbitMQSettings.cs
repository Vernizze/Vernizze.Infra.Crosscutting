namespace Vernizze.Infra.CrossCutting.DataObjects.AppSettings
{
    public class RabbitMQSettings
    {
        public string host_name { get; set; }
        public int port { get; set; }
        public string user_name { get; set; }
        public string pwd { get; set; }
    }
}
