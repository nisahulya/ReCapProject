using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    class Color : IEntity
    {
        public int ColorId { get; set; }

        public String ColorName { get; set; }
    }
}
