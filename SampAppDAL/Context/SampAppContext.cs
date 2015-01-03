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
        public SampAppContext() : base()
        {
                
        }

        DbSet<StudentDto> Students { get; set; }
    }
}
