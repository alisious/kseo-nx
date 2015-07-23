using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kseo_nx.Model;

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
       // public virtual DbSet<Request<Person>> PersonRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Request<Person>>().ToTable("PersonRequests");
           
            modelBuilder.Entity<Workplace>()
                .Map(m=>m.MapInheritedProperties()).ToTable("Workplaces")
                .Property(w=>w.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<Address>()
                .Map(m => m.MapInheritedProperties()).ToTable("Addresses")
                .Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<Person>()
                .HasMany(e => e.Addresses);
            
            modelBuilder.Entity<Person>()
                .HasMany(e => e.Workplaces);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Reservations);

         }


        public Person GetPersonFile(Guid personId)
        {
           return Persons
                    .Include(p => p.Addresses)
                    .Include(p => p.Workplaces)
                    .Include(p=>p.Reservations)
                    .FirstOrDefault(p => p.Id.Equals(personId));
        }
    }
}
