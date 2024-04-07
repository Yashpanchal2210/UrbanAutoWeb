using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanAutoWeb.Service.Repo;

namespace UrbanAutoWeb.Service.Service.SuperAdmin
{
    public interface ISuperAdminRepository: IGenericRepository<UrbanAutoWeb.SuperAdmin>
    {
        bool Authenticate(string username, string password);
    }
}
