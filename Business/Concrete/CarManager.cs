using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }   

        public IResult Add(Car car)
        {
            if (car.DailyPrice<0)
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }    
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
            else
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
        }

        public IResult Delete(Car car)
        {
            if (car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
            else
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==brandId),Messages.CarGottenByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarGottenByColorId);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailsGotten);
        }

        public IDataResult<Car> GetById(int carId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Car>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.CarId == carId), Messages.CarGottenById);
        }
    }
}
