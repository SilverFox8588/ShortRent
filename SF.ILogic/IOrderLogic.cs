//------------------------------------------------------------------------------
// IOrderLogic.cs
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
    public interface IOrderLogic
    {
        void Create(OrderDomainModel model);

        void Edit(OrderDomainModel model);

        void Delete(int id);

        OrderDomainModel Get(int id);

        List<OrderDomainModel> GetAll();

        PagedList<OrderDomainModel> GetOrders(OrderQueryModel queryModel);
    }
}
