using InterviewQuestion.Controllers;
using InterviewQuestion.Models;
using InterviewQuestion.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace RandomCandidatesAPITests
{
    public class CandidatesControllerTests
    {
        [Fact]
        public void GenerateRandomCandidates_Returns20Candidates()
        {
            // Arrange
            var mockService = new Mock<ICandidateService>();
            var expectedCandidates = new List<Candidate>
            {
                new Candidate { Id = 0, Name = "L0" },
                new Candidate { Id = 1, Name = "L1" },
                // ... 生成20个考生
            };
            mockService.Setup(service => service.GenerateRandomCandidates(20))
                       .Returns(expectedCandidates);
            var controller = new CandidatesController(mockService.Object);

            // Act
            var result = controller.GenerateRandomCandidates(20);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var candidates = Assert.IsType<List<Candidate>>(okResult.Value);
            Assert.Equal(20, candidates.Count);
            Assert.Equal(expectedCandidates, candidates);
            mockService.Verify(service => service.GenerateRandomCandidates(20), Times.Once());
        }

        [Fact]
        public void ReorderCandidates_ReturnsReorderedCandidates()
        {
            // Arrange
            var mockService = new Mock<ICandidateService>();
            var inputCandidates = new List<Candidate>
            {
                new Candidate { Id = 0, Name = "L0" },
                new Candidate { Id = 1, Name = "L1" },
                new Candidate { Id = 2, Name = "L2" },
                new Candidate { Id = 3, Name = "L3" },
            };
            var expectedReorderedCandidates = new List<Candidate>
            {
                new Candidate { Id = 0, Name = "L0" },
                new Candidate { Id = 3, Name = "L3" },
                new Candidate { Id = 1, Name = "L1" },
                new Candidate { Id = 2, Name = "L2" },
            };
            mockService.Setup(service => service.ReorderCandidates(It.IsAny<List<Candidate>>()))
                       .Returns(expectedReorderedCandidates);
            var controller = new CandidatesController(mockService.Object);

            // Act
            var result = controller.ReorderCandidates(new List<int> { 0, 1, 2, 3 });

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var candidates = Assert.IsType<List<Candidate>>(okResult.Value);
            Assert.Equal(4, candidates.Count);
            Assert.Equal(expectedReorderedCandidates, candidates);
            mockService.Verify(service => service.ReorderCandidates(It.IsAny<List<Candidate>>()), Times.Once());
        }
    }
}