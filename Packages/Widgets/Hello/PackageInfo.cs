using Blogifier.Core.Data.Models;
using System.Reflection;

public class PackageInfo : IPackageInfo
{
	public PackageListItem GetAttributes()
	{
		return new PackageListItem
		{
			Title = "Hello",
			Version = "1.0.0",
			Description = "Hello widget.",
			Icon = "https://avatars0.githubusercontent.com/u/19671571?v=4&amp;s=180",
			Author = "Tester",
			ProjectUrl = "https://github.com/blogifierdotnet/Blogifier",
			Tags = "widget,hello,test"
		};
	}
}