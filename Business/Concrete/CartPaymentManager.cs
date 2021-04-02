using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CartPaymentManager : ICartPaymentService
    {
        private readonly ICartPaymentDal _cartPaymentdDal;

        public CartPaymentManager(ICartPaymentDal cartPaymentdDal)
        {
            _cartPaymentdDal = cartPaymentdDal;
        }


        [ValidationAspect(typeof(CartPaymentValidator))]
        public IResult Add(CartPayment cartPayment)
        {
            IResult result = BusinessRules.Run(CheckCreditCardNumber(cartPayment.CreditCardNumber));
            if (result != null)
            {
                return result;
            }

            _cartPaymentdDal.Add(cartPayment);
            return new SuccessResult(Messages.CartPaymentsAdded);
        }

        public IResult Delete(CartPayment cartPayment)
        {
            _cartPaymentdDal.Delete(cartPayment);
            return new SuccessResult(Messages.CartPaymentsDeleted);
        }

        public IDataResult<List<CartPayment>> GetAll()
        {
            return new SuccessDataResult<List<CartPayment>>(_cartPaymentdDal.GetAll(), Messages.CartPaymentsListed);
        }

        public IDataResult<CartPayment> GetCartPaymentsByCustomerId(int customerId)
        {
            return new SuccessDataResult<CartPayment>(_cartPaymentdDal.Get(c => c.CustomerId == customerId), Messages.GetCartPaymentsByCustomerIdListed);
        }

        public IResult Update(CartPayment cardPayment)
        {
            _cartPaymentdDal.Update(cardPayment);
            return new SuccessResult(Messages.CartPaymentsUpdated);
        }

        private IResult CheckCreditCardNumber(string creditCardNumber)
        {
            var result = _cartPaymentdDal.Get(c => c.CreditCardNumber == creditCardNumber);

            if (result != null)
            {
                return new ErrorResult(Messages.CreditCardNumberAllreadyExists);
            }
            return new SuccessResult();
        }
    }
}
