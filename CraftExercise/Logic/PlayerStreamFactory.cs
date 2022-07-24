using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace CraftExercise.Logic
{
	public class PlayerStreamFactory
	{
		private readonly IConfiguration configuration;

		public PlayerStreamFactory(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public virtual Stream GetStream()
		{
			var path = this.configuration["PlayersFilePath"];
			return File.OpenRead(path);
		}

	}
}