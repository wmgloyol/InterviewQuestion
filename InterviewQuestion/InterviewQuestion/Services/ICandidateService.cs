using InterviewQuestion.Models;

namespace InterviewQuestion.Services
{
    public interface ICandidateService
    {
        List<Candidate> GenerateRandomCandidates(int count);
        List<Candidate> ReorderCandidates(List<Candidate> candidates);
    }
}
