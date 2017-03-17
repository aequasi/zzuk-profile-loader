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
        Json,
        Xml
    }

    public enum ProfileType
    {
        Grinding,
        Questing,
        Gathering,
        Travel
    }

    /// <summary>
    /// Loader handles all the profile loading
    /// </summary>
    public class Loader
    {
        /// <summary>
        /// LoadProfileAsync loads a profile asyncronously, based on the given options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<ProfileData> LoadProfileAsync(LoaderOptions options)
            => await Task.Run(() => LoadProfile(options));

        /// <summary>
        /// LoadProfile loads a profile based on the given options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public ProfileData LoadProfile(LoaderOptions options)
        {
            string content = new StreamReader(options.FileName).ReadToEnd();
            if (options.ProfileExtension == ProfileExtension.Xml) {
                content = ConvertXmlToJson(options, content);
            }

            return JsonConvert.DeserializeObject<ProfileData>(content);
        }

        /// <summary>
        /// ConvertXmlToJson converts the supplied content from XML to JSON
        /// </summary>
        /// <param name="options"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private string ConvertXmlToJson(LoaderOptions options, string content)
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
