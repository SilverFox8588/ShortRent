//------------------------------------------------------------------------------
// Account.cs
//
// <copyright from='2017' to='2117' company='SF Technology'> 
// Copyright (c) SF Technology. All Rights Reserved. 
// Information Contained Herein is Proprietary and Confidential. 
// </copyright>
//
// Created: 01/23/2017
// Owner: HongYin Wang
//
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using SF.Repositoriy.Entities;

namespace SF.Domain
{
    public class AccountDomainModel : BaseDomainModel
    {
        public int AccountId { get; set; }

        [StringLength(50)]
        public string Login { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "User name cannot be empty.")]
        public string UserName { get; set; }

        public bool IsEnabled { get; set; }

        [StringLength(32)]
        public string Password { get; set; }

        public bool PasswordResetRequired { get; set; }

        [StringLength(50)]
        public string PasswordQuestion { get; set; }

        [StringLength(50)]
        public string PasswordAnswer { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public string Note { get; set; }

        public DateTime? LastLoggedIn { get; set; }
    }
}
