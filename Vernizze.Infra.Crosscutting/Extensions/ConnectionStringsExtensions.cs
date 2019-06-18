using Vernizze.Infra.CrossCutting.DataObjects.AppSettings;
using Vernizze.Infra.CrossCutting.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class ConnectionStringsExtensions
    {
        public static ConnectionStrings Protect(this ConnectionStrings file, string key)
        {
            try
            {
                file.is_protected = "true";
                file.MaderoAuthConnection = Crypto.Encrypt(file.MaderoAuthConnection.IsNull() ? string.Empty : file.MaderoAuthConnection, key);
                file.MaderoConnection = Crypto.Encrypt(file.MaderoConnection.IsNull() ? string.Empty : file.MaderoConnection, key);
                file.MaderoExpressConnection = Crypto.Encrypt(file.MaderoExpressConnection.IsNull() ? string.Empty : file.MaderoExpressConnection, key);
                file.MelsConnection = Crypto.Encrypt(file.MelsConnection.IsNull() ? string.Empty : file.MelsConnection, key);
                file.MongoDBConnection = Crypto.Encrypt(file.MongoDBConnection.IsNull() ? string.Empty : file.MongoDBConnection, key);
                file.NotificacoesConnection = Crypto.Encrypt(file.NotificacoesConnection.IsNull() ? string.Empty : file.NotificacoesConnection, key);
                file.PessoasConnection = Crypto.Encrypt(file.PessoasConnection.IsNull() ? string.Empty : file.PessoasConnection, key);
                file.RetiradaConnection = Crypto.Encrypt(file.RetiradaConnection.IsNull() ? string.Empty : file.RetiradaConnection, key);
                file.TeknisaAuthConnection = Crypto.Encrypt(file.TeknisaAuthConnection.IsNull() ? string.Empty : file.TeknisaAuthConnection, key);

                var json = JsonConvert.SerializeObject(file);

                System.IO.File.WriteAllText(@"connections_strings.json", json);

                return file;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}-{ex.StackTrace}");
            }
        }

        public static ConnectionStrings Unprotect(this ConnectionStrings file, string key)
        {
            try
            {
                file.ReadProtected(key);

                file.is_protected = "false";

                var json = JsonConvert.SerializeObject(file);

                System.IO.File.WriteAllText(@"connections_strings.json", json);

                return file;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}-{ex.StackTrace}");
            }
        }

        public static ConnectionStrings ReadProtected(this ConnectionStrings file, string key)
        {
            try
            {
                file.MaderoAuthConnection = Crypto.Decrypt(file.MaderoAuthConnection.IsNull() ? string.Empty : file.MaderoAuthConnection, key);
                file.MaderoConnection = Crypto.Decrypt(file.MaderoConnection.IsNull() ? string.Empty : file.MaderoConnection, key);
                file.MaderoExpressConnection = Crypto.Decrypt(file.MaderoExpressConnection.IsNull() ? string.Empty : file.MaderoExpressConnection, key);
                file.MelsConnection = Crypto.Decrypt(file.MelsConnection.IsNull() ? string.Empty : file.MelsConnection, key);
                file.MongoDBConnection = Crypto.Decrypt(file.MongoDBConnection.IsNull() ? string.Empty : file.MongoDBConnection, key);
                file.NotificacoesConnection = Crypto.Decrypt(file.NotificacoesConnection.IsNull() ? string.Empty : file.NotificacoesConnection, key);
                file.PessoasConnection = Crypto.Decrypt(file.PessoasConnection.IsNull() ? string.Empty : file.PessoasConnection, key);
                file.RetiradaConnection = Crypto.Decrypt(file.RetiradaConnection.IsNull() ? string.Empty : file.RetiradaConnection, key);
                file.TeknisaAuthConnection = Crypto.Decrypt(file.TeknisaAuthConnection.IsNull() ? string.Empty : file.TeknisaAuthConnection, key);

                return file;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}-{ex.StackTrace}");
            }
        }
    }
}
