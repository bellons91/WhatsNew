namespace WhatsNew.Tests
{
    public class T09_InterfacesWithConcreteImplementation
    {
        public interface IMediaDownloader
        {
            string Download(string type, string id);

            string DownloadVideo(string id) => Download("video", id);
        }

        [Test]
        [DotNetCore3]
        public void interface_uses_simplemethod()
        {
            IMediaDownloader mediaDownloader = new MediaDownloader();

            var content = mediaDownloader.Download("photo", "123");
            Assert.That(content, Is.EqualTo("I am a photo"));
        }

        [Test]
        [DotNetCore3]
        public void interface_uses_concreteImplementation()
        {
            IMediaDownloader mediaDownloader = new MediaDownloader();

            var content = mediaDownloader.DownloadVideo("123");
            Assert.That(content, Is.EqualTo("I am a video"));
        }

        public class MediaDownloader : IMediaDownloader
        {
            public string Download(string type, string id)
            {
                return $"I am a {type}";
            }
        }

        public record User(int Id, string Name);
    }
}