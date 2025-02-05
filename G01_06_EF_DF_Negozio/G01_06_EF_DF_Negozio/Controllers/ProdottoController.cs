using G01_06_EF_DF_Negozio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace G01_06_EF_DF_Negozio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdottoController : Controller
    {
        //SOLO PER PROVARE!!! Da ristrutturare con Services, Repos e DTO
        private readonly G0104DfNegozioContext _context;

        public ProdottoController(G0104DfNegozioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Prodotto>> FindAll()
        {
            var sw = new Stopwatch();

            IEnumerable<Prodotto> lista = _context.Prodottos.ToList();

            sw.Stop();

            Console.WriteLine($"Tempo impiegato: {sw.ElapsedMilliseconds}");
            return Ok(lista);
        }

        [HttpGet("ricarico")]
        public ActionResult<IEnumerable<Prodotto>> FindAllAndRicarica()
        {
            Span<Prodotto> lista = _context.Prodottos.ToArray();

            foreach(var prod in lista)
            {
                prod.Prezzo = prod.Prezzo * 1.3m;
            }

            return Ok(lista.ToArray());
        }

    }
}
