﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            if (DateTime.Now.Hour == 02)
            {
                return new ErrorDataResult<Brand>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == brandId), Messages.BrandGottenById);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
            
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {

            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);

        }


        [ValidationAspect(typeof(BrandValidator))]
        public IResult Delete(Brand brand)
        {

            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
    }
}
