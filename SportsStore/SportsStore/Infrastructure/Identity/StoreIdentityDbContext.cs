using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Infrastructure.Identity
{
    public class StoreIdentityDbContext : IdentityDbContext<StoreUser>
    {
        public StoreIdentityDbContext() : base("SportsStoreIdentityDb")
        {
            Database.SetInitializer(new StoreIdentityDbInitializer());
        }

        public static StoreIdentityDbContext Create()
        {
            return new StoreIdentityDbContext();
        }
    }
}