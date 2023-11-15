using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.JobUseCase
{
    public record CreateNewJobRequest(string Keyword, string Country) : IRequest<CreateNewJobResponse>;
    public record CreateNewJobResponse(int Id);

    public class CreateNewJobHandler : IRequestHandler<CreateNewJobRequest, CreateNewJobResponse>
    {
        private readonly IJobRepository jobRepository;
        private readonly IJobIndexService jobIndexService;

        public CreateNewJobHandler(IJobRepository jobRepository, IJobIndexService jobIndexService)
        {
            this.jobRepository = jobRepository;
            this.jobIndexService = jobIndexService;
        }

        public async Task<CreateNewJobResponse> Handle(CreateNewJobRequest request, CancellationToken cancellationToken)
        {
            var job = new Job
            {
                CreateDate = DateTime.Now,
                Country = request.Country,
                Keyword = request.Keyword
            };

            jobRepository.save(job);
            jobIndexService.IndexJobAsync(job);

            return new CreateNewJobResponse(0);
        }
    }
}
