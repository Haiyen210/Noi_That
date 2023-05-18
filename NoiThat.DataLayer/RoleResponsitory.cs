using Microsoft.Extensions.Options;
using NoiThat.Services.Entity;
using NoiThat.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.DataLayer
{
    public class RoleResponsitory : BaseRepository<Role>,IRoleResponsitory
    {
        public RoleResponsitory(IOptions<InteriorDatabaseSettings> interiorDataSettings) : base(interiorDataSettings)
        {
        }
    }
}
