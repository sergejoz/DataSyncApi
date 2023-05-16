using Microsoft.AspNetCore.Mvc;
using DataSyncApi.Interfaces;
using DataSyncApi.Models;

namespace DataSyncApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatasetsController : ControllerBase
    {
        private readonly IDataLoader _dataLoader; // Интерфейс для загрузки данных

        public DatasetsController(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        [HttpGet]
        public async Task<IActionResult> GetDatasetsStatus()
        {
            try
            {
                var datasetsStatus = await _dataLoader.GetDatasetsStatusAsync();
                return Ok(datasetsStatus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
