using Blogifier.Core.Data.Domain;
using Blogifier.Core.Data.Interfaces;
using Blogifier.Core.Data.Models;
using Blogifier.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogifier.Widgets.ProjectReference
{
	[ViewComponent(Name = "ProjectReference")]
	public class ProjectReference : ViewComponent
	{
		IUnitOfWork _db;
		IJSONService _jsonService;
		public ProjectReference(IUnitOfWork db, IJSONService jsonService)
		{
			_db = db;
			_jsonService = jsonService;
		}

		public IViewComponentResult Invoke()
		{
			string m = FirstValue();
			var parsedJson = _jsonService.JSONStringToObject<PackageListItem>(m);
			return View(model: m);
		}
		string FirstValue()
		{
			return _db.CustomFields.GetValue(CustomType.Application, 0, "PROJECTREFERENCE");
		}
	}
}