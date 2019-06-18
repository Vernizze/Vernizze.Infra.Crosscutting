using System;
using Net = System.Net.NetworkInformation;

namespace Vernizze.Infra.CrossCutting.Utils
{
    public class Ping
    {
        public static async void Send(string ip, Action<string> success, Action<string> error)
        {
            Send(ip, success, error, 0);
        }

        public static async void Send(string ip, Action<string> success, Action<string> error, int loop_qtty)
        {
            try
            {
                var ping = new Net.Ping();

                var ping_response = await ping.SendPingAsync(ip);

                if (ping_response.Status.ToString().Equals("Success"))
                    success($"Iteration {loop_qtty} - Response: {ping_response.Status.ToString()}");
                else
                    error($"Iteration {loop_qtty} - Response: {ping_response.Status.ToString()}");

                if (loop_qtty > 1)
                {
                    Send(ip, success, error, loop_qtty - 1);
                }
            }
            catch (Exception ex)
            {
                error($"Iteration {loop_qtty} - Error: {ex.Message}-{ex.StackTrace}");
            }
        }
    }
}
