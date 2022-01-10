using ApplicantsManagement.Data.Entities;
using ApplicantsManagement.Dto.Applicants;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicantsManagement.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Applicant, ApplicantOutput>();
            CreateMap<AddApplicantInput, Applicant>();
            CreateMap<UpdateApplicantInput, Applicant>();
        }
    }
}
