using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kseo_nx.Models;

namespace kseo_nx.DataAccess
{
    public class KseoNxDataContext :DbContext,IKseoNxDataContext
    {
        public KseoNxDataContext() :base("name=KseoNxContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<KseoNxDataContext>(new KseoNxDataContextInitializer());
        }

        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Workplace> Workplaces { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Workplace>().Map(m=>m.MapInheritedProperties()).ToTable("Workplaces");
            modelBuilder.Entity<Address>().Map(m => m.MapInheritedProperties()).ToTable("Addresses");


            modelBuilder.Entity<Person>()
                .HasMany(e => e.Addresses);
            
            modelBuilder.Entity<Person>()
                .HasMany(e => e.Workplaces);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Reservations);

        }
    }
}
