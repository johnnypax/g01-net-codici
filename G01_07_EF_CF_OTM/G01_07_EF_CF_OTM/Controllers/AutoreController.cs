using G01_07_EF_CF_OTM.Models;
using G01_07_EF_CF_OTM.Services;
using Microsoft.AspNetCore.Mvc;

namespace G01_07_EF_CF_OTM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoreController : Controller
    {
        private readonly AutoreService _service;
        private readonly ILogger<AutoreController> _logger;
        public AutoreController(AutoreService service, ILogger<AutoreController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public ActionResult<IEnumerable<AutoreDTO>> ListaAutori()
        {
            try
            {
                var autori = _service.CercaTutti();
                return Ok(autori);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero degli Autori");
                return StatusCode(500, "Errore interno del server");
            }
        }
    }
}
