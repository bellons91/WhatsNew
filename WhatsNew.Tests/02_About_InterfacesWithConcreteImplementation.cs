namespace WhatsNew.Tests
{
	public class About_InterfacesWithConcreteImplementation
	{
		public interface IMediaDownloader
		{
			string Download(string type, string id);

			string DownloadVideo(string id) => Download("video", id);
		}

        public class PartialMediaDownloader : IMediaDownloader
        {
            public string Download(string type, string id) => $"I am a {type}";
        }

        public class FullMediaDownloader : IMediaDownloader
        {
            public string Download(string type, string id) => $"Full download of {type}";
			public string DownloadVideo(string id) => "Full video download";
        }


        [Test]
		[DotNetCore3]
		public void Interface_uses_simplemethod()
		{
			IMediaDownloader mediaDownloader = new PartialMediaDownloader();

			var content = mediaDownloader.Download("photo", "123");
			Assert.That(content, Is.EqualTo("I am a photo"));
		}

		[Test]
		[DotNetCore3]
		public void Interface_uses_concreteImplementation()
		{
			IMediaDownloader mediaDownloader = new PartialMediaDownloader();

			var content = mediaDownloader.DownloadVideo("123");
			Assert.That(content, Is.EqualTo("I am a video"));
		}
	}
}