using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactService;

        public ContactManager(IContactDal contactService)
        {
            _contactService = contactService;
        }

        public void Delete(Contact t)
        {
            _contactService.Delete(t);
        }

        public Contact GetById(int id)
        {
           return _contactService.GetById(id);
        }

        public List<Contact> GetListAll()
        {
           return _contactService.GetListAll();
        }

        public void Insert(Contact t)
        {
            _contactService.Insert(t);
        }

        public void Update(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
