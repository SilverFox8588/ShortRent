//------------------------------------------------------------------------------
// OrderItem.cs
//
// <copyright from='2017' to='2117' company='SF Technology'> 
// Copyright (c) SF Technology. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/29/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SF.Repositoriy.Entities
{
    public class OrderItem : BaseModel
    {
        [Key]
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

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
