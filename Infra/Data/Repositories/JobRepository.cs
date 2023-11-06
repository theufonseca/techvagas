using Application.Interfaces;
using Dapper;
using Domain.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly MySqlConnection connection;
        public JobRepository(DataContext context)
        {
            connection = context.connection;
        }

        public async Task<int> save(Job job)
        {
            var id = await connection.ExecuteScalarAsync<int>(
                "INSERT INTO job (keyword, country, createDate) " +
                "VALUES (@keyword, @country, @createDate); " +
                "SELECT LAST_INSERT_ID();", job);

            return id;
        }
    }
}
