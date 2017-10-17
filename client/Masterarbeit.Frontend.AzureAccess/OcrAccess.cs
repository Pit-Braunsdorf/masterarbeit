using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Masterarbeit.Frontend.Contracts;
using Masterarbeit.Shared.Contracts;
using Newtonsoft.Json;

namespace Masterarbeit.Frontend.AzureAccess
{
    public class OcrAccess
    {
        private readonly HttpClient _httpClient;

        private string uriBase = "https://westeurope.api.cognitive.microsoft.com/vision/v1.0/ocr";
        private string uriBase1 = "https://westeurope.api.cognitive.microsoft.com/vision/v1.0/generateThumbnail";
        private string subscriptionKey = "17c09c8becf94127bb1fcfcccc49b321";

        public OcrAccess(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public OCRResult SendAnalysisRequest(byte[] image)
        {
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);


            string requestParameters = "visualFeatures=Categories,Description,Color";
            var uri = uriBase + "?" + requestParameters;

            HttpResponseMessage response;

            using (var content = new ByteArrayContent(image))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = _httpClient.PostAsync(uri, content).Result;
                var contentString = response.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<OCRResult>(contentString);
            }
        }
        public byte[] CreateThumbnail(byte[] image)
        {
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);


            string requestParameters = "visualFeatures=Categories,Description,Color";
            var uri = uriBase + "?" + requestParameters;

            HttpResponseMessage response;

            using (var content = new ByteArrayContent(image))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = _httpClient.PostAsync(uri, content).Result;
                var contentString = response.Content.ReadAsByteArrayAsync().Result;

                return contentString;
            }
        }
    }
}
