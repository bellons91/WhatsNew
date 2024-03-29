﻿namespace WhatsNew.Tests
{
	public class About_Pattern_Matching
	{
		[Test]
		[DotNet5]
		public void Can_use_keywords()
		{
			bool IsLetterOrSeparator(char inputChar) =>
	  inputChar is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';

			Assert.IsTrue(IsLetterOrSeparator('C'));
			Assert.IsTrue(IsLetterOrSeparator('.'));
			Assert.IsFalse(IsLetterOrSeparator('9'));
		}

		[Test]
		[DotNet5]
		public void Can_use_isnull()
		{
			string SelfOrMessage(string content)
			{
				if (content is not null) return content;
				return "error!";
			}

			Assert.That(SelfOrMessage("CIAO"), Is.EqualTo("CIAO"));
			Assert.That(SelfOrMessage(string.Empty), Is.EqualTo(""));
			Assert.That(SelfOrMessage(null), Is.EqualTo("error!"));
		}

		[Test]
		[DotNet7]
		public void Can_use_list_pattern()
		{
			string SelfOrMessage(int[] values)
			{
				if (values is [1, 2, 3]) return "OK";
				return "error!";
			}

			Assert.That(SelfOrMessage(new int[] { 1, 2, 3 }), Is.EqualTo("OK"));
			Assert.That(SelfOrMessage(new int[] { 1, 2, 3, 4 }), Is.EqualTo("error!"));
		}

		[Test]
		[DotNet7]
		public void Can_use_list_pattern_with_slice()
		{
			string SelfOrMessage(int[] values)
			{
				if (values is [1, .., 3]) return "OK";
				return "error!";
			}

			Assert.That(SelfOrMessage(new int[] { 1, 2, 3 }), Is.EqualTo("OK"));
			Assert.That(SelfOrMessage(new int[] { 1, 2, 5, 8, 1, 3 }), Is.EqualTo("OK"));
			Assert.That(SelfOrMessage(new int[] { 1, 2, 3, 4 }), Is.EqualTo("error!"));
		}

		[Test]
		[DotNet7]
		public void Can_use_list_patterns_with_discard()
		{
			string SelfOrMessage(int[] values)
			{
				if (values is [_, 2, _]) return "OK";
				return "error!";
			}

			Assert.That(SelfOrMessage(new int[] { 1, 2, 3 }), Is.EqualTo("OK"));
			Assert.That(SelfOrMessage(new int[] { 1, 6, 2, 3 }), Is.EqualTo("error!"));
			Assert.That(SelfOrMessage(new int[] { 6, 3, 8, 4 }), Is.EqualTo("error!"));
		}

		[Test]
		[DotNet7]
		public void Can_use_list_patterns_with_var()
		{
			string SelfOrMessage(int[] values)
			{
				if (values is [_, 2, int third]) return "OK " + third;
				return "error!";
			}

			Assert.That(SelfOrMessage(new int[] { 1, 2, 3 }), Is.EqualTo("OK 3"));
			Assert.That(SelfOrMessage(new int[] { 1, 6, 2, 3 }), Is.EqualTo("error!"));
			Assert.That(SelfOrMessage(new int[] { 6, 3, 8, 4 }), Is.EqualTo("error!"));
		}

		[Test]
		[DotNet7]
		public void Can_use_list_patterns_with_condition()
		{
			string SelfOrMessage(int[] values)
			{
				if (values is [0 or 1, > 2, int third]) return "OK " + third;
				return "error!";
			}

			Assert.That(SelfOrMessage(new int[] { 0, 4, 3 }), Is.EqualTo("OK 3"));
			Assert.That(SelfOrMessage(new int[] { 6, 4, 3 }), Is.EqualTo("error!"));
			Assert.That(SelfOrMessage(new int[] { 1, 2, 3 }), Is.EqualTo("error!"));
			Assert.That(SelfOrMessage(new int[] { 1, 6, 2, 3 }), Is.EqualTo("error!"));
			Assert.That(SelfOrMessage(new int[] { 6, 3, 8, 4 }), Is.EqualTo("error!"));
		}
	}
}