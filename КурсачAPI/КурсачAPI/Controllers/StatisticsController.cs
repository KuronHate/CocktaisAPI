using Microsoft.AspNetCore.Mvc;
using КурсачAPI.Clients;
using КурсачAPI.Models;

namespace КурсачAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StatisticsController : ControllerBase
    {
        private readonly ILogger<StatisticsController> Logger;
        public StatisticsController(ILogger<StatisticsController> logger)
        {
            Logger = logger;
        }
        [HttpGet]
        public List<Statistics> Drink()
        {
            Database db = new Database();
            return db.SelectStatisticsAsync().Result;
        }

        [HttpDelete]
        public void Delete()
        {
            Database db = new Database();
            db.DeleteStatisticsAsync();
        }
    }
}
