using ApplicantsManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicantsManagement.Domain.Applicants
{
    public interface IApplicantService
    {
        List<Applicant> GetAll(ref string errorMsg);
        Applicant GetById(int id, ref string errorMsg);
        void AddApplicant(Applicant entity, ref string errorMsg);
        void RemoveApplicant(int id, ref string errorMsg);
        void UpdateApplicant(Applicant entity, ref string errorMsg);
    }
}
