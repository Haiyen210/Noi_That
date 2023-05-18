using NoiThat.Services.Entity;
using NoiThat.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        public CategoryServices(IBaseResponsitory<Category> responsitory) : base(responsitory)
        {
        }
    }
}
