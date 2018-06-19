using Blogifier.Core.Common;
using Blogifier.Core.Data.Domain;
using Blogifier.Core.Data.Interfaces;
using Blogifier.Core.Data.Models;
using Blogifier.Core.Middleware;
using Blogifier.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blogifier.Widgets.ProjectReference
{
	[Route("blogifier/widgets/[controller]")]
	public class ProjectReferenceController : Controller
	{
		IUnitOfWork _db;
		IJSONService _jsonService;
		static readonly string key = "PROJECTREFERENCE";

		public ProjectReferenceController(IUnitOfWork db, IJSONService jsonService)
		{
			_db = db;
			_jsonService = jsonService;
		}

		[HttpPut("SetValue")]
		public async Task SetValue([FromBody]CustomFieldItem item)
		{

			var info = new PackageInfo();
			var pck = info.GetAttributes();



			var value = FirstValue();

			if (value != null)
			{
				if (!value.Contains(item.CustomValue))
				{
					value = item.CustomValue;
					value = _jsonService.ObjectToJSONString(pck);
					await _db.CustomFields.SetCustomField(CustomType.Application, 0, item.CustomKey, value);
				}
			}
			else
			{
				await _db.CustomFields.SetCustomField(CustomType.Application, 0, item.CustomKey, item.CustomValue);
			}
		}
		[Authorize]
		[MustBeAdmin]
		[HttpPost]
		public async void SaveSettings(SettingsModel model)
		{
			await _db.CustomFields.SetCustomField(CustomType.Application, 0, key, _jsonService.ObjectToJSONString(model));
		}

		[Authorize]
		[MustBeAdmin]
		[HttpGet("settings")]
		public IActionResult Settings(string search = "")
		{
			var profile = _db.Profiles.Single(b => b.IdentityName == User.Identity.Name);

			//var emails = Emails();

			//if (!string.IsNullOrEmpty(search))
			//{
			//	emails = emails.Where(e => e.Contains(search)).ToList();
			//}

			dynamic settings = new SettingsModel();
			settings = _jsonService.JSONStringToObject<SettingsModel>(FirstValue());

			var info = new PackageInfo();

			var model = new AdminSettingsModel
			{
				Profile = profile,
				Settings = settings,
				PackageItem = info.GetAttributes()
			};

			return View("~/Views/Shared/Components/ProjectReference/Settings.cshtml", model);
		}

		//[Authorize]
		//[MustBeAdmin]
		//[HttpPut("remove/{id}")]
		//public async Task Remove(string id)
		//{
		//	var emails = Emails();
		//	if (emails != null && emails.Contains(id))
		//	{
		//		emails.Remove(id);
		//		await _db.CustomFields.SetCustomField(CustomType.Application, 0, key, string.Join(",", emails));
		//	}
		//}

		string FirstValue()
		{
			return _db.CustomFields.GetValue(CustomType.Application, 0, key);
		}
	}
}