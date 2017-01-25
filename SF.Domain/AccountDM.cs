//------------------------------------------------------------------------------
// Account.cs
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

using System;
using System.ComponentModel.DataAnnotations;

namespace SF.Domain
{
    public class AccountDM
    {
        [Key]
        public int AccountId { get; set; }

        [StringLength(50)]
        public string Login { get; set; }

        [StringLength(50)]
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

        public DateTime CreatedOn { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
