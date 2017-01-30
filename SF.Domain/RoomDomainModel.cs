//------------------------------------------------------------------------------
// RoomDomainModel.cs
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

using System.ComponentModel.DataAnnotations;
using SF.Repositoriy.Entities;

namespace SF.Domain
{
    public class RoomDomainModel : BaseDomainModel
    {
        public int RoomId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public byte State { get; set; }

        public byte Type { get; set; }

        public int UnitPrice { get; set; }

        [StringLength(200)]
        public string ImageUrl { get; set; }

        public bool IsEnabled { get; set; }

        [StringLength(2000)]
        public string Note { get; set; }

        public int ClientId { get; set; }
    }
}
