﻿//------------------------------------------------------------------------------
// AccountQueryModel.cs
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
    public class AccountQueryModel : BaseQueryModel
    {
        public string Login { get; set; }

        public string UserName { get; set; }

        public bool? IsEnabled { get; set; }

        public int ClientId { get; set; }
    }
}
