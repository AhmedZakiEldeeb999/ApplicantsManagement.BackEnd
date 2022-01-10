using ApplicantsManagement.Data;
using ApplicantsManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsManagement.Data.Interfaces
{
    public interface IApplicantRepository : IGenericRepository<Applicant>
    {
        IEnumerable<Applicant> GetAll();
    }
}
