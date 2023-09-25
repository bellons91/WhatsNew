using JO = System.Text.Json.JsonSerializerOptions;
using JSON = System.Text.Json;

namespace WhatsNew.Tests
{
	public class About_AliasOnTypes
	{
		[Test]
		[DotNet8]
		public void Can_UseAliases_OnTypes()
		{
			JO options = new JO { PropertyNameCaseInsensitive = true };
			var me = new { Name = "Davide", LastName = "Bellone" };

			var serialized = JSON.JsonSerializer.Serialize(me, options);
			Assert.Pass();
		}
	}
}