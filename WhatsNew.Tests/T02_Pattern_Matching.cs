﻿using WhatsNew.Tests.Utils;

namespace WhatsNew.Tests
{
    public class T15_Pattern_Matching
    {
        [Test]
        [DotNet5]
        public void can_use_keywords()
        {
            bool IsLetterOrSeparator(char c) =>
      c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';

            Assert.IsTrue(IsLetterOrSeparator('C'));
            Assert.IsTrue(IsLetterOrSeparator('.'));
            Assert.IsFalse(IsLetterOrSeparator('9'));
        }

        [Test]
        [DotNet5]
        public void can_use_isnull()
        {
            string SelfOrMessage(string s)
            {
                if (s is not null) return s;
                return "error!";
            }

            Assert.That(SelfOrMessage("CIAO"), Is.EqualTo("CIAO"));
            Assert.That(SelfOrMessage(null), Is.EqualTo("error!"));
        }

        [Test]
        [DotNet7]
        public void can_use_list_pattern()
        {
            string SelfOrMessage(int[] s)
            {
                if (s is [1, 2, 3]) return "CIAO";
                return "error!";
            }

            Assert.That(SelfOrMessage(new int[] { 1, 2, 3 }), Is.EqualTo("CIAO"));
            Assert.That(SelfOrMessage(new int[] { 1, 2, 3, 4 }), Is.EqualTo("error!"));
        }
    }

    public class T02_Switch_Pattern_Matching
    {
        [Test]
        [DotNetCore3]
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
        [DotNetCore3]
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
        [DotNetCore3]
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
        [DotNetCore3]
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