using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SampAppDAL.Dtos;


namespace SampAppDAL.Context
{
    public class SampAppContext : DbContext
    {
        public SampAppContext()
            : base("DefaultConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SampAppContext, Configuration>());
            //Database.SetInitializer<SampAppContext>(new CreateDatabaseIfNotExists<SampAppContext>());

            Database.SetInitializer<SampAppContext>(new DropCreateDatabaseIfModelChanges<SampAppContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }

        DbSet<StudentDto> Students { get; set; }
    }
}
