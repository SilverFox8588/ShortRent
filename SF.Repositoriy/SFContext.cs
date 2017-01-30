//------------------------------------------------------------------------------
// SFContext.cs
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

        public DbSet<Client> Clients { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
