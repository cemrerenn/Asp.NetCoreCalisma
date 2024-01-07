using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAnnouncementDal : GenericRepository<Annouoncement>, IAnnouoncementDal
    {
        public void AnnouncementStatusToFalse(int id)
        {
            using var context = new AgricultureContext();
            var p = context.Annouoncements.Find(id);
            p.Status = false;
            context.SaveChanges();
        }

        public void AnnouncementStatusToTrue(int id)
        {
            using var context = new AgricultureContext();
            var p = context.Annouoncements.Find(id);
            p.Status= true;
            context.SaveChanges();
        }
    }
}
