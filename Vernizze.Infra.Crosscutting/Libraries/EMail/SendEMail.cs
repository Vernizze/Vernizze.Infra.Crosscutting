using System.Net;
using System.Net.Mail;
using System.Text;
using Vernizze.Infra.CrossCutting.DataObjects.AppSettings;

namespace Vernizze.Infra.CrossCutting.Libraries.EMail
{
    public class SendEMail
    {
        #region Variables

        private MailMessage _mail;
        private EMailSettings _cfg;

        #endregion

        #region Constructors

        public SendEMail(EMailSettings cfg)
        {
            this._cfg = cfg;

            this._mail = new MailMessage();

            this._mail.From = new MailAddress(this._cfg.mail_from);

            this._mail.IsBodyHtml = true;
        }

        #endregion

        #region Methods        

        private string GetEMailAlias()
        {
            var result = string.Empty;

            try
            {
                result = this._cfg.email_alias;
            }
            catch
            {
                result = "Grupo Durski";
            }

            return result;
        }

        private string GetEMailAddress()
        {
            var result = string.Empty;

            try
            {
                result = this._cfg.smtp_credencials_mail;
            }
            catch
            {
            }

            return result;
        }

        private string GetEMailPwd()
        {
            var result = string.Empty;

            try
            {
                result = this._cfg.smtp_credencials_password;
            }
            catch
            {
            }

            return result;
        }

        private bool EnableSSL()
        {
            var result = false;

            //bool.TryParse(ConfigurationManager.AppSettings["EnableSSL"].ToString(), out result);
            result = this._cfg.enable_ssl;

            return result;
        }

        private int GetEMailServerPort()
        {
            var result = 0;

            //int.TryParse(ConfigurationManager.AppSettings["SmtpPort"].ToString(), out result);
            result = this._cfg.smtp_port;

            return result;
        }

        public void Send(string to, string subject, string message)
        {
            var emailAlias = string.Empty;
            var emailAddress = string.Empty;
            var emailPwd = string.Empty;
            var enableSSL = false;
            var smtpPort = 0;

            emailAlias = this.GetEMailAlias();
            emailAddress = this.GetEMailAddress();
            emailPwd = this.GetEMailPwd();
            enableSSL = this.EnableSSL();
            smtpPort = this.GetEMailServerPort();

            using (var smtp = new SmtpClient(this._cfg.smtp_client))
            {
                this._mail.From = new MailAddress(emailAddress, emailAlias);                                                        // De (Endereço de Email + Alias de Apresentação)
                this._mail.To.Add(Encoding.UTF8.GetString(Encoding.Default.GetBytes(to)));                                          // Para
                this._mail.Subject = Encoding.UTF8.GetString(Encoding.Default.GetBytes(subject));                                   // Assunto
                this._mail.Body = message;                                                                                          // Mensagem
                smtp.EnableSsl = enableSSL;                                                                                         // Requer SSL
                smtp.Port = smtpPort;                                                                                               // Porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;                                                                   // Modo de envio
                smtp.UseDefaultCredentials = false;                                                                                 // Utiliza credencias especificas

                // Usuário e Senha para autenticação
                smtp.Credentials = new NetworkCredential(emailAddress, this._cfg.smtp_credencials_password);

                // Envia o e-mail
                smtp.Send(this._mail);
            }
        }

        #endregion
    }
}
