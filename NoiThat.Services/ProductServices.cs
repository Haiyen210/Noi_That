using NoiThat.Services.Entity;
using NoiThat.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services
{
    
    public class ProductServices : BaseServices<Product>, IProductServices
    {
        IProductResponsitory _productResponsitory;
        public ProductServices(IBaseResponsitory<Product> responsitory, IProductResponsitory productResponsitory) : base(responsitory)
        {
            _productResponsitory = productResponsitory;
        }

        public List<Product> GetProducts()
        {
            return _productResponsitory.GetProduct().ToList();
        }
    }
}
