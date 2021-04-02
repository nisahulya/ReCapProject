using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CartPayment : IEntity
    {
        public int CartPaymentId { get; set; }
        public int CustomerId { get; set; }
        public string CardholderFirstNameLastName { get; set; }
        public string CreditCardNumber { get; set; }
        public string ValidThru { get; set; }
        public string CardValidationValue { get; set; }
        public decimal ExtractofAccount { get; set; }
    }
}
