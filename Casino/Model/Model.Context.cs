﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Casino.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RPM_CasinoEntities : DbContext
    {
        public RPM_CasinoEntities()
            : base("name=RPM_CasinoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BalanceHistory> BalanceHistories { get; set; }
        public virtual DbSet<GamesHistory> GamesHistories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}
