namespace Vernizze.Infra.CrossCutting.DataObjects.AppSettings
{
    public class EMailSettings
    {
        public string smtp_credencials_mail { get; set; }
        public string smtp_credencials_password { get; set; }
        public bool enable_ssl { get; set; }
        public string smtp_client { get; set; }
        public int smtp_port { get; set; }
        public string mail_from { get; set; }
        public string email_alias { get; set; }
        public string mail_to { get; set; }
        public string mail_subject { get; set; }
    }
}
