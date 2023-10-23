using Microsoft.AspNetCore.Mvc;

namespace Rechtefriet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlantController : Controller
    {
        private string GetklantName(int index)
        {
            return 
        }
        private string GetklantAdress(int index)
        {
            return 
        }
        private readonly ILogger<KlantController> _logger;

        public KlantController(ILogger<KlantController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{index:int}",Name = "GetKlant")]
        public Klant get(int index)
        {
            return new Klant()
            {
                Klantid = index,
                Name = GetklantName(index),
                Adress = GetklantAdress(index)
            };
        }
    }
}
