using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using BetReader.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Betreader.DataAccess.Database
{
    public class BetReaderContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Pick> Picks { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BetReaderContext() 
            : base("name=BetReaderDataBase")
        {
            System.Data.Entity.Database.SetInitializer<BetReaderContext>(null);
            Database.Initialize(true);
        }

        public BetReaderContext(DbConnection connection)
            : base(connection, true)
        {
            
        }

        public override int SaveChanges()
        {
            ObjectContext context = ((IObjectContextAdapter)this).ObjectContext;

            //Find all Entities that are Added/Modified that inherit from my EntityBase
            IEnumerable<ObjectStateEntry> objectStateEntries =
                from e in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                where
                    e.IsRelationship == false &&
                    e.Entity != null &&
                    typeof(BaseEntity).IsAssignableFrom(e.Entity.GetType())
                select e;

            var currentTime = DateTime.Now;

            foreach (var entry in objectStateEntries)
            {
                var entityBase = entry.Entity as BaseEntity;

                if (entityBase != null && entry.State == EntityState.Added)
                {
                    entityBase.CreatedOn = currentTime;
                }

                entityBase.LastModified = currentTime;
            }

            return base.SaveChanges();
        }
    }
}
