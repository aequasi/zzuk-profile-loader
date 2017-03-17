using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aequasi.ProfileLoader
{
    public enum ProfileExtension
    {
        JSON,
        XML
    }

    public enum ProfileType
    {
        Grinding,
        Questing,
        Gathering,
        Travel
    }

    public class Loader
    {
        public static async Task<ProfileData> LoadProfileAsync(LoaderOptions options)
            => await Task.Run(() => LoadProfile(options));

        public static ProfileData LoadProfile(LoaderOptions options)
        {
            string content = new StreamReader(options.FileName).ReadToEnd();
            if (options.ProfileExtension == ProfileExtension.XML) {
                content = ConvertXmlToJson(options, content);
            }

            return JsonConvert.DeserializeObject<ProfileData>(content);
        }

        private static string ConvertXmlToJson(LoaderOptions options, string content)
        {
            string url = "http://profile-converter.herokuapp.com/xml/" + WebUtility.UrlEncode(options.ProfileName) + "/" +options.ProfileType;
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            byte[] bytes = Encoding.ASCII.GetBytes(content);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK) {
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return json;
            }

            throw new Exception("Could not convert XML to JSON: " + response.ToString());
        }
    }
}
