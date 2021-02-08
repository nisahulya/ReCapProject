using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Entities.Concrete.Color>
    {
    }
}
