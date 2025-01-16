using InterviewQuestion.Models;
using InterviewQuestion.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet("generate")]
        public IActionResult GenerateRandomCandidates(int count)
        {
            if (count < 5)
            {
                count = 20; // 默认生成20个考生
            }
            var candidates = _candidateService.GenerateRandomCandidates(count);
            return Ok(candidates);
        }

        [HttpGet("reorder")]
        public IActionResult ReorderCandidates([FromQuery] List<int> ids)
        {
            if (ids == null || ids.Count < 2)
            {
                return BadRequest("Invalid candidate IDs");
            }

            var candidates = ids.Select(id => new Candidate { Id = id, Name = $"L{id}" }).ToList();
            var reorderedCandidates = _candidateService.ReorderCandidates(candidates);
            return Ok(reorderedCandidates);
        }

        [HttpGet("error")]
        public IActionResult TriggerError()
        {
            throw new Exception("This is a test exception");
        }
    }
}
