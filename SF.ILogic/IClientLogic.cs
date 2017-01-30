//------------------------------------------------------------------------------
// IClientLogic.cs
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
    public interface IClientLogic
    {
        void Create(ClientDomainModel model);

        void Edit(ClientDomainModel model);

        void Delete(int id);

        ClientDomainModel Get(int id);

        List<ClientDomainModel> GetAll();

        PagedList<ClientDomainModel> GetClients(ClientQueryModel queryModel);
    }
}
