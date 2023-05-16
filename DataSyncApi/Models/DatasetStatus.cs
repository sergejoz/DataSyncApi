namespace DataSyncApi.Models
{
    public class DatasetStatus
    {
        public int DatasetId { get; set; }
        public string DatasetName { get; set; }
        public StatusType Status { get; set; }

        public DatasetStatus(int datasetId, string datasetName, StatusType status)
        {
            DatasetId = datasetId;
            DatasetName = datasetName;
            Status = status;
        }
    }

    public enum StatusType
    {
        InProgress,
        Success,
        Error
    }

}

