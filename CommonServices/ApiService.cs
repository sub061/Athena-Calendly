using Azure;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Medical_Athena_Calendly.CommonServices
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<TResponse> GetAsync<TResponse>(string apiUrl, string accessToken = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);

            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<TResponse>();
                //var responseObject = JsonConvert.DeserializeObject<TResponse>(responseData["resource"][0]);
                return responseData;
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        //Dictionary<string, string> formData
        public async Task<TResponse> PostAsync<TResponse>(string url, Dictionary<string, string> formData, string authHeader = null)
        {
            var content = new FormUrlEncodedContent(formData);

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = content;

            // if access tokan avaliable then need to append in Header section
            if (authHeader != null)
            {
                // We use Bearer Tokan
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
            }

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
            return responseObject;
        }
        public async Task<TResponse> PostLoginAsync<TRequest, TResponse>(string url, TRequest request, string authHeader = null)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // if access tokan avaliable then need to append in Header section
                if (authHeader != null)
                {
                    // We use Bearer Tokan
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",authHeader);
                }
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<TResponse>(jsonResponse);

                return responseObject;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while making the API request.", ex);
            }
            finally
            {
                _httpClient.DefaultRequestHeaders.Authorization = null; // Reset authorization header
            }


        }
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest request, string accessToken = null)
        {
            try
            {
                var jsonRequest = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                // if access tokan avaliable then need to append in Header section
                if (accessToken != null)
                {
                    // We use Bearer Tokan
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<TResponse>(jsonResponse);

                return responseObject;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while making the API request.", ex);
            }
            finally
            {
                _httpClient.DefaultRequestHeaders.Authorization = null; // Reset authorization header
            }
           

        }
    }
}
