using Microsoft.AspNetCore.Mvc;

namespace Blogifier.Widgets
{
	[ViewComponent(Name = "Hello")]
	public class Hello : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}