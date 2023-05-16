using DataSyncApi.Interfaces;
using DataSyncApi.Models;
using DataSyncApi.Services;
using Moq;

namespace DataSyncApi.Tests
{
    public class DataLoaderTests
    {
        private Mock<IDatasetRepository> _datasetRepositoryMock;
        private DataLoader _dataLoader;

        [SetUp]
        public void Setup()
        {
            _datasetRepositoryMock = new Mock<IDatasetRepository>();
            _dataLoader = new DataLoader(_datasetRepositoryMock.Object);
        }

        [Test]
        public async Task GetDatasetsStatusAsync_ShouldReturnDatasetStatuses()
        {
            // Arrange
            var datasets = new List<Dataset>
        {
            new Dataset { Id = 1, Name = "Dataset 1" },
            new Dataset { Id = 2, Name = "Dataset 2" },
            new Dataset { Id = 3, Name = "Dataset 3" }
        };

            _datasetRepositoryMock.Setup(repo => repo.GetDatasets()).ReturnsAsync(datasets);

            // Act
            var result = await _dataLoader.GetDatasetsStatusAsync();

            // Assert
            Assert.That(result.Count, Is.EqualTo(datasets.Count));
            foreach (var dataset in datasets)
            {
                var datasetStatus = result.FirstOrDefault(ds => ds.DatasetId == dataset.Id);
                Assert.IsNotNull(datasetStatus);
                Assert.That(datasetStatus.DatasetName, Is.EqualTo(dataset.Name));
                Assert.That(new[] { StatusType.InProgress, StatusType.Success, StatusType.Error }, Does.Contain(datasetStatus.Status));
            }
        }

        [Test]
        public async Task GetDatasetsStatusAsync_ShouldReturnEmptyList_WhenNoDatasets()
        {
            // Arrange
            var datasets = new List<Dataset>();
            _datasetRepositoryMock.Setup(repo => repo.GetDatasets()).ReturnsAsync(datasets);

            // Act
            var result = await _dataLoader.GetDatasetsStatusAsync();

            // Assert
            Assert.IsEmpty(result);
        }
    }

}

