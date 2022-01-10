using ApplicantsManagement.Data;
using ApplicantsManagement.Data.Entities;
using ApplicantsManagement.Data.Interfaces;
using ApplicantsManagement.Data.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicantsManagement.Data.Repositories
{
    public class ApplicantRepository : GenericRepository<Applicant>, IApplicantRepository
    {
        public ApplicantRepository(ApllicantDbContext context) : base(context)
        {
        }
    }
}
