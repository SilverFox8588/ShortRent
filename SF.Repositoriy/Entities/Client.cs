//------------------------------------------------------------------------------
// Client.cs
//
// <copyright from='2017' to='2117' company='Smartware Enterprises Inc'> 
// Copyright (c) Smartware Enterprises Inc. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/23/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace SF.Repositoriy.Entities
{
    public class Client : BaseModel
    {
        [Key]
        public int ClientId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public string Note { get; set; }
    }
}
