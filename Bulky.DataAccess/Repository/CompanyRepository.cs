using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class CompanayRepository : Repository<Company> , ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanayRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public void Update(Company  obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
