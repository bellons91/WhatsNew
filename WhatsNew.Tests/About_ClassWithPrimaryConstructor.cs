namespace WhatsNew.Tests
{
	public class About_ClassWithPrimaryConstructor
	{

		[Test]
		[DotNet8]
		public void Defines_Default_Fields()
		{
			var me = new User(1, "Davide");

			Assert.That(me.Id, Is.EqualTo(1));
			Assert.That(me.Name, Is.EqualTo("Davide"));
		}


		//[Test]
		//[DotNet8]
		//public void Defines_Parameterless_Constructor()
		//{
		//	var me = new User();
		//	me.Id = 1;
		//	me.Name = "Davide";
		//	Assert.That(me.Id, Is.EqualTo(1));
		//	Assert.That(me.Name, Is.EqualTo("Davide"));
		//}


		internal class User(int id, string name)
		{
			public int Id { get { return id; } }
			public string Name { get { return name; } }
			public string LastName { get; set; }


			//can we use a secondary constructor?

			//public User(int id, string name, string lastName)
			//{
			//	Id = id;
			//	Name = name;
			//	LastName = lastName;
			//}
		}
	}
}