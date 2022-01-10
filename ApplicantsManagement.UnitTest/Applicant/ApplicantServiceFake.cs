using ApplicantsManagement.Data.Entities;
using ApplicantsManagement.Domain.Applicants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ApplicantsManagement.UnitTest.Applicant
{
    public class ApplicantServiceFake : IApplicantService
    {
        private readonly List<Data.Entities.Applicant> _applicants;
        public ApplicantServiceFake()
        {
            _applicants = new List<Data.Entities.Applicant>()
            {
                new Data.Entities.Applicant(){ Id=1,Address="Cairo Egypt",Age=40,CountryOfOrigin="Cairo",EMailAdress="ahmed@gmail.com",FamilyName="Zaki eldeeb",Hired=true,Name="Ahmed Zaki Eldeeb"},
                new Data.Entities.Applicant(){ Id=2,Address="Alex Egypt",Age=30,CountryOfOrigin="Alex",EMailAdress="ali@gmail.com",FamilyName="Zaki eldeeb",Hired=true,Name="ali Zaki Eldeeb"},
                new Data.Entities.Applicant(){ Id=3,Address="Giza Egypt",Age=25,CountryOfOrigin="Giza",EMailAdress="sam@gmail.com",FamilyName="Zaki eldeeb",Hired=true,Name="sam Zaki Eldeeb"},
            };
        }

        public void AddApplicant(Data.Entities.Applicant entity, ref string errorMsg)
        {
            entity.Id = 4;
            _applicants.Add(entity);
        }

        public List<Data.Entities.Applicant> GetAll(ref string errorMsg)
        {
            return _applicants;
        }

        public Data.Entities.Applicant GetById(int id, ref string errorMsg)
        {
            return _applicants.Where(a => a.Id == id).FirstOrDefault();

        }

        public void RemoveApplicant(int id, ref string errorMsg)
        {
            var applicant = _applicants.Where(a => a.Id == id).FirstOrDefault();
            if (applicant == null)
            {
                errorMsg = string.Format("There is no Applicant with ID  {0}", id);
            }
            else
            {
                _applicants.Remove(applicant);
            }

        }

        public void UpdateApplicant(Data.Entities.Applicant entity, ref string errorMsg)
        {
            var savedApplicant = _applicants.Where(a => a.Id == entity.Id).FirstOrDefault();
            if (savedApplicant == null)
            {
                errorMsg = string.Format("There is no Applicant with ID  {0}", entity.Id);
            }
            else
            {
                savedApplicant.EMailAdress = entity.EMailAdress;
                savedApplicant.Address = entity.Address;
                savedApplicant.Age = entity.Age;
                savedApplicant.CountryOfOrigin = entity.CountryOfOrigin;
                savedApplicant.FamilyName = entity.FamilyName;
                savedApplicant.Hired = entity.Hired;
                savedApplicant.Name = entity.Name;
                _applicants.Remove(savedApplicant);
                _applicants.Add(savedApplicant);
            }
        }
    }
}
