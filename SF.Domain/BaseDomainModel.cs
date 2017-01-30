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

using System;

namespace SF.Repositoriy.Entities
{
    public class BaseDomainModel
    {
        public DateTime CreatedOn { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
