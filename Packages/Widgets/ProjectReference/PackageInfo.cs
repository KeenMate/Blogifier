﻿using Blogifier.Core.Data.Models;
using System.Reflection;

public class PackageInfo : IPackageInfo
{
	public PackageListItem GetAttributes()
	{
		return new PackageListItem
		{
			Title = "Project Reference",
			ControllerName = "ProjectReference",
			Version = "1.0.0",
			Description = "Project reference that shows what have we done.",
			Icon = "https://avatars0.githubusercontent.com/u/19671571?v=4&amp;s=180",
			Author = "Jakub Šenk",
			ProjectUrl = "",
			Tags = "project,reference,github,code"
		};
	}
}