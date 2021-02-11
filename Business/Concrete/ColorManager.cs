using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintanceTime);
            }
            
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed); 
        }

        public IDataResult<Color> GetById(int colorId)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<Color>(Messages.MaintanceTime);
            }
            
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId), Messages.ColorGottenById);
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }
            
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }
        }

        public IResult Delete(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else
            {
                _colorDal.Delete(color);
                return new SuccessResult(Messages.ColorDeleted);
            }
        }
    }
}
