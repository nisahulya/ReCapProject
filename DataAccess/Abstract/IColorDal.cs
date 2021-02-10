using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Entities.Concrete.Color>
    {
    }
}
