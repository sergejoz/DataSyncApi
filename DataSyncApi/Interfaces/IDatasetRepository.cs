using System;
using DataSyncApi.Models;

namespace DataSyncApi.Interfaces
{
	public interface IDatasetRepository
	{
        Task<List<Dataset>> GetDatasets();
    }
}

