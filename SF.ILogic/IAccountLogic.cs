//------------------------------------------------------------------------------
// IAccountLogic.cs
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

using SF.Domain;

namespace SF.ILogic
{
    public interface IAccountLogic
    {
        void Create(AccountDM model);

        void Edit(AccountDM model);

        void Delete(int id);

        AccountDM Get(int id);

        List<AccountDM> GetAll();

        AccountDM LoginByEmailAndPassword(string email, string password);

        int GetPageCountByCondition(string serchCondition);

        List<AccountDM> GetAccountsByCondition(string serchCondition);

        bool CheckExist(string email, string id);

        AccountDM GetAccountByUserName(string username);

        AccountDM GetAccountByEmail(string email);
    }
}
