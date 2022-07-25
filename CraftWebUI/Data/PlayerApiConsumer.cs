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
			var client = new HttpClient();
			var response = await client.GetAsync(apiUrl);
			var responseAsString = await response.Content.ReadAsStringAsync();
			var players = JsonSerializer.Deserialize<PlayerModel[]>(responseAsString, jsonOptions);
			return players;
		}
	}
}
