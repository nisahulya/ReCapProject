using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
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


        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }
           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
           
             _carDal.Add(car);
             return new SuccessResult(Messages.CarAdded);
               
        }


        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }


        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.BrandId==brandId),Messages.CarGottenByBrandId);
        }


        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByBrandId(c=>c.BrandId==brandId), Messages.CarGottenByBrandId);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByColorId(c => c.ColorId == colorId), Messages.CarGottenByColorId);
        }



        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarGottenByColorId);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailsGotten);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails().Where(c => c.CarId == carId).ToList());
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByFilter(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByCarId().Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList());
        }


        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int carId)
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<Car>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c=> c.CarId == carId), Messages.CarGottenById);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 50)
            {
                throw new Exception("");
            }
            Add(car);

            return null;
        }

        public IDataResult<List<CarForRentalDto>> GetCarForRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<CarForRentalDto>>(_carDal.GetCarForRentalByCarId().Where(c => c.CarId == carId).ToList());
        }

    }
}
