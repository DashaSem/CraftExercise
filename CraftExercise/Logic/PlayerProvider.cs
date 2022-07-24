using AutoMapper;
using CraftExercise.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CraftExercise.Logic
{
	public class PlayerProvider
	{
		private readonly IMapper mapper;
		private readonly PlayerStreamFactory playerStreamFactory;

		public PlayerProvider(IMapper mapper, PlayerStreamFactory playerStreamFactory)
		{
			this.mapper = mapper;
			this.playerStreamFactory = playerStreamFactory;
		}

		public virtual List<PlayerModel> GetPlayers()
		{
			using (var stream = this.playerStreamFactory.GetStream())
			using (var reader = new StreamReader(stream))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Context.RegisterClassMap<PlayerCsvDataMap>();
				var csvPlayers = csv.GetRecords<PlayerCsvData>();
				var players = this.mapper.Map<List<PlayerModel>>(csvPlayers);
				return players.ToList();
			}
		}
	}
}
