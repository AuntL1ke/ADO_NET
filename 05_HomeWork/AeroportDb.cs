using System.Data.Entity;

namespace _05_HomeWork
{
    public class AeroportDb : DbContext
    {
      
        public AeroportDb()
            : base("name=AeroportDb")
        {
        }
        public virtual DbSet<Airplane> Airplanes { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Client> CLients { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

     
    }


}