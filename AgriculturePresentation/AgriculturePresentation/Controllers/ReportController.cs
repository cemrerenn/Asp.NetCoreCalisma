using AgriculturePresentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AgriculturePresentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticReport() //EPPlus kurulur
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workbook = excelPackage.Workbook.Worksheets.Add("Dosya1");
            workbook.Cells[1,1].Value = "Ürün Adı";
            workbook.Cells[1,2].Value = "Ürün Kategorisi";
            workbook.Cells[1,3].Value = "Ürün Stok";

            workbook.Cells[2, 1].Value = "Mercimek";
            workbook.Cells[2, 2].Value = "Bakliyat";
            workbook.Cells[2, 3].Value = "750 kg";

            workbook.Cells[3, 1].Value = "Buğday";
            workbook.Cells[3, 2].Value = "Bakliyat";
            workbook.Cells[3, 3].Value = "1986 kg";

            workbook.Cells[4, 1].Value = "Havuç";
            workbook.Cells[4, 2].Value = "Sebze";
            workbook.Cells[4, 3].Value = "167 kg";

            var bytes =excelPackage.GetAsByteArray();
            return File(bytes,"application/vnd-openxmlformats-officedocument.spreadsheetml.sheet","BakliyatRaporu.xlsx");
        }

        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            using(var context = new AgricultureContext()) 
            {
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactID = x.ContactID,
                    ContactName=x.Name,
                    ContactMail=x.Mail,
                    ContactMessage=x.Message,
                    ContactDate=x.Date
                }).ToList();
            }
            return contactModels;
        }
        public IActionResult ContactReport() 
        {
            using (var workbook =new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Mesaj Listesi");
                worksheet.Cell(1, 1).Value = "Mesaj Id";
                worksheet.Cell(1, 2).Value = "Mesaj Gönderen";
                worksheet.Cell(1, 3).Value = "Mesaj Mail";
                worksheet.Cell(1, 4).Value = "Mesaj İçeriği";
                worksheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    worksheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    worksheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    worksheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    worksheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    worksheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;

                }

                using(var stream = new MemoryStream()) 
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd-openxmlformats-officedocument.spreadsheetml.sheet", "MesajRapor.xlsx");
                }
            }
              
        }

        public List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
            using (var context = new AgricultureContext())
            {
                announcementModels = context.Annouoncements.Select(x => new AnnouncementModel
                {
                   Id=x.AnnouoncementID,
                   Status=x.Status,
                   Date=x.Date,
                   Description=x.Description,
                   Title=x.Title
                }).ToList();
            }
            return announcementModels;
        }

        public IActionResult AnnouncementReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Duyuru Listesi");
                worksheet.Cell(1, 1).Value = "Duyuru Id";
                worksheet.Cell(1, 2).Value = "Duyuru Başlığı";
                worksheet.Cell(1, 3).Value = "Duyuru Tarihi";
                worksheet.Cell(1, 4).Value = "Duyuru İçeriği";
                worksheet.Cell(1, 5).Value = "Durum";

                int contactRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    worksheet.Cell(contactRowCount, 1).Value = item.Id;
                    worksheet.Cell(contactRowCount, 2).Value = item.Title;
                    worksheet.Cell(contactRowCount, 3).Value = item.Date;
                    worksheet.Cell(contactRowCount, 4).Value = item.Description;
                    worksheet.Cell(contactRowCount, 5).Value = item.Status;
                    contactRowCount++;

                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd-openxmlformats-officedocument.spreadsheetml.sheet", $"{DateTime.Now.ToShortDateString()}_TarihliRapor.xlsx");
                }
            }

        }
    }
}
