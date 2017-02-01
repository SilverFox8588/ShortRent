//------------------------------------------------------------------------------
// IAccountLogic.cs
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

using SF.Domain;
using SF.Domain.ResultModels;
using SF.Repositoriy.Entities;

namespace SF.ILogic
{
    public interface IAccountLogic
    {
        void Create(AccountDomainModel model);

        void Edit(AccountDomainModel model);

        void Delete(int id);

        AccountDomainModel Get(int id);

        List<AccountDomainModel> GetAll();

        AccountDomainModel LoginByEmailAndPassword(string email, string password);

        PagedList<AccountDomainModel> GetAccounts(AccountQueryModel queryModel);

        bool CheckExist(string email, string id);

        AccountDomainModel GetAccountByLogin(string login);

        AccountDomainModel GetAccountByEmail(string email);
        AccountDomainModel GetAccountById(int id);
    }
}
