using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanAutoWeb.Service.Repo;

namespace UrbanAutoWeb.Service.Service.SuperAdmin
{
    public class SuperAdminRepository : GenericRepository<UrbanAutoWeb.SuperAdmin>, ISuperAdminRepository
    {
        private readonly UrbanAutoMasterContext _dbContext;

        public SuperAdminRepository(UrbanAutoMasterContext context) : base(context)
        {
            _dbContext = context;
        }

        public bool Authenticate(string username, string password)
        {
            bool result = false;

            var getUser = _dbContext.SuperAdmins.Where(x => x.Username.ToLower() == username.ToLower() &&
            x.Password == password).FirstOrDefault();

            if (getUser != null)
            {
                result = true;
            }

            return result;
        }
    }
}
