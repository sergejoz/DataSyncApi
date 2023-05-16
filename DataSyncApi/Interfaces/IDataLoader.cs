using DataSyncApi.Models;

namespace DataSyncApi.Interfaces
{
    public interface IDataLoader
    {
        Task<List<DatasetStatus>> GetDatasetsStatusAsync();
    }
}

