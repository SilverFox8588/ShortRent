//------------------------------------------------------------------------------
// AccountController.cs
//
// <copyright from='2017' to='2117' company='SF Technology'> 
// Copyright (c) SF Technology. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/23/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Web.Http;

using SF.Domain;
using SF.ILogic;

namespace SF.ShortRentManage.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IAccountLogic _accountLogic;

        public AccountController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public IEnumerable<AccountDomainModel> Get()
        {
            return _accountLogic.GetAll();
        }

        public AccountDomainModel Get(int id)
        {
            return _accountLogic.Get(id);
        }

        public void Post([FromBody]AccountDomainModel domain)
        {
            _accountLogic.Create(domain);
        }

        public void Put(int id, [FromBody]AccountDomainModel domain)
        {
            _accountLogic.Edit(domain);
        }

        public void Delete(int id)
        {
            _accountLogic.Delete(id);
        }
    }
}
