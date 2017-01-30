//------------------------------------------------------------------------------
// Order.cs
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SF.Repositoriy.Entities
{
    public class Order : BaseModel
    {
        [Key]
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

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
