﻿//------------------------------------------------------------------------------
// OrderLogic.cs
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
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderService _orderService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public OrderLogic(IOrderService orderService, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _orderService = orderService;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(OrderDomainModel model)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _orderService.Create(model.ToDataModel());
                unitWork.Commit();
            }
        }

        public void Edit(OrderDomainModel model)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _orderService.Edit(model.ToDataModel());
                unitWork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _orderService.Delete(id);
                unitWork.Commit();
            }
        }

        public OrderDomainModel Get(int id)
        {
            var user = _orderService.Get(id);
            return user.ToDomainModel();
        }

        public List<OrderDomainModel> GetAll()
        {
            var model = _orderService.Query();
            return !model.Any()
                ? null
                : model.ToList()
                    .Select(m => m.ToDomainModel())
                    .ToList();
        }

        public PagedList<OrderDomainModel> GetOrders(OrderQueryModel queryModel)
        {
            var source = _orderService.Query();

            if (!string.IsNullOrEmpty(queryModel.Name))
            {
                source = source.Where(x => x.Name.Contains(queryModel.Name));
            }

            if (queryModel.RoomId > 0)
            {
                source = source.Where(x => x.RoomId == queryModel.RoomId);
            }

            if (queryModel.IsEnabled.HasValue)
            {
                source = source.Where(x => x.IsEnabled == queryModel.IsEnabled);
            }

            if (string.IsNullOrEmpty(queryModel.OrderBy))
            {
                queryModel.OrderBy = "OrderId";
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
            var result = new PagedList<OrderDomainModel>(pageItems, queryModel.PageIndex,
                queryModel.PageSize, pageCount);

            return result;
        }
    }
}
