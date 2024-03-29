﻿namespace WhatsNew.Tests
{
	public class About_Switch_Pattern_Matching_On_Type
	{
		[Test]
		[DotNetCore3]
		public void Accepts_type_in_case_branch()
		{
			string GetMessage(Media media)
			{
				switch (media)
				{
					case Video video: return "This is a video";
					default: return "This is a generic media";
				}
			}

			Assert.That(GetMessage(new Video()), Is.EqualTo("This is a video"));
			Assert.That(GetMessage(new Media()), Is.EqualTo("This is a generic media"));
		}

		[Test]
		[DotNetCore3]
		public void Can_use_when_clause()
		{
			string GetMessage(Media media)
			{
				switch (media)
				{
					case Video video when video.Duration > 5: return "This is a long video";
					case Video video: return "This is a video";
					default: return "This is a generic media";
				}
			}

			Assert.That(GetMessage(new Video { Duration = 15 }), Is.EqualTo("This is a long video"));
			Assert.That(GetMessage(new Video()), Is.EqualTo("This is a video"));
			Assert.That(GetMessage(new Media()), Is.EqualTo("This is a generic media"));
		}

		[Test]
		[DotNetCore3]
		public void Accepts_type_in_case_branch_short_syntax()
		{
			string GetMessage(Media media)
			{
				return media switch
				{
					Video _ => "This is a video",
					_ => "This is a generic media"
				};
			}

			Assert.That(GetMessage(new Video()), Is.EqualTo("This is a video"));
			Assert.That(GetMessage(new Media()), Is.EqualTo("This is a generic media"));
		}

		[Test]
		[DotNetCore3]
		public void With_filter_short_syntax()
		{
			string GetMessage(Media media)
			{
				return media switch
				{
					Video { Public: true } => "This is a public video",
					Video => "This is a video",
					_ => "This is a generic media"
				};
			}

			Assert.That(GetMessage(new Video { Public = true }), Is.EqualTo("This is a public video"));
			Assert.That(GetMessage(new Video()), Is.EqualTo("This is a video"));
			Assert.That(GetMessage(new Media()), Is.EqualTo("This is a generic media"));
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