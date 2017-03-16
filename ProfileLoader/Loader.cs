using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProfileLoader
{
    public enum ProfileType
    {
        JSON,
        XML
    }

    public class Loader
    {
        public static async Task<ProfileData> LoadProfileAsync(string fileName, string profileName, ProfileType type)
            => await Task.Run(() => LoadProfile(fileName, profileName, type));

        public static ProfileData LoadProfile(string fileName, string profileName, ProfileType type)
        {
            string content = new StreamReader(fileName).ReadToEnd();
            if (type == ProfileType.JSON) {
                content = ConvertXmlToJson(profileName, content);
            }

            return JsonConvert.DeserializeObject<ProfileData>(content);
        }

        private static string ConvertXmlToJson(string profileName, string content)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create($"http://profile-converter.herokuapp.com/xml/{profileName}");

            byte[] bytes = Encoding.ASCII.GetBytes(content);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK) {
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }

            throw new Exception("Could not convert XML to JSON: " + response.ToString());
        }
    }
}
