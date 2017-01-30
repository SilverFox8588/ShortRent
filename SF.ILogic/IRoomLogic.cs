//------------------------------------------------------------------------------
// IRoomLogic.cs
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

using SF.Domain;
using SF.Domain.ResultModels;
using SF.Repositoriy.Entities;

namespace SF.ILogic
{
    public interface IRoomLogic
    {
        void Create(RoomDomainModel model);

        void Edit(RoomDomainModel model);

        void Delete(int id);

        RoomDomainModel Get(int id);

        List<RoomDomainModel> GetAll();

        PagedList<RoomDomainModel> GetRooms(RoomQueryModel queryModel);
    }
}
