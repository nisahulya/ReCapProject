using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Business.Constants;
using System.Linq;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard entity)
        {
            IResult result = BusinessRules.Run(CheckIfCardIsExists(entity.CreditCardNumber));
            if (result != null)
            {
                return result;
            }
            _creditCardDal.Add(entity);
            return new SuccessResult("Kredi Kartı" + Messages.Added);
        }


        public IResult Delete(CreditCard entity)
        {
            _creditCardDal.Delete(entity);
            return new SuccessResult("Kredi Kartı" + Messages.Deleted);
        }

        public IResult DeleteById(int cardId)
        {
            var card = _creditCardDal.Get(x => x.Id == cardId);
            _creditCardDal.Delete(card);
            return new SuccessResult("Kredi Kartı" + Messages.DeletedByCarId);
        }

        public IDataResult<CreditCard> FindByID(int Id)
        {
            CreditCard p = new CreditCard();
            if (!_creditCardDal.GetAll().Any(x => x.Id == Id))
            {
                return new ErrorDataResult<CreditCard>(Messages.NotExist + "Kredi Kartı");
            }
            p = _creditCardDal.GetAll().FirstOrDefault(x => x.Id == Id);
            return new SuccessDataResult<CreditCard>(p);
        }

        public IDataResult<CreditCard> Get(CreditCard entity)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(x => x.Id == entity.Id));
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetAllCreditCardByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll().Where(x => x.CustomerId == customerId).ToList());
        }


        public IResult Update(CreditCard entity)
        {
            _creditCardDal.Update(entity);
            return new SuccessResult("Kredi Kartı" + Messages.Updated);
        }

        private IResult CheckIfCardIsExists(string creditCardNumber)
        {
            if (_creditCardDal.GetAll().Any(x => x.CreditCardNumber == creditCardNumber))
            {
                return new ErrorResult("Kredi Kartı" + Messages.AlreadyExist);
            }
            return new SuccessResult();
        }

    }
}
