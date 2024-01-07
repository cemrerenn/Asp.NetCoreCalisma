using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AnnouncementManager :  IAnnouncementService
    {
        public readonly IAnnouoncementDal _annouoncementDal;

        public AnnouncementManager(IAnnouoncementDal annouoncementDal)
        {
            _annouoncementDal = annouoncementDal;
        }

        public void AnnouncementStatusToFalse(int id)
        {
           _annouoncementDal.AnnouncementStatusToFalse(id);
        }

        public void AnnouncementStatusToTrue(int id)
        {
            _annouoncementDal.AnnouncementStatusToTrue(id);
        }

        public void Delete(Annouoncement t)
        {
            _annouoncementDal.Delete(t);
        }

        public void Insert(Annouoncement t)
        {
           _annouoncementDal.Insert(t);
        }

        public void Update(Annouoncement t)
        {
           _annouoncementDal.Update(t);
        }

        Annouoncement IGenericService<Annouoncement>.GetById(int id)
        {
            return _annouoncementDal.GetById(id);
        }

        List<Annouoncement> IGenericService<Annouoncement>.GetListAll()
        {
           return _annouoncementDal.GetListAll();
        }
    }
}
