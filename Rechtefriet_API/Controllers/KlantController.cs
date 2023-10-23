using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Rechtefriet_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlantController : Controller
    {
            private readonly RechtefrietDB_V2 _context;

            public KlantController(RechtefrietDB_V2 context)
            {
                _context = context;
            }

            [HttpGet("{id:int}", Name = "Getklant")]
            public async Task<ActionResult<Klant>> GetKlant(int id)
            {
                Klant klant = await _context.Klant.Where(c => c.Id == id).FirstAsync();

                if (klant == null)
                {
                    return NotFound();
                }

                return klant;
            }

            [HttpPost("{index:int, Name:string}", Name = "Changename")]
            public async Task<ActionResult<Klant>> Postname(int index, string name)
            {
                Klant klant = await _context.Klant.Where(c => c.Id == index).FirstAsync();

                if (klant == null)
                {
                    return NotFound();
                }
                else
                {
                    klant.Name = name;
                }
                return Ok(klant);
            }

            [HttpPost("{index:int, Adress:string}", Name = "ChangeAdress")]
            public async Task<ActionResult<Klant>> postadress(int index, string adress)
            {
                Klant klant = await _context.Klant.Where(c => c.Id == index).FirstAsync();

                if (klant == null)
                {
                    return NotFound();
                }
                else
                {
                    klant.Adress = adress;
                }
                return Ok(klant);
            }
        }
    }
