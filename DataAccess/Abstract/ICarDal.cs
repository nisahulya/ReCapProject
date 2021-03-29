using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();

        List<CarDetailDto> GetCarDetailsByCarId();

        List<CarDetailDto> GetCarDetailsByBrandId(Expression<Func<Car, bool>> filter);

        List<CarDetailDto> GetCarDetailsByColorId(Expression<Func<Car, bool>> filter);
    }
}
