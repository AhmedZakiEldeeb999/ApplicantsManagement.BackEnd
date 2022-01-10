using ApplicantsManagement.Controllers;
using ApplicantsManagement.Domain.Applicants;
using ApplicantsManagement.Dto.Applicants;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApplicantsManagement.UnitTest.Applicant
{
    public class ApplicantControllerTest
    {
        private readonly ApplicantController _controller;
        private readonly IApplicantService _service;
        private readonly IMapper _mapper;
        public ApplicantControllerTest()
        {
            _service = new ApplicantServiceFake();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicantsManagement.MappingProfile.MappingProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            _controller = new ApplicantController(_service, _mapper);
        }
        [Fact]
        public async Task List_Applicants_Return_All_Items()
        {
            // Act
            var actionResult = _controller.ListApplicants() as OkObjectResult;
            // Assert
            Assert.NotNull(actionResult);
            var response = actionResult.Value as List<ApplicantOutput>;
            // Assert
            Assert.Equal(3, response.Count);
        }
        [Fact]
        public async Task Create_New_Applicant_Should_Create_NewOne()
        {
            // Arrange
            AddApplicantInput testItem = new AddApplicantInput();
            testItem.Address = "Cairo Egypt";
            testItem.Age = 45;
            testItem.CountryOfOrigin = "Cairo";
            testItem.EMailAdress = "test@gmail.com";
            testItem.FamilyName = "Eldeeb";
            testItem.Hired = false;
            testItem.Name = "Jeff Tindall";
            // Act
            var actionResult = _controller.AddApplicant(testItem) as OkResult;
            // Assert
            Assert.NotNull(actionResult);
        }
        [Fact]
        public async Task Create_New_Applicant_With_Empty_Adress_Should_Not_Create_NewOne()
        {
            // Arrange
            AddApplicantInput testItem = new AddApplicantInput();
            testItem.Age = 45;
            testItem.CountryOfOrigin = "Cairo";
            testItem.EMailAdress = "test@gmail.com";
            testItem.FamilyName = "Eldeeb";
            testItem.Hired = false;
            testItem.Name = "Jeff Tindall";
            // Act
            var actionResult = _controller.AddApplicant(testItem) as BadRequestObjectResult;
            var response = actionResult.Value as string;
            // Assert
            Assert.Equal("Address cant be empty", response);
        }
        [Fact]
        public async Task Get_Applicant_Should_Return()
        {
            // Act
            var actionResult = _controller.ListApplicants() as OkObjectResult;
            var list = actionResult.Value as List<ApplicantOutput>;
            var getApplicantResult = _controller.GetApplicant(list.FirstOrDefault().Id) as OkObjectResult;
            // Assert
            var applicantOutput = getApplicantResult.Value as ApplicantOutput;
            // Assert
            Assert.NotNull(applicantOutput);
        }
        [Fact]
        public async Task Delete_Applicant_Should_Return()
        {
            // Act
            var actionResult = _controller.ListApplicants() as OkObjectResult;
            var list = actionResult.Value as List<ApplicantOutput>;
            var countBefore = list.Count;
            var result = _controller.DeleteApplicant(list.FirstOrDefault().Id) as OkResult;
            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public async Task Update_Applicant_Should_Update()
        {
            // Arrange
            var actionResult = _controller.ListApplicants() as OkObjectResult;
            var list = actionResult.Value as List<ApplicantOutput>;

            UpdateApplicantInput testItem = new UpdateApplicantInput();
            testItem.Id = list.FirstOrDefault().Id;
            testItem.Age = 45;
            testItem.CountryOfOrigin = "Cairo";
            testItem.EMailAdress = "test@gmail.com";
            testItem.FamilyName = "Eldeeb";
            testItem.Hired = false;
            testItem.Address = "Cairo Egypt";
            testItem.Name = "Amr Ali";
            // Act
            var result = _controller.UpdateApplicant(testItem) as OkResult;
            // Assert
            Assert.NotNull(result);
        }
    }
}
