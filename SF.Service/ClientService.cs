//------------------------------------------------------------------------------
// ClientService.cs
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

using SF.IService;
using SF.Repositoriy;
using SF.Repositoriy.Entities;

namespace SF.Service
{
    public class ClientService : BaseService<Client>, IClientService
    {
        public ClientService(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
