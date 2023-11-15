using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;

namespace Infra.Elasticsearch
{
    public static class ElasticSearchExtensions
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration.GetSection("ELKConfiguration:Uri").Value!;
            var defaultIndex = configuration.GetSection("ELKConfiguration:index").Value!;

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex)
                .DefaultMappingFor<Domain.Entities.Job>(m => m.IdProperty(p => p.Id));

            var client = new ElasticClient(settings);
            services.AddSingleton<IElasticClient>(client);
            CreateIndex(client, defaultIndex);
        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<Domain.Entities.Job>(x => x.AutoMap())
            );
        }
    }
}
