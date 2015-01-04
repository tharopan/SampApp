using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampAppDAL.Context;
using SampAppDAL.Dtos;

namespace SampAppDAL.Repository
{
    public class SampAppUnitOfWork
    {
        private SampAppContext context = new SampAppContext();

        private SampApRepository<StudentDto> studentRepository;

        public SampApRepository<StudentDto> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new SampApRepository<StudentDto>(context);
                }
                return studentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
