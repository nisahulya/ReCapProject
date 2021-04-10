using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
        IResult CheckIfCustomer(int userId);
        IDataResult<User> GetUser(User user);
        IDataResult<User> GetById(int userId);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
    }
}
