using Microsoft.AspNetCore.Mvc;
using Rechtefriet_V4.Data;
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

            [HttpGet("{index:int}", Name = "Getklant")]
            public async Task<ActionResult<Klant>> GetKlant(int index)
            {
                var klant = await _context.Klants.FindAsync(index);

                if (klant == null)
                {
                    return NotFound();
                }

                return Ok(klant);
            }

            [HttpPost("{index:int, Name:string}", Name = "Changename")]
            public async Task<ActionResult<Klant>> Postname(int index, string name)
            {
                var klant = await _context.Klants.FindAsync(index);

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
            var klant = await _context.Klants.FindAsync(index);

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
