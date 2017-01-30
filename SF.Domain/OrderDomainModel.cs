//------------------------------------------------------------------------------
// OrderDomainModel.cs
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
using SF.Repositoriy.Entities;

namespace SF.Domain
{
    public class OrderDomainModel : BaseDomainModel
    {
        public int OrderId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public string No { get; set; }

        public byte State { get; set; }

        public DateTime StartDate { get; set; }

        public short Days { get; set; }

        public Decimal GrandTotal { get; set; }

        public string OrderSource { get; set; }

        public string GuestInfo { get; set; }

        public bool IsEnabled { get; set; }

        [StringLength(2000)]
        public string Note { get; set; }

        public int RoomId { get; set; }
    }
}
