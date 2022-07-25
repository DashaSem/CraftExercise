using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CraftWebUI.Data
{
	public class PlayerApiConsumer
	{
		static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
		private readonly IConfiguration configuration;

		public PlayerApiConsumer(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task<PlayerModel[]> GetPlayersAsync()
		{
			var apiUrl = this.configuration["PlayersApiUrl"];
			return await this.GetFromApiAsync<PlayerModel[]>(apiUrl);
		}

		public async Task<PlayerModel> GetPlayerDetailsAsync(string playerId)
		{
			var apiUrl = this.configuration["PlayersApiUrl"];
			var playerUrl = $"{apiUrl}/{playerId}";
			return await this.GetFromApiAsync<PlayerModel>(playerUrl);
		}

		private async Task<T> GetFromApiAsync<T>(string url)
		{
			var client = new HttpClient();
			var response = await client.GetAsync(url);
			var responseAsString = await response.Content.ReadAsStringAsync();
			var data = JsonSerializer.Deserialize<T>(responseAsString, jsonOptions);
			return data;
		}
	}
}
