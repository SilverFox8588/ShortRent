//------------------------------------------------------------------------------
// AccountController.cs
//
// <copyright from='2017' to='2117' company='Smartware Enterprises Inc'> 
// Copyright (c) Smartware Enterprises Inc. All Rights Reserved. 
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

        public IEnumerable<AccountDM> Get()
        {
            return _accountLogic.GetAll();
        }

        public AccountDM Get(int id)
        {
            return _accountLogic.Get(id);
        }

        public void Post([FromBody]AccountDM domain)
        {
            _accountLogic.Create(domain);
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
