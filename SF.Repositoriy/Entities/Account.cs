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
using System.ComponentModel.DataAnnotations.Schema;

namespace SF.Repositoriy.Entities
{
    public class Account : BaseModel
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

        [StringLength(2000)]
        public string Note { get; set; }

        public DateTime? LastLoggedIn { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}
