using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : IColorDal
    {
        public void Add(Entities.Concrete.Color entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Entities.Concrete.Color entity)
        {
            throw new NotImplementedException();
        }

        public Entities.Concrete.Color Get(Expression<Func<Entities.Concrete.Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Entities.Concrete.Color> GetAll(Expression<Func<Entities.Concrete.Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.Concrete.Color entity)
        {
            throw new NotImplementedException();
        }
    }
}
