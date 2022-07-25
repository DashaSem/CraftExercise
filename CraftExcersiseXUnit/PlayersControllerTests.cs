using CraftExercise;
using CraftExercise.Controllers;
using CraftExercise.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System.IO;
using System.Linq;
using Xunit;

namespace CraftExcersiseXUnit
{
	public class PlayersControllerTests
	{
		private readonly PlayersController playersController;
		//test data
		const string FileContentWithNoPlayers = "";
		const string FileContentWithTwoPlayers = @"playerID,birthYear,birthMonth,birthDay,birthCountry,birthState,birthCity,deathYear,deathMonth,deathDay,deathCountry,deathState,deathCity,nameFirst,nameLast,nameGiven,weight,height,bats,throws,debut,finalGame,retroID,bbrefID
aardsda01,1981,12,27,USA,CO,Denver,,,,,,,David,Aardsma,David Allan,215,75,R,R,2004-04-06,2015-08-23,aardd001,aardsda01
aaronha01,1934,2,5,USA,AL,Mobile,,,,,,,Hank,Aaron,Henry Louis,180,72,R,R,1954-04-13,1976-10-03,aaroh101,aaronha01
";
		const string playerID = "aaronha01";
		const string notValidPlayerID = "001";

		string FileContent;

		public PlayersControllerTests()
		{
			var services = new ServiceCollection();
			//services.AddTransient<IMatchRepository, MatchRepositoryStub>();
			new Startup(null).ConfigureServices(services);

			var moqPlayerStreamFactory = new Mock<PlayerStreamFactory>(null);
			moqPlayerStreamFactory
				.Setup(o => o.GetStream())
				.Returns(() => MakeStreamFrom(FileContent));
			services.AddSingleton<PlayerStreamFactory>(moqPlayerStreamFactory.Object);

			services.AddSingleton(new Mock<ILogger<PlayersController>>().Object);
			services.AddSingleton<PlayersController>();

			var serviceProvider = services.BuildServiceProvider();

			playersController = serviceProvider.GetService<PlayersController>();
			var pp = serviceProvider.GetService<PlayerProvider>();
		}

		private static Stream MakeStreamFrom(string s)
		{
			var stream = new MemoryStream();
			var writer = new StreamWriter(stream);
			writer.Write(s);
			writer.Flush();
			stream.Position = 0;
			return stream;
		}

		[Fact]
		public void EmptyFileTest()
		{
			// Arrange
			this.FileContent = FileContentWithNoPlayers;

			//Act
			var players = this.playersController.Get();

			// Assert
			Assert.Empty(players);
		}

		[Fact]
		public void GetAllPlayers()
		{
			// Arrange
			this.FileContent = FileContentWithTwoPlayers;

			//Act
			var players = this.playersController.Get();

			// Assert
			Assert.Equal(2, players.Count());			
		}

		[Fact]
		public void GetPlayerByID()
		{
			// Arrange
			this.FileContent = FileContentWithTwoPlayers;

			//Act
			var player = this.playersController.Get(playerID);
			
			// Assert
			Assert.NotNull(player);
			Assert.Contains("Hank", player.Value.NameFirst);
		}

		[Fact]
		public void NoExistingPlayer()
		{
			// Arrange
			this.FileContent = FileContentWithTwoPlayers;

			//Act
			var player = this.playersController.Get(notValidPlayerID);

			// Assert
			Assert.True(player.Result is Microsoft.AspNetCore.Mvc.NoContentResult);
		}
	}
}
