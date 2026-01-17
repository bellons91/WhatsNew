using System.ComponentModel.DataAnnotations;

namespace WhatsNew.Tests
{
	[IncludeRandomSelection("New Model validation attributes")]
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
				var model = new MusicAlbum()
				{
					Name = "My album",
					Tracks = new[] { "Track1", "Track2" }
				};

				var validationResult = ModelValidationHelper.Validate(model);
				Assert.That(validationResult, Is.Empty);
			}

			[Test]
			[DotNet8]
			public void LengthValues_FailOnString()
			{
				var model = new MusicAlbum()
				{
					Name = "Hey",
					Tracks = new[] { "Track1", "Track2" }
				};

				var validationResult = ModelValidationHelper.Validate(model);
				Assert.That(validationResult, Is.Not.Empty);
			}

			[Test]
			[DotNet8]
			public void LengthValues_FailOnCollection()
			{
				var model = new MusicAlbum()
				{
					Name = "Hey you!",
					Tracks = new[] { "Track1" }
				};

				var validationResult = ModelValidationHelper.Validate(model);
				Assert.That(validationResult, Is.Not.Empty);
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
				var model = new MusicGenre() { Type = "rock" };

				var validationResult = ModelValidationHelper.Validate(model);
				Assert.That(validationResult, Is.Empty);
			}

			[Test]
			[DotNet8]
			public void DeniedValues_Fail()
			{
				var model = new MusicGenre() { Type = "trap" };

				var validationResult = ModelValidationHelper.Validate(model);
				Assert.That(validationResult, Is.Not.Empty);
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
				var model = new Person() { Role = "teacher" };
				var validationResult = ModelValidationHelper.Validate(model);
				Assert.That(validationResult, Is.Empty);
			}

			[Test]
			[DotNet8]
			public void AllowedValues_Fail()
			{
				var model = new Person() { Role = "worker" };
				var validationResult = ModelValidationHelper.Validate(model);
				Assert.That(validationResult, Is.Not.Empty);
			}

		}
		public class ModelValidationHelper
		{
			public static IList<ValidationResult> Validate(object model)
			{
				var results = new List<ValidationResult>();
				var validationContext = new ValidationContext(model, null, null);
				Validator.TryValidateObject(model, validationContext, results, true);
				if (model is IValidatableObject validatableModel)
					results.AddRange(validatableModel.Validate(validationContext));
				return results;
			}
		}
	}
}