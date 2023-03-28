using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace App1.Services
{
    public class RestService: IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        string restUrl = "http://192.168.0.15/{0}";

        public RestService()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Book>> GetBooks(string query)
        {
            List<Book> books = new List<Book>();
            Uri uri = new Uri(string.Format(restUrl, query));
            Debug.WriteLine(uri);
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    books = JsonSerializer.Deserialize<List<Book>>(content, serializerOptions);
                    Debug.WriteLine("Найдено книг:" + books.Count);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Debug.WriteLine("Сукаааааааааа");
            }

            return books;
        }
    }
}
