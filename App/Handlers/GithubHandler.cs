using App.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App.Handlers
{
    public static class GithubHandler
    {
        public static async Task<bool> IsLatestVersion()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(Settings.Default.app_name, Settings.Default.version));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", Settings.Default.access_token);

            var url = Settings.Default.repo_api_url + "/releases/latest";
            var response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);
            return json["tag_name"].ToString() == Settings.Default.version;
        }

        public static async void UpdateApp()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(Settings.Default.app_name, Settings.Default.version));
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", Settings.Default.access_token);

            var url = Settings.Default.repo_api_url + "/releases/latest";
            var response = await client.GetStringAsync(url);
            var json = JObject.Parse(response);
            var assetArray = JArray.Parse(json["assets"].ToString());
            var firstAsset = JObject.Parse(assetArray[0].ToString());
            var downloadname = firstAsset["name"];
            var downloadurl = firstAsset["browser_download_url"];

            DownloadAndRun(downloadname.ToString(), downloadurl.ToString());
        }

        private static async void DownloadAndRun(string name, string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(url);

                    string tempFilePath = Path.Combine(Path.GetTempPath(), name);
                    await File.WriteAllBytesAsync(tempFilePath, fileBytes);

                    Process.Start(new ProcessStartInfo(tempFilePath) { UseShellExecute = true });

                    Application.Exit();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
