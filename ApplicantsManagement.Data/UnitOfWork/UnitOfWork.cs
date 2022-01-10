using ApplicantsManagement.Data;
using ApplicantsManagement.Data.Interfaces;
using ApplicantsManagement.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsManagement.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApllicantDbContext _context;
        public UnitOfWork(ApllicantDbContext context)
        {
            _context = context;
            Applicants = new ApplicantRepository(_context);
        }
        public IApplicantRepository Applicants { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
