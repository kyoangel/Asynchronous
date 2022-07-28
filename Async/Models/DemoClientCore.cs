namespace Async.Models
{
    public class DemoClientCore
    {
        private readonly HttpClient _client = new();

        public async Task<IEnumerable<string>> GetBothAsync(string url1, string url2)
        {
            // var result = new ConcurrentBag<string>();
            var result = new List<string>();
            var task1 = GetOneAsync(result, url1);
            var task2 = GetOneAsync(result, url2);
            await Task.WhenAll(task1, task2);
            return result;
        }

        public async Task GetOneAsync(List<string> result, string url)
        {
            var data = await _client.GetStringAsync(url);
            result.Add(data);
        }
    }
}