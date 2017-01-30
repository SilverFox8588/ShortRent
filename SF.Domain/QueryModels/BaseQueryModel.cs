//------------------------------------------------------------------------------
// BaseDomainModel.cs
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

namespace SF.Repositoriy.Entities
{
    public class BaseQueryModel
    {
        public BaseQueryModel()
        {
            PageIndex = 0;
            PageSize = 20;
            IsDesc = true;
        }

        public string OrderBy { get; set; }

        public bool IsDesc { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}
