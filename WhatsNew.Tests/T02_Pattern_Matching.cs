namespace WhatsNew.Tests
{
    public class T02_Pattern_Matching
    {
        [Test]
        public void switch_accepts_type_in_case_branch()
        {
            string GetMessage(Media media)
            {
                switch (media)
                {
                    case Video video: return "This is a video";
                    default: return "This is not a video";
                }
            }

            Assert.That(GetMessage(new Video()), Is.EqualTo("This is a video"));
            Assert.That(GetMessage(new Media()), Is.EqualTo("This is not a video"));
        }

        [Test]
        public void switch_can_use_when_clause()
        {
            string GetMessage(Media media)
            {
                switch (media)
                {
                    case Video video when video.Duration > 5: return "This is a long video";
                    case Video video: return "This is a video";
                    default: return "This is not a video";
                }
            }

            Assert.That(GetMessage(new Video { Duration = 15 }), Is.EqualTo("This is a long video"));
            Assert.That(GetMessage(new Video()), Is.EqualTo("This is a video"));
            Assert.That(GetMessage(new Media()), Is.EqualTo("This is not a video"));
        }

        [Test]
        [Description("From C#8")]
        public void switch_accepts_type_in_case_branch_short_syntax()
        {
            string GetMessage(Media media)
            {
                return media switch
                {
                    Video _ => "This is a video",
                    _ => "This is not a video"
                };
            }

            Assert.That(GetMessage(new Video()), Is.EqualTo("This is a video"));
            Assert.That(GetMessage(new Media()), Is.EqualTo("This is not a video"));
        }

        [Test]
        public void switch_with_filter_short_syntax()
        {
            string GetMessage(Media media)
            {
                return media switch
                {
                    Video { Public: true } => "This is a public video",
                    Video => "This is a video",
                    _ => "This is not a video"
                };
            }

            Assert.That(GetMessage(new Video { Public = true }), Is.EqualTo("This is a public video"));
            Assert.That(GetMessage(new Video()), Is.EqualTo("This is a video"));
            Assert.That(GetMessage(new Media()), Is.EqualTo("This is not a video"));
        }

        public class Media
        {
            public string Url { get; set; }
        }

        public class Video : Media
        {
            public int Duration { get; set; }
            public bool Public { get; set; }
        }
    }
}