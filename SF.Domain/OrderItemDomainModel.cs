//------------------------------------------------------------------------------
// OrderItemDomainModel.cs
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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SF.Repositoriy.Entities;

namespace SF.Domain
{
    public class OrderItemDomainModel : BaseDomainModel
    {
        public int OrderItemId { get; set; }

        public DateTime? StartDate { get; set; }

        public short? Days { get; set; }

        public Decimal? UnitPrice { get; set; }

        public Decimal Total { get; set; }

        /// <summary>
        /// Cost type: 1- Income, 2- Outcome
        /// </summary>
        public byte Type { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public int OrderId { get; set; }
    }
}
