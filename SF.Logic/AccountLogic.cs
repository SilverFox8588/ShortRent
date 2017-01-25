//------------------------------------------------------------------------------
// AccountLogic.cs
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

using System;
using System.Collections.Generic;
using System.Linq;

using SF.ILogic;
using SF.IService;
using SF.Service.UnitOfWork;
using SF.Domain;
using SF.Logic.ModelConverter;

namespace SF.Logic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountService _accountService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public AccountLogic(IAccountService accountService, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _accountService = accountService;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(AccountDM model)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _accountService.Create(model.ToDataModel());
                unitWork.Commit();
            }
        }

        public void Edit(AccountDM model)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _accountService.Edit(model.ToDataModel());
                unitWork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _accountService.Delete(id);
                unitWork.Commit();
            }
        }

        public AccountDM Get(int id)
        {
            var user = _accountService.Get(id);
            return user.ToDomainModel();
        }

        public List<AccountDM> GetAll()
        {
            var model = _accountService.Query();
            return !model.Any()
                ? null
                : model.ToList()
                    .Select(m => m.ToDomainModel())
                    .ToList();
        }

        public AccountDM LoginByEmailAndPassword(string email, string password)
        {
            var model = _accountService.Query()
                .FirstOrDefault(n => n.Email == email && n.Password == password);
            if (model == null)
            {
                return null;
            }

            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                var user = _accountService.Get(model.AccountId);
                user.LastLoggedIn = DateTime.Now;
                _accountService.Edit(user);
                unitWork.Commit();
            }
            return model.ToDomainModel();
        }

        public int GetPageCountByCondition(string serchCondition)
        {
            return _accountService
                    .Query()
                    .Count(n => string.IsNullOrEmpty(serchCondition)
                        || n.UserName.Contains(serchCondition)
                        || n.Email.Contains(serchCondition));
        }

        public List<AccountDM> GetAccountsByCondition(string serchCondition)
        {
            var model = _accountService.Query()
                .Where(n => string.IsNullOrEmpty(serchCondition)
                    || n.UserName.Contains(serchCondition)
                    || n.Email.Contains(serchCondition))
                    .OrderBy(n => n.AccountId);

            return !model.Any()
                ? null
                : model.ToList()
                    .Select(m => m.ToDomainModel())
                    .ToList();
        }

        public bool CheckExist(string email, string userId)
        {
            if (_accountService.Query().Any())
            {
                return _accountService
                    .Query().Where(n => string.IsNullOrEmpty(userId) || n.AccountId.ToString() != userId)
                    .Any(x => x.Email.Equals(email));
            }
            return false;
        }

        public AccountDM GetAccountByUserName(string username)
        {
            var model = _accountService.Query().FirstOrDefault(n => n.UserName == username);
            return model == null ? null : model.ToDomainModel();
        }

        public AccountDM GetAccountByEmail(string email)
        {
            var model = _accountService.Query().FirstOrDefault(n => n.Email == email);
            return model == null ? null : model.ToDomainModel();
        }
    }
}
