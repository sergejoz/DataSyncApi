using System;
using DataSyncApi.Interfaces;
using DataSyncApi.Models;

namespace DataSyncApi.Services
{
	public class DataLoader : IDataLoader
	{
        private readonly IDatasetRepository _datasetRepository;


        public DataLoader(IDatasetRepository datasetRepository)
        {
            _datasetRepository = datasetRepository;
        }


        public async Task<List<DatasetStatus>> GetDatasetsStatusAsync()
        {
            var datasets = await _datasetRepository.GetDatasets();
            var statusList = new List<DatasetStatus>();

            foreach (var dataset in datasets)
            { 
                statusList.Add(GetDatasetStatus(dataset));
            }

            return statusList;
        }

        public DatasetStatus GetDatasetStatus(Dataset dataset)
        {
            // Здесь должна быть реализация

            // Для тестирования добавим задержку и рандомный результат
            var random = new Random();
            var delayMinutes = random.Next(2, 7);
            Task.Delay(TimeSpan.FromMinutes(delayMinutes)); // Задержка (для имитации длительной операции)

            // Генерация рандомных статусов для каждого набора данных
            var status = random.Next(0, 2) == 0 ? StatusType.Success : StatusType.Error;

            return new DatasetStatus(dataset.Id, dataset.Name, status);
        }
    }
}

