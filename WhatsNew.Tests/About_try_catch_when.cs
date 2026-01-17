namespace WhatsNew.Tests
{
	[IncludeRandomSelection("try-catch with 'when' clause")]
    public class About_try_catch_when
	{
		[Test]
		[DotNetCore3]
		public async Task Catch_exception_by_condition()
		{
			async Task<string> CallEndpoint(string value)
			{
				try
				{
					ArgumentException.ThrowIfNullOrEmpty(value);

					var httpClient = new HttpClient();
					var response = await httpClient.GetAsync(value);
					response.EnsureSuccessStatusCode();

					return "OK";
				}
				catch (HttpRequestException ex)
					when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					return "Page not found";
				}
				catch (HttpRequestException ex)
				{
					return "Another HTTP Error";
				}
				catch (Exception)
				{
					return "Unknown error";
				}
			}

			var okResult = await CallEndpoint("https://www.code4it.dev/");
			Assert.That(okResult, Is.EqualTo("OK"));

			var notFoundResult = await CallEndpoint("https://www.code4it.dev/non-existing-page");
			Assert.That(notFoundResult, Is.EqualTo("Page not found"));

			var anotherHttpErrorResult = await CallEndpoint("https://www.code4it-invalidHost.dev/");
			Assert.That(anotherHttpErrorResult, Is.EqualTo("Another HTTP Error"));

			var genericErrorResult = await CallEndpoint("");
			Assert.That(genericErrorResult, Is.EqualTo("Unknown error"));
		}
	}
}