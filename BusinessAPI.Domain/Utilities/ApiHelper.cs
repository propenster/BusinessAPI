using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BusinessAPI.Domain.Utilities
{
    public static class ApiHelper
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        //The Async Web Request Method.. Generic
        public static async Task<T> DoWebRequestAsync<T>(string url, object request, string requestType, Dictionary<string, string> headers = null, string authUserName = null, string authPword = null, MemoryStream stream = null) where T : new()
        {
            T result = new T();
            Method method = requestType.ToLower() == "post" ? Method.POST : Method.GET;

            //bypass ssl error on the api end..
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, SslPolicyErrors) => true;
            //instantiate a restclient
            var client = new RestClient(url);
            var restRequest = new RestRequest(method);
            if(method == Method.POST)
            {
                restRequest.RequestFormat = DataFormat.Json;
                restRequest.JsonSerializer = NewtonsoftJsonSerializer.Default;
                restRequest.AddJsonBody(request);
            }
           //restRequest.AddHeader("authorization", "Bearer" + access_token);
           
            if(headers != null)
            {
                foreach(var item in headers)
                {
                    restRequest.AddHeader(item.Key, item.Value);
                }
            }

            //If a valid AuthUsername and Password is passed in headers
            if(!string.IsNullOrEmpty(authUserName) && !string.IsNullOrEmpty(authPword))
            {
                client.Authenticator = new HttpBasicAuthenticator(authUserName, authPword);
            }
            //log
            try
            {
                logger.Info("Request Request {@request}", restRequest);
                IRestResponse<T> response = await client.ExecuteAsync<T>(restRequest);
                logger.Info("Request Response {@response}", response);
                if (response.Content.StartsWith("<?"))
                {
                    response.Content = ConvertXmlToJson(response.Content);
                    result = JsonConvert.DeserializeObject<T>(response.Content);
                    return result;
                }
                else
                {
                    result = JsonConvert.DeserializeObject<T>(response.Content);
                    return result;
                }
            }catch(Exception ex)
            {
                logger.Info($"An error occured while making request {ex.Message} {ex.InnerException}");
                return result;
            }

        }

        public static string ConvertXmlToJson(string xml)
        {
            //To convert an XML node contained in string xml into a JSOn string
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeObject(doc);
            return jsonText;
        }

        public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
        {
            private readonly Newtonsoft.Json.JsonSerializer serializer;

            public NewtonsoftJsonSerializer(Newtonsoft.Json.JsonSerializer serializer)
            {
                this.serializer = serializer;
            }

            public string ContentType
            {
                get { return "application/json";  } //probably used for Serialization?
                set { }
            }

            public string DateFormat { get; set; }
            public string Namespace { get; set; }
            public string RootElement { get; set; }


            public string Serialize(object obj)
            {
                using (var stringWriter = new StringWriter())
                {
                    using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                    {
                        serializer.Serialize(jsonTextWriter, obj);

                        return stringWriter.ToString();
                    }
                }
            }


            public T Deserialize<T>(RestSharp.IRestResponse response)
            {
                var content = response.Content;

                using (var stringReader = new StringReader(content))
                {
                    using (var jsonTextReader = new JsonTextReader(stringReader))
                    {
                        return serializer.Deserialize<T>(jsonTextReader);
                    }
                }
            }

            public static NewtonsoftJsonSerializer Default
            {
                get
                {
                    return new NewtonsoftJsonSerializer(new Newtonsoft.Json.JsonSerializer()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                    });
                }
            }

        }
    }
}
