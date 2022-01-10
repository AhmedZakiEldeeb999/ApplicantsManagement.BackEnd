using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicantsManagement.Data.Entities;
using ApplicantsManagement.Domain.Applicants;
using ApplicantsManagement.Dto.Applicants;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicantsManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;
        public ApplicantController(IApplicantService applicantService, IMapper mapper)
        {
            _applicantService = applicantService;
            _mapper = mapper;
        }
        [HttpGet("ListApplicants")]
        public IActionResult ListApplicants()
        {
            string errorMessage = string.Empty;
            var applicantList = _applicantService.GetAll(ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return StatusCode(500, errorMessage);
            }
            var result = _mapper.Map<List<ApplicantOutput>>(applicantList);
            return Ok(result);
        }
        [HttpGet("GetApplicant")]
        public IActionResult GetApplicant(int applicantId)
        {
            string errorMessage = string.Empty;
            var applicant = _applicantService.GetById(applicantId, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return StatusCode(500, errorMessage);
            }
            var result = _mapper.Map<ApplicantOutput>(applicant);
            return Ok(result);
        }
        [HttpPost("AddApplicant")]
        public IActionResult AddApplicant([FromBody] AddApplicantInput input)
        {
            var validator = new AddApplicantInputValidator();
            var validationresult = validator.Validate(input);
            if (!validationresult.IsValid)
            {
                return BadRequest(validationresult.Errors.FirstOrDefault().ToString());
            }
            else
            {
                string errorMessage = string.Empty;
                var entity = _mapper.Map<Applicant>(input);
                _applicantService.AddApplicant(entity, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return StatusCode(500, errorMessage);
                }
                return Ok();
            }
        }
        [HttpPut("UpdateApplicant")]
        public IActionResult UpdateApplicant([FromBody] UpdateApplicantInput input)
        {
            var validator = new UpdateApplicantInputValidator();
            var validationresult = validator.Validate(input);
            if (!validationresult.IsValid)
            {
                return BadRequest(validationresult.Errors.FirstOrDefault().ToString());
            }
            else
            {
                string errorMessage = string.Empty;
                var entity = _mapper.Map<Applicant>(input);
                _applicantService.UpdateApplicant(entity, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return StatusCode(500, errorMessage);
                }
                return Ok();
            }
        }
        [HttpDelete("DeleteApplicant")]
        public IActionResult DeleteApplicant(int applicantId)
        {
            string errorMessage = string.Empty;
            _applicantService.RemoveApplicant(applicantId, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return StatusCode(500, errorMessage);
            }
            return Ok();
        }
    }
}