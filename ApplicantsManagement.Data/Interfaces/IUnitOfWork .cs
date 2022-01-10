using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsManagement.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicantRepository Applicants { get; }
        int Complete();
    }
}
