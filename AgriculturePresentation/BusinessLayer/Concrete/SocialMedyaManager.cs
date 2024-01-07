using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class SocialMedyaManager : ISocialMedyaService
	{
		private readonly ISocialMedyaDal _socialMedya;

		public SocialMedyaManager(ISocialMedyaDal socialMedya)
		{
			_socialMedya = socialMedya;
		}

		public void Delete(SocialMedia t)
		{
			_socialMedya.Delete(t);
		}

		public SocialMedia GetById(int id)
		{
			return _socialMedya.GetById(id);
		}

		public List<SocialMedia> GetListAll()
		{
			return _socialMedya.GetListAll();
		}

		public void Insert(SocialMedia t)
		{
			_socialMedya.Insert(t);
		}

		public void Update(SocialMedia t)
		{
			_socialMedya.Update(t);
		}
	}
}
