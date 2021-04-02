using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICartPaymentService
    {
        IDataResult<List<CartPayment>> GetAll();
        IDataResult<CartPayment> GetCartPaymentsByCustomerId(int customerId);
        IResult Add(CartPayment cartPayment);
        IResult Update(CartPayment cartPayment);
        IResult Delete(CartPayment cartPayment);
    }
}
