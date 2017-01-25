//------------------------------------------------------------------------------
// SFContext.cs
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

using System.Data.Entity;

using SF.Repositoriy.Entities;

namespace SF.Repositoriy
{
    public class SFContext : DbContext
    {
        public SFContext() : base("name=SFContext")
        {
            Database.SetInitializer<SFContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //comment out this line to allow for a normal connection string 
            //throw new UnintentionalCodeFirstException();
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
