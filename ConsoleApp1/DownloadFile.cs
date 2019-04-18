using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DownloadContent
    {
        private async Task<string> DownloadAsync(string url, HttpClient client, CancellationToken token)
        {
            var response = await client.GetAsync(url, token);
            return await response.Content.ReadAsStringAsync();
        }

        private async Task Wait()
        {
            await Task.Delay(1000);
            System.Console.WriteLine("wait1");
        }

        private async Task<string> DownloadMultiAsync(CancellationToken token)
        {
            HttpClient client = new HttpClient();
            var content1 = await DownloadAsync("url1", client, token);
            var content2 = await DownloadAsync("url2", client, token);
            var content3 = await DownloadAsync("url3", client, token);

            return content1 + content2 + content3;
        }

        public async void CancelableDownload()
        {
            //var tokenSource = new CancellationTokenSource();
            //var allContent = await DownloadMultiAsync(tokenSource.Token);
            await Wait();
            await Wait();
            await Wait();

            Thread.Sleep(1000);
            System.Console.WriteLine("100");

            //manually cancel download
            //tokenSource.Cancel();
        }

    }
}
