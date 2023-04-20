using CowboyApi.Classes;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CowboyApi.Services
{
    public class OpenAIService
    {

        private readonly HttpClient _client;
        public OpenAIService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://api.openai.com/v1/chat/completions");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SystemVariables.OpenAIKey);
        }

        public async Task<string> GetRandomData(string input)
        {

            var message = new OpenAIRequestMessageBuilder().CreateMessage(input);

            var response = await _client.SendAsync(message);

            return "";

        }




    }


    public class OpenAIRequestMessageBuilder 
    {
        public OpenAIRequestMessageBuilder()
        {
            Messages = new List<OpenAIMessage>();
           
        }
        public string Model { get; set; } = "gpt-3.5-turbo";
        public List<OpenAIMessage> Messages { get; } 

        public double Temperature { get; set; } = 0.7;


        public HttpRequestMessage CreateMessage(string input)
        {

            var message = new OpenAIMessage
            {
                Content = input
            };

            Messages.Add(message);

            var json = JsonConvert.SerializeObject(this);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, string.Empty);

            requestMessage.Content = new StringContent(json);
            requestMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return requestMessage;
        }
    }

    public class OpenAIMessage
    {
        public string Role { get; set; } = "user";
        public string Content { get; set; }
        public string Name { get; set; }
    }

    public class OpenAIResponseMessage
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public DateTime Created{ get; set; }
        public string Model { get; set; }
        public OpenAIUsage Usage { get; set; }

    }


    public class OpenAIUsage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }

    }
}
