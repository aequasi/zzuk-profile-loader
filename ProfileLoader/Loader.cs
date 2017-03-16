using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProfileLoader
{
    public enum ProfileExtension
    {
        JSON,
        XML
    }

    public class Loader
    {
        public static async Task<ProfileData> LoadProfileAsync(string fileName, string profileName, ProfileExtension profileExtension, string profileType)
            => await Task.Run(() => LoadProfile(fileName, profileName, profileExtension, profileType));

        public static ProfileData LoadProfile(string fileName, string profileName, ProfileExtension profileExtension, string profileType)
        {
            string content = new StreamReader(fileName).ReadToEnd();
            if (profileExtension == ProfileExtension.XML) {
                content = ConvertXmlToJson(profileName, content, profileType);
            }

            return JsonConvert.DeserializeObject<ProfileData>(content);
        }

        private static string ConvertXmlToJson(string profileName, string content, string profileType)
        {
            string url = "http://profile-converter.herokuapp.com/xml/" + WebUtility.UrlEncode(profileName) + "/" + profileType;
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
