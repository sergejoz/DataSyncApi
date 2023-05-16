using System;
using System.Reflection;

namespace DataSyncApi.Models
{
    /// <summary>
    /// Набор данных
    /// </summary>
    public class Dataset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DataSourceId { get; set; }
        public List<FieldInfo> Fields { get; set; }
    }
}

