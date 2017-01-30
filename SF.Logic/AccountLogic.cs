//------------------------------------------------------------------------------
// AccountLogic.cs
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

using System;
using System.Collections.Generic;
using System.Linq;
using SF.ILogic;
using SF.IService;
using SF.Service.UnitOfWork;
using SF.Domain;
using SF.Domain.ResultModels;
using SF.Logic.Common;
using SF.Logic.ModelConverter;
using SF.Repositoriy.Entities;

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

        public void Create(AccountDomainModel model)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _accountService.Create(model.ToDataModel());
                unitWork.Commit();
            }
        }

        public void Edit(AccountDomainModel model)
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

        public AccountDomainModel Get(int id)
        {
            var user = _accountService.Get(id);
            return user.ToDomainModel();
        }

        public List<AccountDomainModel> GetAll()
        {
            var model = _accountService.Query();
            return !model.Any()
                ? null
                : model.ToList()
                    .Select(m => m.ToDomainModel())
                    .ToList();
        }

        public AccountDomainModel LoginByEmailAndPassword(string email, string password)
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

        public PagedList<AccountDomainModel> GetAccounts(AccountQueryModel queryModel)
        {
            var source = _accountService.Query();

            if (!string.IsNullOrEmpty(queryModel.UserName))
            {
                source = source.Where(x => x.UserName.Contains(queryModel.UserName));
            }

            if (queryModel.ClientId > 0)
            {
                source = source.Where(x => x.ClientId == queryModel.ClientId);
            }

            if (queryModel.IsEnabled.HasValue)
            {
                source = source.Where(x => x.IsEnabled == queryModel.IsEnabled);
            }

            if (string.IsNullOrEmpty(queryModel.OrderBy))
            {
                queryModel.OrderBy = "AccountId";
            }

            var pageCount = source.Count();

            source = queryModel.IsDesc
                    ? source.SortByDescending(queryModel.OrderBy)
                    : source.SortBy(queryModel.OrderBy);

            var pageItems = source.Skip(queryModel.PageIndex * queryModel.PageSize)
                .Take(queryModel.PageSize)
                .ToList()
                .Select(x => x.ToDomainModel())
                .ToList();
            var result = new PagedList<AccountDomainModel>(pageItems, queryModel.PageIndex,
                queryModel.PageSize, pageCount);

            return result;
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

        public AccountDomainModel GetAccountByUserName(string username)
        {
            var model = _accountService.Query().FirstOrDefault(n => n.UserName == username);
            return model == null ? null : model.ToDomainModel();
        }

        public AccountDomainModel GetAccountByEmail(string email)
        {
            var model = _accountService.Query().FirstOrDefault(n => n.Email == email);
            return model == null ? null : model.ToDomainModel();
        }
    }
}
