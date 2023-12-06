using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace KI6LCZ_HFT_2023241.Client
{
    public class RestService
    {
        HttpClient httpClient;

        public RestService(string temp)
        {
            Init(temp);
        }
        private void Init(string temp)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(temp);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                httpClient.GetAsync("").GetAwaiter().GetResult();
            }
            catch (HttpRequestException)
            {
                throw new ArgumentException("Endpoint isn't available!");
            }
        }
        public List<T> Get<T>(string endpoint)
        {
            List<T> items = new List<T>();
            HttpResponseMessage response = httpClient.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                items = response.Content.ReadAsAsync<List<T>>().GetAwaiter().GetResult();
            }
            return items;
        }
        public T GetSingle<T>(string endpoint)
        {
            T item = default(T);
            HttpResponseMessage response = httpClient.GetAsync(endpoint).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }
            return item;
        }
        public T Get<T>(int id, string endpoint)
        {
            T item = default(T);
            HttpResponseMessage response = httpClient.GetAsync(endpoint + "/" + id.ToString()).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                item = response.Content.ReadAsAsync<T>().GetAwaiter().GetResult();
            }
            return item;
        }
        public void Post<T>(T item, string endpoint)
        {
            HttpResponseMessage response =
                httpClient.PostAsJsonAsync(endpoint, item).GetAwaiter().GetResult();

            response.EnsureSuccessStatusCode();
        }
        public void Delete(int id, string endpoint)
        {
            HttpResponseMessage response =
                httpClient.DeleteAsync(endpoint + "/" + id.ToString()).GetAwaiter().GetResult();

            response.EnsureSuccessStatusCode();
        }
        public void Put<T>(T item, string endpoint)
        {
            HttpResponseMessage response =
                httpClient.PutAsJsonAsync(endpoint, item).GetAwaiter().GetResult();


            response.EnsureSuccessStatusCode();
        }
    }
}
