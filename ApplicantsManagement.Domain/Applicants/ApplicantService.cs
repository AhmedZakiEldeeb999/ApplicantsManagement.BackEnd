using ApplicantsManagement.Data.Entities;
using ApplicantsManagement.Data.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicantsManagement.Domain.Applicants
{
    public class ApplicantService : IApplicantService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ApplicantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Applicant> GetAll(ref string errorMsg)
        {
            try
            {
                var result = _unitOfWork.Applicants.GetAll().ToList();
                _unitOfWork.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return new List<Applicant>();
            }
        }
        public Applicant GetById(int id, ref string errorMsg)
        {
            try
            {
                var result = _unitOfWork.Applicants.GetById(id);
                _unitOfWork.Dispose();
                if (result == null)
                    errorMsg = string.Format("There is no Applicant with ID  {0}", id);
                return result;
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
                return new Applicant();
            }
        }
        public void AddApplicant(Applicant entity, ref string errorMsg)
        {
            try
            {
                _unitOfWork.Applicants.Add(entity);
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
        }
        public void UpdateApplicant(Applicant entity, ref string errorMsg)
        {
            try
            {
                var savedApplicant = _unitOfWork.Applicants.Find(a => a.Id == entity.Id).FirstOrDefault();
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
                    _unitOfWork.Applicants.Update(savedApplicant);
                    _unitOfWork.Complete();
                }

            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
        }
        public void RemoveApplicant(int id, ref string errorMsg)
        {
            try
            {
                var savedApplicant = _unitOfWork.Applicants.Find(a => a.Id == id).FirstOrDefault();
                if (savedApplicant == null)
                {
                    errorMsg = string.Format("There is no Applicant with ID  {0}", id);
                }
                else
                {
                    _unitOfWork.Applicants.Remove(savedApplicant);
                    _unitOfWork.Complete();
                }
            }
            catch (Exception ex)
            {
                errorMsg = ex.Message;
            }
        }

    }
}
