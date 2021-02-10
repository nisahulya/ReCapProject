using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{ CarId=1, BrandId=1, ColorId=1, DailyPrice=50, Description="Ford Araba", ModelYear=2010},
                new Car{ CarId=2, BrandId=4, ColorId=2, DailyPrice=100, Description="Renault Araba", ModelYear=2009},
                new Car{ CarId=3, BrandId=2, ColorId=3, DailyPrice=150, Description="Opel Araba", ModelYear=2015},
                new Car{ CarId=4, BrandId=3, ColorId=3, DailyPrice=100, Description="BMW Araba", ModelYear=2000}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int CarId)
        {
            Car carFindingId = _cars.SingleOrDefault(c => c.CarId == CarId);
            return carFindingId;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
           Car carToUpdate = _cars.SingleOrDefault(c=>c.CarId  == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
