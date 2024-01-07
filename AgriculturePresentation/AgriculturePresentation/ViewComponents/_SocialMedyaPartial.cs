using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _SocialMedyaPartial:ViewComponent
	{
		private readonly ISocialMedyaService _socialMedyaService;

		public _SocialMedyaPartial(ISocialMedyaService socialMedyaService)
		{
			_socialMedyaService = socialMedyaService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _socialMedyaService.GetListAll();
			return View(values);
		}
	}
}
