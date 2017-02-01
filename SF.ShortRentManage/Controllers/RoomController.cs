//------------------------------------------------------------------------------
// RoomController.cs
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
    public class RoomController : BaseApiController
    {
        private readonly IRoomLogic _roomLogic;

        public RoomController(IAccountLogic accountLogic, IRoomLogic roomLogic)
            : base(accountLogic)
        {
            _roomLogic = roomLogic;
        }

        public IEnumerable<RoomDomainModel> Get()
        {
            return _roomLogic.GetAll();
        }

        public RoomDomainModel Get(int id)
        {
            return _roomLogic.Get(id);
        }

        public void Post([FromBody]RoomDomainModel domain)
        {
            _roomLogic.Create(domain);
        }

        public void Put(int id, [FromBody]RoomDomainModel domain)
        {
            _roomLogic.Edit(domain);
        }

        public void Delete(int id)
        {
            _roomLogic.Delete(id);
        }
    }
}
