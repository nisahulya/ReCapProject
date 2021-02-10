using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }

        public String BrandName { get; set; }
    }
}
