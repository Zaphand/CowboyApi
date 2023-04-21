using CowboyApi.Contracts;
using CowboyApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CowboyClientLib.Services
{
	internal class CowboyRepositoryService : ICowboyRepository
	{

		private readonly HttpClient _client;
		public CowboyRepositoryService(HttpClient client)
		{
			_client = client;

		}

		public Task Add(Cowboy entity)
		{
			throw new NotImplementedException();
		}

		public Task AddRange(IEnumerable<Cowboy> entity)
		{
			throw new NotImplementedException();
		}

		public async Task<Cowboy> Create(UserInfo userInfo)
		{
			var message = new HttpRequestMessage(HttpMethod.Post, "/Cowboy/Create");
			message.Content = new StringContent(JsonConvert.SerializeObject(userInfo));

			message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

			var response = await _client.SendAsync(message);

			if (!response.IsSuccessStatusCode)
			{
				return default;
			}

			var jsonContent = await response.Content.ReadAsStringAsync();

			var data = JsonConvert.DeserializeObject<Cowboy>(jsonContent);

            return data ?? default;
		}

		public Task<IEnumerable<Cowboy>> List()
		{
			throw new NotImplementedException();
		}

		public Task<bool> Remove(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Cowboy>> Shoot(Guid cowboyShootingId, Guid cowboyGettingShotId)
		{
			throw new NotImplementedException();
		}

		public Task<Cowboy> Single(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<Cowboy> Update(Cowboy entity)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Cowboy>> UpdateRange(IEnumerable<Cowboy> entity)
		{
			throw new NotImplementedException();
		}
	}
}
