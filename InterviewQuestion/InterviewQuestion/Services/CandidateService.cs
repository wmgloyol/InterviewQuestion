using System;
using System.Collections.Generic;
using System.Linq;
using InterviewQuestion.Models;

namespace InterviewQuestion.Services
{
    public class CandidateService : ICandidateService
    {
        public List<Candidate> GenerateRandomCandidates(int count)
        {
            var candidates = new List<Candidate>();
            for (int i = 0; i < count; i++)
            {
                candidates.Add(new Candidate { Id = i, Name = $"L{i}" });
            }
            return candidates;
        }

        public List<Candidate> ReorderCandidates(List<Candidate> candidates)
        {
            var reorderedCandidates = new List<Candidate>();
            int n = candidates.Count;
            for (int i = 0; i < n / 2; i++)
            {
                reorderedCandidates.Add(candidates[i]);
                reorderedCandidates.Add(candidates[n - 1 - i]);
            }
            if (n % 2 != 0)
            {
                reorderedCandidates.Add(candidates[n / 2]);
            }
            return reorderedCandidates;
        }
    }
}
