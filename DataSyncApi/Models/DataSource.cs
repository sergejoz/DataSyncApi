using System;
namespace DataSyncApi.Models
{
    /// <summary>
    /// Источник
    /// </summary>
	public class DataSource
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseType { get; set; }

     }
}

