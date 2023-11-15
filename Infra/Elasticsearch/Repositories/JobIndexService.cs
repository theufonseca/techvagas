using Application.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Elasticsearch.Repositories
{
    public class JobIndexService : IJobIndexService
    {
        private readonly IElasticClient elasticClient;

        public JobIndexService(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        public async Task IndexJobAsync(Domain.Entities.Job job)
        {
            await elasticClient.IndexDocumentAsync(job);
        }
    }
}
