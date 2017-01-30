//------------------------------------------------------------------------------
// ClientController.cs
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
    public class ClientController : ApiController
    {
        private readonly IClientLogic _clientLogic;

        public ClientController(IClientLogic clientLogic)
        {
            _clientLogic = clientLogic;
        }

        public IEnumerable<ClientDomainModel> Get()
        {
            return _clientLogic.GetAll();
        }

        public ClientDomainModel Get(int id)
        {
            return _clientLogic.Get(id);
        }

        public void Post([FromBody]ClientDomainModel domain)
        {
            _clientLogic.Create(domain);
        }

        public void Put(int id, [FromBody]ClientDomainModel domain)
        {
            _clientLogic.Edit(domain);
        }

        public void Delete(int id)
        {
            _clientLogic.Delete(id);
        }
    }
}
