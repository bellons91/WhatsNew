using System.ComponentModel.DataAnnotations;

namespace WhatsNew.Tests
{
	public class About_ModelValidationAttributes
	{

		public class LengthAttributeTests
		{
			public class MusicAlbum
			{
				[Length(4, 10)]
				public string Name { get; set; }

				[Length(2, 20)]
				public string[] Tracks { get; set; }
			}

			[Test]
			[DotNet8]
			public void LengthValues_Pass()
			{
				var mode = new MusicAlbum()
				{
					Name = "My rock album",
					Tracks = new[] { "Track1", "Track2" }
				};

				var res = ModelValidationHelper.Validate(mode);
				Assert.That(res, Is.Empty);
			}

			[Test]
			[DotNet8]
			public void LengthValues_FailOnString()
			{
				var mode = new MusicAlbum()
				{
					Name = "Hey",
					Tracks = new[] { "Track1", "Track2" }
				};

				var res = ModelValidationHelper.Validate(mode);
				Assert.That(res, Is.Not.Empty);
			}

			[Test]
			[DotNet8]
			public void LengthValues_FailOnCollection()
			{
				var mode = new MusicAlbum()
				{
					Name = "Hey you!",
					Tracks = new[] { "Track1" }
				};

				var res = ModelValidationHelper.Validate(mode);
				Assert.That(res, Is.Not.Empty);
			}
		}

		public class DeniedValuesAttributeTests
		{
			public class MusicGenre
			{

				[DeniedValues("trap", "bossanova")]
				public string Type { get; set; }
			}

			[Test]
			[DotNet8]
			public void DeniedValues_Pass()
			{
				var mode = new MusicGenre() { Type = "rock" };

				var res = ModelValidationHelper.Validate(mode);
				Assert.That(res, Is.Empty);
			}

			[Test]
			[DotNet8]
			public void DeniedValues_Fail()
			{
				var mode = new MusicGenre() { Type = "trap" };

				var res = ModelValidationHelper.Validate(mode);
				Assert.That(res, Is.Not.Empty);
			}

		}
		public class AllowedValuesAttributeTests
		{
			public class Person
			{

				[AllowedValues("teacher", "student")]
				public String Role { get; set; }
			}

			[Test]
			[DotNet8]
			public void AllowedValues_Pass()
			{
				var mode = new Person() { Role = "teacher" };

				var res = ModelValidationHelper.Validate(mode);
				Assert.That(res, Is.Empty);
			}

			[Test]
			[DotNet8]
			public void AllowedValues_Fail()
			{
				var mode = new Person() { Role = "worker" };

				var res = ModelValidationHelper.Validate(mode);
				Assert.That(res, Is.Not.Empty);
			}

		}
		public class ModelValidationHelper
		{
			public static IList<ValidationResult> Validate(object model)
			{
				var results = new List<ValidationResult>();
				var validationContext = new ValidationContext(model, null, null);
				Validator.TryValidateObject(model, validationContext, results, true);
				if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
				return results;
			}
		}
	}
}