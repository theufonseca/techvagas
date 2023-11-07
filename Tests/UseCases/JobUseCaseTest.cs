using Application.Interfaces;
using Application.UseCase.JobUseCase;
using Domain.Entities;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Tests.UseCases
{
    public class JobUseCaseTest
    {
        [Test]
        public async Task CreateJob()
        {
            // Arrange
            var job = new Job { Country = "Brazil", CreateDate = DateTime.Now, Keyword = ".NET" };
            Mock<IJobRepository> mock = new Mock<IJobRepository>();
            mock.Setup(mock => mock.save(It.IsAny<Job>())).ReturnsAsync(1);

            // Act
            var handler = new CreateNewJobHandler(mock.Object);
            var result = await handler.Handle(new CreateNewJobRequest(job.Keyword, job.Country), new CancellationToken());

            // Assert
            result.Id.Should().Be(1);
        }
    }
}
