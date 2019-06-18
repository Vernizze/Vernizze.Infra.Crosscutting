namespace Vernizze.Infra.CrossCutting.DataObjects.AppSettings
{
    public class ConnectionStrings
    {
        public string is_protected { get; set; }
        public string MaderoAuthConnection { get; set; }
        public string MaderoConnection { get; set; }
        public string MelsConnection { get; set; }
        public string PessoasConnection { get; set; }
        public string MaderoExpressConnection { get; set; }
        public string NotificacoesConnection { get; set; }
        public string TeknisaAuthConnection { get; set; }
        public string MongoDBConnection { get; set; }
        public string RetiradaConnection { get; set; }
    }
}
