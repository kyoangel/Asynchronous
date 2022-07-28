using System.Net.Http;
using System.Threading.Tasks;

namespace Async.framework.Models
{
    public class demo
    {
        // bad practice, just for demo, don't do this
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<string> DeadlockAsync(string url)
        {
            var content = await HttpClient.GetStringAsync(url);
            return content;
        }

        public async Task<string> NoDeadlockAsync(string url)
        {
            var content = await HttpClient.GetStringAsync(url).ConfigureAwait(false);
            return content;
        }

    }
}