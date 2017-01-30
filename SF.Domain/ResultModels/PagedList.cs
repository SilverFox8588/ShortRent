//------------------------------------------------------------------------------
// PagedList.cs
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

using System;
using System.Collections.Generic;
using System.Linq;

namespace SF.Domain.ResultModels
{
    public class PagedList<T> : List<T>
    {
        public PagedList(List<T> source, int pageIndex, int pageSize, int totalCount)
        {
            if (pageSize < 1)
            {
                throw new ArgumentException(string.Format("Invalid Page Size: {0}", pageSize));
            }

            PageSize = pageSize;
            PageIndex = pageIndex;
            TotalCount = totalCount;
            TotalPages = (totalCount + pageSize - 1) / pageSize;

            if (source != null && source.Any())
            {
                AddRange(source);
            }
        }

        public int PageIndex { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public int TotalPages { get; }

        public bool HasPreviousPage => PageIndex > 0;

        public bool HasNextPage => PageIndex + 1 < TotalPages;
    }
}
