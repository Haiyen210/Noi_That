﻿using NoiThat.Services.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services.Interface
{
    public interface IProductResponsitory:IBaseResponsitory<Product>
    {

        List<Product> GetProduct();
    }
}
