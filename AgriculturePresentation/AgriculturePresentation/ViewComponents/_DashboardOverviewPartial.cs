using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _DashboardOverviewPartial:ViewComponent
    {
        AgricultureContext c = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
            ViewBag.TeamCount = c.Teams.Count();
            ViewBag.serviceCount = c.Services.Count();
            ViewBag.messageCount=c.Contacts.Count();
            ViewBag.currentMonthMessage = c.Contacts.Where(x=>x.Date.Month == DateTime.Now.Month).Select(x=>x.Date).Count();

            ViewBag.announcementTrue=c.Annouoncements.Where(x=>x.Status==true).Count();
            ViewBag.announcementFalse=c.Annouoncements.Where(x=>x.Status==false).Count();

            ViewBag.urunPazarlama =c.Teams.Where(c=>c.Title== "deneme").Select(x=>x.PersonName).FirstOrDefault();
            ViewBag.bakliyatYonetimi =c.Teams.Where(c=>c.Title== "aaaa").Select(x=>x.PersonName).FirstOrDefault();
            ViewBag.sutUretici =c.Teams.Where(c=>c.Title== "bdeneme").Select(x=>x.PersonName).FirstOrDefault();
            ViewBag.gubreYonetimi =c.Teams.Where(c=>c.Title== "ddeneme").Select(x=>x.PersonName).FirstOrDefault();

            return View();
        }
    }
}
