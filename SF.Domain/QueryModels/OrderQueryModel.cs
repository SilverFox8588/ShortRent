//------------------------------------------------------------------------------
// OrderQueryModel.cs
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
    public class OrderQueryModel : BaseQueryModel
    {
        public string Name { get; set; }

        public string No { get; set; }

        public byte State { get; set; }

        public string OrderSource { get; set; }

        public bool? IsEnabled { get; set; }

        public int RoomId { get; set; }
    }
}
