using AutoMapper;
using CraftExercise.Logic;
using CraftExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CraftExercise.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PlayersController : ControllerBase
	{
		private readonly ILogger<PlayersController> _logger;
		private readonly PlayerProvider playerProvider;

		public PlayersController(ILogger<PlayersController> logger, PlayerProvider playerProvider)
		{
			this._logger = logger;
			this.playerProvider = playerProvider;
		}

		[HttpGet]
		public IEnumerable<PlayerModel> Get()
		{
			return this.playerProvider.GetPlayers();
		}

		[HttpGet("{id}")]
		public ActionResult<PlayerModel> Get(string id)
		{
			var player = this.playerProvider.GetPlayers().FirstOrDefault(p => p.PlayerID == id);
			if (player != null)
			{
				return player;
			}
			else
			{
				return NoContent();
			}
		}
	}
}
