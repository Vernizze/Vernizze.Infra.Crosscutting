using System.Threading.Tasks;

namespace Vernizze.Infra.CrossCutting.Extensions
{
    public static class TaskExtensions
    {
        public static async void FireAndForget(this Task task, bool ThrowException = false)
        {
            try
            {
                await task;
            }
            catch
            {
                if (ThrowException) throw;
            }
        }
    }
}