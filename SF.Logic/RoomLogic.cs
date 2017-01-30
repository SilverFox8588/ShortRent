//------------------------------------------------------------------------------
// RoomLogic.cs
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
    public class RoomLogic : IRoomLogic
    {
        private readonly IRoomService _roomService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public RoomLogic(IRoomService roomService, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _roomService = roomService;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(RoomDomainModel model)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _roomService.Create(model.ToDataModel());
                unitWork.Commit();
            }
        }

        public void Edit(RoomDomainModel model)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _roomService.Edit(model.ToDataModel());
                unitWork.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var unitWork = _unitOfWorkFactory.GetCurrentUnitOfWork())
            {
                _roomService.Delete(id);
                unitWork.Commit();
            }
        }

        public RoomDomainModel Get(int id)
        {
            var user = _roomService.Get(id);
            return user.ToDomainModel();
        }

        public List<RoomDomainModel> GetAll()
        {
            var model = _roomService.Query();
            return !model.Any()
                ? null
                : model.ToList()
                    .Select(m => m.ToDomainModel())
                    .ToList();
        }

        public PagedList<RoomDomainModel> GetRooms(RoomQueryModel queryModel)
        {
            var source = _roomService.Query();

            if (!string.IsNullOrEmpty(queryModel.Name))
            {
                source = source.Where(x => x.Name.Contains(queryModel.Name));
            }

            if (queryModel.ClientId > 0)
            {
                source = source.Where(x => x.ClientId == queryModel.ClientId);
            }

            if (queryModel.State > 0)
            {
                source = source.Where(x => x.State == queryModel.State);
            }

            if (queryModel.Type > 0)
            {
                source = source.Where(x => x.Type == queryModel.Type);
            }

            if (queryModel.IsEnabled.HasValue)
            {
                source = source.Where(x => x.IsEnabled == queryModel.IsEnabled);
            }

            if (string.IsNullOrEmpty(queryModel.OrderBy))
            {
                queryModel.OrderBy = "RoomId";
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
            var result = new PagedList<RoomDomainModel>(pageItems, queryModel.PageIndex,
                queryModel.PageSize, pageCount);

            return result;
        }
    }
}
