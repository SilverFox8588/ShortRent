//------------------------------------------------------------------------------
// OrderController.cs
//
// <copyright from='2017' to='2117' company='SF Technology'> 
// Copyright (c) SF Technology. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/30/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Web.Http;
using SF.Domain;
using SF.ILogic;

namespace SF.ShortRentManage.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrderLogic _orderLogic;

        public OrderController(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        public IEnumerable<OrderDomainModel> Get()
        {
            return _orderLogic.GetAll();
        }

        public OrderDomainModel Get(int id)
        {
            return _orderLogic.Get(id);
        }

        public void Post([FromBody]OrderDomainModel domain)
        {
            _orderLogic.Create(domain);
        }

        public void Put(int id, [FromBody]OrderDomainModel domain)
        {
            _orderLogic.Edit(domain);
        }

        public void Delete(int id)
        {
            _orderLogic.Delete(id);
        }
    }
}
