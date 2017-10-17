using DemoApp.HTTPClientDemo.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.HTTPClientDemo.Service
{
    public class ContextDataStore
    {
        HttpClient client;
        string RestUrl = "http://192.168.3.74:53470/api/values";
        public ContextDataStore()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }
        public async Task<bool> AddItemAsync(ContextModel item)
        {
            var uri = new Uri(RestUrl+ "/AddDate/");
            var json = JsonConvert.SerializeObject(item);
          //  var dic = JsonToDictionary.ToDictionary(json);
            //var content = new  FormUrlEncodedContent(dic);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(uri, content);


            if (response.IsSuccessStatusCode)
            {
                var date = await response.Content.ReadAsStringAsync();
                return Convert.ToBoolean(date);

            }
            return false;
        }

        public async Task<bool> UpdateItemAsync(ContextModel item)
        {

            var uri = new Uri(RestUrl + "/UpdateDate/");
            var json = JsonConvert.SerializeObject(item);
            //  var dic = JsonToDictionary.ToDictionary(json);
            //var content = new  FormUrlEncodedContent(dic);
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(uri, content);


            if (response.IsSuccessStatusCode)
            {
                var date = await response.Content.ReadAsStringAsync();
                return Convert.ToBoolean(date);

            }
            return false;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var uri = new Uri(string.Format(RestUrl + "/Delete/?id=" + id, string.Empty));
            var response = await client.DeleteAsync(uri);
           

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Convert.ToBoolean(content);

            }
            return false;
        }

        public async Task<IEnumerable<ContextModel>> GetItemsAsync(int page,int rows)
        {
            var uri = new Uri(string.Format(RestUrl+"/Get/?page="+page+ "&count=" + rows, string.Empty));
            var response = await client.GetAsync(uri);
            List<ContextModel> Items = new List<ContextModel>();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    Items = JsonConvert.DeserializeObject<List<ContextModel>>(content);
                }
                catch (Exception ex)
                {

                  
                }
               
            }
            return Items;
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }
    }
}
