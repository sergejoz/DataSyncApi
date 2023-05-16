using System;
using DataSyncApi.Interfaces;
using DataSyncApi.Models;
using DataSyncApi.Data;
using Microsoft.EntityFrameworkCore;

namespace DataSyncApi.Repositories
{
    public class DatasetRepository : IDatasetRepository
    {
        private readonly AppDbContext _dbContext;

        public DatasetRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Dataset>> GetDatasets()
        {
            return await _dbContext.Datasets.ToListAsync();
        }
    }

}

