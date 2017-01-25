//------------------------------------------------------------------------------
// AccountService.cs
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

using SF.IService;
using SF.Repositoriy;
using SF.Repositoriy.Entities;

namespace SF.Service
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        public AccountService(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
