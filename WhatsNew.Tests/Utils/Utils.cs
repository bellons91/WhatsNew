namespace WhatsNew.Tests.Utils
{
	public static class Utils
	{
		public static IEnumerable<T> Shuffle<T>(IEnumerable<T> items)
		{
			Random rd = new Random();
			return items.OrderBy(_ => rd.Next());
		}


	}


	[AttributeUsage(AttributeTargets.Class)]
    public class IncludeRandomSelectionAttribute : Attribute
	{
        public IncludeRandomSelectionAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }


    public class DotNetCore3Attribute : CategoryAttribute
	{
		public DotNetCore3Attribute() : base(".NET Core 3, C# 8")
		{
		}
	}

	public class DotNet5Attribute : CategoryAttribute
	{
		public DotNet5Attribute() : base(".NET 5, C# 9")
		{
		}
	}

	public class DotNet6Attribute : CategoryAttribute
	{
		public DotNet6Attribute() : base(".NET 6, C# 10")
		{
		}
	}

	public class DotNet7Attribute : CategoryAttribute
	{
		public DotNet7Attribute() : base(".NET 7, C# 11")
		{
		}
	}
	public class DotNet8Attribute : CategoryAttribute
	{
		public DotNet8Attribute() : base(".NET 8, C# 12")
		{
		}
	}

    public class DotNet9Attribute : CategoryAttribute
    {
        public DotNet9Attribute() : base(".NET 9, C# 13")
        {
        }
    }
 
}